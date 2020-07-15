using System.IO;
using System;
using System.Collections.Generic;
using TrProtocol.NetType;

namespace TrProtocol.NetMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class Msg73TeleportationPotion : INetMessage
    {
        public const int ID = 73;

        public Side Side { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TeleportationPotionType type = default(TeleportationPotionType);



        public void OnSerialize(BinaryWriter writer)
        {
            writer.Write((byte)type);
        }

        public void OnDeserialize(BinaryReader reader)
        {
            type = (TeleportationPotionType)reader.ReadByte();
        }
    }
}

//Json file changed at 2020/6/9 23:19:12