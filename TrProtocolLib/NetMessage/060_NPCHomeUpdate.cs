using System.IO;
using System;
using System.Collections.Generic;
using TrProtocol.NetType;

namespace TrProtocol.NetMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class Msg60NPCHomeUpdate : INetMessage
    {
        public const int ID = 60;

        public Side Side { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public short npcId = default(short);
        /// <summary>
        /// 
        /// </summary>
        public short homeTileX = default(short);
        /// <summary>
        /// 
        /// </summary>
        public short homeTileY = default(short);
        /// <summary>
        /// 
        /// </summary>
        public byte homeless = default(byte);



        public void OnSerialize(BinaryWriter writer)
        {
            writer.Write(npcId);
            writer.Write(homeTileX);
            writer.Write(homeTileY);
            writer.Write(homeless);
        }

        public void OnDeserialize(BinaryReader reader)
        {
            npcId = reader.ReadInt16();
            homeTileX = reader.ReadInt16();
            homeTileY = reader.ReadInt16();
            homeless = reader.ReadByte();
        }
    }
}

//Json file changed at 2020/6/9 23:05:17