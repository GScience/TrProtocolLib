using System.IO;
using System;
using System.Collections.Generic;
using TrProtocolLib.NetType;

namespace TrProtocolLib.NetMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class Msg77CreateTemporaryAnimation : INetMessage
    {
        public const int ID = 77;

        public Side Side { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public short animationType = default(short);
        /// <summary>
        /// 
        /// </summary>
        public ushort tileType = default(ushort);
        /// <summary>
        /// 
        /// </summary>
        public short x = default(short);
        /// <summary>
        /// 
        /// </summary>
        public short y = default(short);



        public void OnSerialize(BinaryWriter writer)
        {
            writer.Write(animationType);
            writer.Write(tileType);
            writer.Write(x);
            writer.Write(y);
        }

        public void OnDeserialize(BinaryReader reader)
        {
            animationType = reader.ReadInt16();
            tileType = reader.ReadUInt16();
            x = reader.ReadInt16();
            y = reader.ReadInt16();
        }
    }
}

//Json file changed at 2020/6/9 23:23:02