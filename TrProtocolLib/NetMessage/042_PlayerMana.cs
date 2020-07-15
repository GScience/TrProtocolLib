using System.IO;
using System;
using System.Collections.Generic;
using TrProtocolLib.NetType;

namespace TrProtocolLib.NetMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class Msg42PlayerMana : INetMessage
    {
        public const int ID = 42;

        public Side Side { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public byte playerId = default(byte);
        /// <summary>
        /// 
        /// </summary>
        public short mana = default(short);
        /// <summary>
        /// 
        /// </summary>
        public short maxMana = default(short);



        public void OnSerialize(BinaryWriter writer)
        {
            writer.Write(playerId);
            writer.Write(mana);
            writer.Write(maxMana);
        }

        public void OnDeserialize(BinaryReader reader)
        {
            playerId = reader.ReadByte();
            mana = reader.ReadInt16();
            maxMana = reader.ReadInt16();
        }
    }
}

//Json file changed at 2020/6/9 22:52:10