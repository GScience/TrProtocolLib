using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TrProtocolLib;
using TrProtocolLib.NetMessage;
using TrProtocolLib.NetType;

namespace TrForward
{
    public static class Program
    {
        public static Dictionary<int, Type> messageTypes = new Dictionary<int, Type>();
        public static TcpClient serverConnection;
        public static TcpClient playerConnection;

        public static NetworkStream serverStream;
        public static NetworkStream playerStream;

        static void Main(string[] args)
        {
            RegisterAllMessage();

            var server = TcpListener.Create(7777);
            server.Start();

            while (true)
            {
                if (serverConnection == null || !serverConnection.Connected)
                {
                    serverConnection = new TcpClient();
                    serverConnection.Connect("127.0.0.1", 6666);

                    serverStream = serverConnection.GetStream();
                }

                playerConnection = server.AcceptTcpClient();
                playerStream = playerConnection.GetStream();

                StartForward();
            }
        }

        static void RegisterAllMessage()
        {
            var types = typeof(INetMessage).Assembly.GetTypes();

            foreach (var type in types)
            {
                if (type.GetInterface("INetMessage") == null)
                    continue;
                var idField = type.GetField("ID", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
                if (idField == null)
                    continue;
                var id = (int)idField.GetValue(null);
                messageTypes[id] = type;
            }
        }

        static void StartForward()
        {
            var task1 = StartForward(serverStream, playerStream);
            var task2 = StartForward(playerStream, serverStream);
            task1.Wait();
            task2.Wait();
        }

        static INetMessage OnReceivedMessage(MessageRaw msg, Side side)
        {
            if (messageTypes.TryGetValue(msg.type, out var msgType))
            {
                var netMsg = (INetMessage) Activator.CreateInstance(msgType);

                netMsg.Side = side;

                using (var ms = new MemoryStream(msg.data))
                {
                    var subId = -1;
                    try
                    {
                        netMsg.OnDeserialize(new BinaryReader(ms));
                        if (netMsg is Msg82NetModule netModule)
                        {
                            subId = netModule.moduleId;

                            if (subId == 1)
                            {
                                if (netMsg.Side == Side.Server)
                                    Console.WriteLine($"<{netMsg.Side}> : {((NetworkText)netModule.moduleValue["text"]).text}");
                            }
                        }
                    }
                    catch (NotImplementedException e)
                    {
                        throw e;
                    }
                    catch (Exception e)
                    {
                        throw new Exception($"(SubPackage:{subId}) Failed to deserialize message\n" + e.ToString());
                    }
                    //Console.WriteLine($"Reveiced msg {msg.type} from " + netMsg.Side.ToString());

                    if (ms.Position != ms.Length)
                        throw new Exception($"(SubPackage:{subId}) Part of the data is not read");

                    // check whether the serialized result is same
                    byte[] data = null;
                    using (var memorystream = new MemoryStream())
                    using (var testWriter = new BinaryWriter(memorystream))
                    {
                        netMsg.OnSerialize(testWriter);
                        memorystream.Seek(0, SeekOrigin.Begin);
                        data = new byte[memorystream.Length];
                        memorystream.Read(data, 0, (int)memorystream.Length);
                    }

                    for (var i = 0; i < data.Length; ++i)
                        if (data[i] != msg.data[i])
                        {
                            Console.WriteLine($"Warning: (SubPackage:{subId}) Serialized result is not same with the original one");
                            break;
                        }
                }
                return netMsg;
            }
            else
                Console.WriteLine($"Unknown msg {msg.type}");
            return null;
        }

        static Task StartForward(NetworkStream from, NetworkStream to)
        {
            var task = new Task(() =>
            {
                while (serverConnection.Connected && playerConnection.Connected)
                {
                    MessageRaw msg;
                    try
                    {
                        var reader = new BinaryReader(from);
                        msg = new MessageRaw(reader);
                    }
                    catch
                    {
                        break;
                    }

                    INetMessage netMessage = null;

                    try
                    {
                        if (from == serverStream)
                            netMessage = OnReceivedMessage(msg, Side.Server);
                        else

                            netMessage = OnReceivedMessage(msg, Side.Client);
                    }
                    catch (NotImplementedException)
                    {
                        Console.WriteLine($"An not implemented message {msg.type}" );
                        netMessage = null;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Failed to read net message {msg.type} because {e.Message}");
                        netMessage = null;
                    }

                    try
                    {
                        if (netMessage != null)
                        {
                            try
                            {
                                using (var memoryStream = new MemoryStream())
                                {
                                    if (msg.type == Msg10SendSection.ID)
                                    {
                                        var sectionData = (Msg10SendSection)netMessage;
                                        foreach (var tile in sectionData.tiles)
                                        {
                                            tile.Value.wall = 0;
                                        }
                                    }
                                    if (msg.type == Msg16PlayerHP.ID)
                                    {
                                        var playerHp = (Msg16PlayerHP)netMessage;
                                        playerHp.maxHp = 1000;
                                        playerHp.hp = 1000;
                                    }
                                    using (var writer = new BinaryWriter(memoryStream))
                                    {
                                        netMessage.OnSerialize(writer);
                                        var message = new MessageRaw();
                                        message.type = msg.type;
                                        message.length = (short)(memoryStream.Length + 3);
                                        message.data = memoryStream.GetBuffer();

                                        var netWriter = new BinaryWriter(to);
                                        message.WriteTo(netWriter);
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine($"Failed to serialize net message {msg.type} because {e.Message}");
                                var writer = new BinaryWriter(to);
                                msg.WriteTo(writer);
                            }
                        }
                        else
                        {
                            var writer = new BinaryWriter(to);
                            msg.WriteTo(writer);
                        }
                    }
                    catch (Exception e)
                    {
                        break;
                    }
                }
            });
            task.Start();
            return task;
        }
    }
}
