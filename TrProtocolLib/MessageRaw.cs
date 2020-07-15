using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TrProtocolLib
{
    public struct MessageRaw
    {
        public short length;
        public byte type;
        public byte[] data;

        public MessageRaw(INetMessage netMsg)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var writer = new BinaryWriter(memoryStream))
                {
                    netMsg.OnSerialize(writer);
                    var idField = netMsg.GetType().GetField("ID", BindingFlags.Static | BindingFlags.Public);
                    if (idField == null)
                        throw new Exception();
                    type = (byte)(int)idField.GetValue(null);
                    length = (short)(memoryStream.Length + 3);
                    data = memoryStream.GetBuffer();
                }
            }
        }

        public MessageRaw(BinaryReader reader)
        {
            length = 0;
            type = 0;
            data = null;
            ReadFrom(reader);
        }

        public void WriteTo(BinaryWriter writer)
        {
            writer.Write(length);
            writer.Write(type);
            writer.BaseStream.Write(data, 0, length - 3);
        }

        public void ReadFrom(BinaryReader reader)
        {
            length = reader.ReadInt16();
            type = reader.ReadByte();
            data = reader.ReadBytes(length - 3);
        }

        public T ConvertTo<T>() where T: INetMessage, new()
        {
            var netMsg = new T();
            using (var ms = new MemoryStream(data))
            using (var reader = new BinaryReader(ms))
                netMsg.OnDeserialize(reader);
            return netMsg;
        }
    }
}
