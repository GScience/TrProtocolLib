using System.IO;
using System;
using System.Collections.Generic;
using TrProtocol.NetType;

namespace TrProtocol.NetMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class Msg66HealOtherPlayer : INetMessage
    {
        public const int ID = 66;

        public Side Side { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public byte playerId = default(byte);
        /// <summary>
        /// 
        /// </summary>
        public short healAmount = default(short);



        public void OnSerialize(BinaryWriter writer)
        {
            writer.Write(playerId);
            writer.Write(healAmount);
        }

        public void OnDeserialize(BinaryReader reader)
        {
            playerId = reader.ReadByte();
            healAmount = reader.ReadInt16();
        }
    }
}

//Json file changed at 2020/6/9 23:12:10