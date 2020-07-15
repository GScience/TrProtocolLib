using System.IO;
using System;
using System.Collections.Generic;
using TrProtocol.NetType;

namespace TrProtocol.NetMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class Msg51SpecialNPCEffect : INetMessage
    {
        public const int ID = 51;

        public Side Side { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public byte playerId = default(byte);
        /// <summary>
        /// 
        /// </summary>
        public SpecialNPCEffectType type = default(SpecialNPCEffectType);



        public void OnSerialize(BinaryWriter writer)
        {
            writer.Write(playerId);
            writer.Write((byte)type);
        }

        public void OnDeserialize(BinaryReader reader)
        {
            playerId = reader.ReadByte();
            type = (SpecialNPCEffectType)reader.ReadByte();
        }
    }
}

//Json file changed at 2020/6/9 22:58:40