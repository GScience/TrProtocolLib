using System.IO;
using System;
using System.Collections.Generic;
using TrProtocol.NetType;

namespace TrProtocol.NetMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class Msg58PlayMusicItem : INetMessage
    {
        public const int ID = 58;

        public Side Side { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public byte playerId = default(byte);
        /// <summary>
        /// 
        /// </summary>
        public float note = default(float);



        public void OnSerialize(BinaryWriter writer)
        {
            writer.Write(playerId);
            writer.Write(note);
        }

        public void OnDeserialize(BinaryReader reader)
        {
            playerId = reader.ReadByte();
            note = reader.ReadSingle();
        }
    }
}

//Json file changed at 2020/6/9 23:04:11