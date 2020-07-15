using System.IO;
using System;
using System.Collections.Generic;
using TrProtocolLib.NetType;

namespace TrProtocolLib.NetMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class Msg11SectionTileFrame : INetMessage
    {
        public const int ID = 11;

        public Side Side { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public short startX = default(short);
        /// <summary>
        /// 
        /// </summary>
        public short startY = default(short);
        /// <summary>
        /// 
        /// </summary>
        public short endX = default(short);
        /// <summary>
        /// 
        /// </summary>
        public short endY = default(short);



        public void OnSerialize(BinaryWriter writer)
        {
            writer.Write(startX);
            writer.Write(startY);
            writer.Write(endX);
            writer.Write(endY);
        }

        public void OnDeserialize(BinaryReader reader)
        {
            startX = reader.ReadInt16();
            startY = reader.ReadInt16();
            endX = reader.ReadInt16();
            endY = reader.ReadInt16();
        }
    }
}

//Json file changed at 2020/6/9 21:05:16