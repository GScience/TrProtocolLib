using System.IO;
using System;
using System.Collections.Generic;

namespace TrProtocolLib.NetType
{
    /// <summary>
    /// Color
    /// </summary>
    public class Color : INetObject
    {
        /// <summary>
        /// Red
        /// </summary>
        public byte r = default(byte);
        /// <summary>
        /// Red
        /// </summary>
        public byte g = default(byte);
        /// <summary>
        /// Red
        /// </summary>
        public byte b = default(byte);



        public void OnSerialize(BinaryWriter writer)
        {
            writer.Write(r);
            writer.Write(g);
            writer.Write(b);
        }

        public void OnDeserialize(BinaryReader reader)
        {
            r = reader.ReadByte();
            g = reader.ReadByte();
            b = reader.ReadByte();
        }

        public Color(byte r = 0, byte g = 0, byte b = 0)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }
    }
}

//Json file changed at 2020/6/9 16:35:51