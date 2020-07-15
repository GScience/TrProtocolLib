using System.IO;
using System;
using System.Collections.Generic;
using TrProtocolLib.NetType;

namespace TrProtocolLib.NetMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class Msg80SyncPlayerChestIndex : INetMessage
    {
        public const int ID = 80;

        public Side Side { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public byte player = default(byte);
        /// <summary>
        /// 
        /// </summary>
        public short chest = default(short);



        public void OnSerialize(BinaryWriter writer)
        {
            writer.Write(player);
            writer.Write(chest);
        }

        public void OnDeserialize(BinaryReader reader)
        {
            player = reader.ReadByte();
            chest = reader.ReadInt16();
        }
    }
}

//Json file changed at 2020/6/9 23:26:44