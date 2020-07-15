using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using TrProtocol;
using TrProtocol.NetMessage;

namespace TrMapDownloader
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input Host");
            var host = Console.ReadLine();
            Console.WriteLine("Input Port");
            if (!short.TryParse(Console.ReadLine(), out var port))
                port = 7777;

            var client = new TcpClient();
            client.Connect(host, port);

            var netStream = client.GetStream();
            var reader = new BinaryReader(netStream);
            var writer = new BinaryWriter(netStream);

            var connect = new Msg1ConnectRequest();
            connect.version = "Terraria" + 230;
            SendMessage(writer, connect);

            /*var serverInfo = WaitMessage<Msg3SetUserSlot>(reader);

            var userInfo = new Msg4PlayerInfo();
            userInfo.playerId = serverInfo.playerId;
            userInfo.name = "TrMapDownloader";
            SendMessage(writer, userInfo);*/

            /*var requireWorldData = new Msg6RequireWorldData();
            SendMessage(writer, requireWorldData);*/

            var requireTiles = new Msg8RequestEssentialTiles();
            requireTiles.x = 0;
            requireTiles.y = 0;
            SendMessage(writer, requireTiles);

            var tilesData = WaitMessage<Msg10SendSection>(reader);

            foreach (var tile in tilesData.tiles)
            {
                Console.Write(tile.Value.wallColor());
            }
        }

        public static void SendMessage(BinaryWriter stream, INetMessage msg)
        {
            var msgRaw = new MessageRaw(msg);
            msgRaw.WriteTo(stream);
        }
        
        public static MessageRaw RecvMessage(BinaryReader stream)
        {
            return new MessageRaw(stream);
        }

        public static MessageRaw WaitMessage(BinaryReader reader, byte msgType)
        {
            MessageRaw msg;
            do
            {
                msg = RecvMessage(reader);

            } while (msg.type != msgType);

            return msg;
        }

        public static T WaitMessage<T>(BinaryReader reader) where T : INetMessage, new()
        {
            var idField = typeof(T).GetField("ID", BindingFlags.Static | BindingFlags.Public);
            if (idField == null)
                throw new Exception();
            var type = (byte)(int)idField.GetValue(null);

            var msg = WaitMessage(reader, type);
            return msg.ConvertTo<T>();
        }
    }
}
