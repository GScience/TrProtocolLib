using System.IO;
using System;
using System.Collections.Generic;
using TrProtocol.NetType;

namespace TrProtocol.NetMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class Msg50UpdatePlayerBuff : INetMessage
    {
        public const int ID = 50;

        public Side Side { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public byte playerId = default(byte);
        /// <summary>
        /// 
        /// </summary>
        public ushort[] buffType = new ushort[22];



        public void OnSerialize(BinaryWriter writer)
        {
            writer.Write(playerId);
            for (var i = 0; i < 22; ++i) writer.Write(buffType[i]);
        }

        public void OnDeserialize(BinaryReader reader)
        {
            playerId = reader.ReadByte();
            for (var i = 0; i < 22; ++i) buffType[i] = reader.ReadUInt16();
        }
    }
}

//Json file changed at 2020/6/9 22:58:36