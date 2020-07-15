using System.IO;
using System;
using System.Collections.Generic;
using TrProtocolLib.NetType;

namespace TrProtocolLib.NetMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class Msg70CatchNPC : INetMessage
    {
        public const int ID = 70;

        public Side Side { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public short npcId = default(short);
        /// <summary>
        /// 
        /// </summary>
        public byte playerId = default(byte);



        public void OnSerialize(BinaryWriter writer)
        {
            writer.Write(npcId);
            writer.Write(playerId);
        }

        public void OnDeserialize(BinaryReader reader)
        {
            npcId = reader.ReadInt16();
            playerId = reader.ReadByte();
        }
    }
}

//Json file changed at 2020/6/9 23:15:43