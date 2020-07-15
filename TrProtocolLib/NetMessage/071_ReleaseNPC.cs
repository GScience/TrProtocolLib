using System.IO;
using System;
using System.Collections.Generic;
using TrProtocol.NetType;

namespace TrProtocol.NetMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class Msg71ReleaseNPC : INetMessage
    {
        public const int ID = 71;

        public Side Side { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int x = default(int);
        /// <summary>
        /// 
        /// </summary>
        public int y = default(int);
        /// <summary>
        /// 
        /// </summary>
        public short npcType = default(short);
        /// <summary>
        /// Sent to NPC AI[2]
        /// </summary>
        public byte style = default(byte);



        public void OnSerialize(BinaryWriter writer)
        {
            writer.Write(x);
            writer.Write(y);
            writer.Write(npcType);
            writer.Write(style);
        }

        public void OnDeserialize(BinaryReader reader)
        {
            x = reader.ReadInt32();
            y = reader.ReadInt32();
            npcType = reader.ReadInt16();
            style = reader.ReadByte();
        }
    }
}

//Json file changed at 2020/6/9 23:16:39