using System.IO;
using System;
using System.Collections.Generic;
using TrProtocolLib.NetType;

namespace TrProtocolLib.NetMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class Msg12SpawnPlayer : INetMessage
    {
        public const int ID = 12;

        public Side Side { get; set; }

        /// <summary>
        /// Remote player ID
        /// </summary>
        public byte playerId = default(byte);
        /// <summary>
        /// 
        /// </summary>
        public short spawnX = default(short);
        /// <summary>
        /// 
        /// </summary>
        public short spawnY = default(short);
        /// <summary>
        /// 
        /// </summary>
        public int respawnTimeRemain = default(int);
        /// <summary>
        /// 
        /// </summary>
        public PlayerSpawnContext playerSpawnContext = default(PlayerSpawnContext);



        public void OnSerialize(BinaryWriter writer)
        {
            writer.Write(playerId);
            writer.Write(spawnX);
            writer.Write(spawnY);
            writer.Write(respawnTimeRemain);
            writer.Write((byte)playerSpawnContext);
        }

        public void OnDeserialize(BinaryReader reader)
        {
            playerId = reader.ReadByte();
            spawnX = reader.ReadInt16();
            spawnY = reader.ReadInt16();
            respawnTimeRemain = reader.ReadInt32();
            playerSpawnContext = (PlayerSpawnContext)reader.ReadByte();
        }
    }
}

//Json file changed at 2020/6/9 21:49:12