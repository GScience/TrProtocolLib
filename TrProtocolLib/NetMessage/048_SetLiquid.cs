using System.IO;
using System;
using System.Collections.Generic;
using TrProtocol.NetType;

namespace TrProtocol.NetMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class Msg48SetLiquid : INetMessage
    {
        public const int ID = 48;

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
        public byte liquid = default(byte);
        /// <summary>
        /// 
        /// </summary>
        public byte liquidType = default(byte);



        public void OnSerialize(BinaryWriter writer)
        {
            writer.Write(x);
            writer.Write(y);
            writer.Write(liquid);
            writer.Write(liquidType);
        }

        public void OnDeserialize(BinaryReader reader)
        {
            x = reader.ReadInt16();
            y = reader.ReadInt16();
            liquid = reader.ReadByte();
            liquidType = reader.ReadByte();
        }
    }
}

//Json file changed at 2020/6/9 22:55:34