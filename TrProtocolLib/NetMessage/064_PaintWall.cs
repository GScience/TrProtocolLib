using System.IO;
using System;
using System.Collections.Generic;
using TrProtocolLib.NetType;

namespace TrProtocolLib.NetMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class Msg64PaintWall : INetMessage
    {
        public const int ID = 64;

        public Side Side { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public short x = default(short);
        /// <summary>
        /// 
        /// </summary>
        public short y = default(short);
        /// <summary>
        /// 
        /// </summary>
        public byte color = default(byte);



        public void OnSerialize(BinaryWriter writer)
        {
            writer.Write(x);
            writer.Write(y);
            writer.Write(color);
        }

        public void OnDeserialize(BinaryReader reader)
        {
            x = reader.ReadInt16();
            y = reader.ReadInt16();
            color = reader.ReadByte();
        }
    }
}

//Json file changed at 2020/6/9 23:09:45