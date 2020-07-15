using System.IO;
using System;
using System.Collections.Generic;
using TrProtocolLib.NetType;

namespace TrProtocolLib.NetMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class Msg3SetUserSlot : INetMessage
    {
        public const int ID = 3;

        public Side Side { get; set; }

        /// <summary>
        /// Remote player ID
        /// </summary>
        public byte playerId = default(byte);



        public void OnSerialize(BinaryWriter writer)
        {
            writer.Write(playerId);
        }

        public void OnDeserialize(BinaryReader reader)
        {
            playerId = reader.ReadByte();
        }
    }
}

//Json file changed at 2020/6/9 19:46:21