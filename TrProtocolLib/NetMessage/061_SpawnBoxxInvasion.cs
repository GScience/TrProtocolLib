using System.IO;
using System;
using System.Collections.Generic;
using TrProtocol.NetType;

namespace TrProtocol.NetMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class Msg61SpawnBoxxInvasion : INetMessage
    {
        public const int ID = 61;

        public Side Side { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public short playerId = default(short);
        /// <summary>
        /// 
        /// </summary>
        public SpawnBossInvasionType type = default(SpawnBossInvasionType);



        public void OnSerialize(BinaryWriter writer)
        {
            writer.Write(playerId);
            writer.Write((short)type);
        }

        public void OnDeserialize(BinaryReader reader)
        {
            playerId = reader.ReadInt16();
            type = (SpawnBossInvasionType)reader.ReadInt16();
        }
    }
}

//Json file changed at 2020/6/9 23:08:46