using System.IO;
using System;
using System.Collections.Generic;
using TrProtocol.NetType;

namespace TrProtocol.NetMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class Msg16PlayerHP : INetMessage
    {
        public const int ID = 16;

        public Side Side { get; set; }

        /// <summary>
        /// Remote player ID
        /// </summary>
        public byte playerId = default(byte);
        /// <summary>
        /// 
        /// </summary>
        public short hp = default(short);
        /// <summary>
        /// 
        /// </summary>
        public short maxHp = default(short);



        public void OnSerialize(BinaryWriter writer)
        {
            writer.Write(playerId);
            writer.Write(hp);
            writer.Write(maxHp);
        }

        public void OnDeserialize(BinaryReader reader)
        {
            playerId = reader.ReadByte();
            hp = reader.ReadInt16();
            maxHp = reader.ReadInt16();
        }
    }
}

//Json file changed at 2020/6/9 21:17:55