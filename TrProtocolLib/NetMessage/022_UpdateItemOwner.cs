using System.IO;
using System;
using System.Collections.Generic;
using TrProtocolLib.NetType;

namespace TrProtocolLib.NetMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class Msg22UpdateItemOwner : INetMessage
    {
        public const int ID = 22;

        public Side Side { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public short itemId = default(short);
        /// <summary>
        /// Remote player ID
        /// </summary>
        public byte playerId = default(byte);



        public void OnSerialize(BinaryWriter writer)
        {
            writer.Write(itemId);
            writer.Write(playerId);
        }

        public void OnDeserialize(BinaryReader reader)
        {
            itemId = reader.ReadInt16();
            playerId = reader.ReadByte();
        }
    }
}

//Json file changed at 2020/6/9 22:22:05