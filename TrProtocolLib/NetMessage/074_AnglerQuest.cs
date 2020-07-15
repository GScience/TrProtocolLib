using System.IO;
using System;
using System.Collections.Generic;
using TrProtocol.NetType;

namespace TrProtocol.NetMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class Msg74AnglerQuest : INetMessage
    {
        public const int ID = 74;

        public Side Side { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public byte quest = default(byte);
        /// <summary>
        /// 
        /// </summary>
        public bool completed = default(bool);



        public void OnSerialize(BinaryWriter writer)
        {
            writer.Write(quest);
            writer.Write(completed);
        }

        public void OnDeserialize(BinaryReader reader)
        {
            quest = reader.ReadByte();
            completed = reader.ReadBoolean();
        }
    }
}

//Json file changed at 2020/6/9 23:20:11