using System.IO;
using System;
using System.Collections.Generic;
using TrProtocol.NetType;

namespace TrProtocol.NetMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class Msg55AddPlayerBuff : INetMessage
    {
        public const int ID = 55;

        public Side Side { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public byte playerId = default(byte);
        /// <summary>
        /// 
        /// </summary>
        public ushort buff = default(ushort);
        /// <summary>
        /// 
        /// </summary>
        public int time = default(int);



        public void OnSerialize(BinaryWriter writer)
        {
            writer.Write(playerId);
            writer.Write(buff);
            writer.Write(time);
        }

        public void OnDeserialize(BinaryReader reader)
        {
            playerId = reader.ReadByte();
            buff = reader.ReadUInt16();
            time = reader.ReadInt32();
        }
    }
}

//Json file changed at 2020/6/9 23:02:11