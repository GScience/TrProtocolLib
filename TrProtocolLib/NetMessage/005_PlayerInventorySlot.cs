using System.IO;
using System;
using System.Collections.Generic;
using TrProtocol.NetType;

namespace TrProtocol.NetMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class Msg5PlayerInventorySlot : INetMessage
    {
        public const int ID = 5;

        public Side Side { get; set; }

        /// <summary>
        /// Remote player ID
        /// </summary>
        public byte playerId = default(byte);
        /// <summary>
        /// Slot ID
        /// </summary>
        public short slotId = default(short);

        public Item item = new Item();


        public void OnSerialize(BinaryWriter writer)
        {
            writer.Write(playerId);
            writer.Write(slotId);
            item.OnSerialize(writer);
        }

        public void OnDeserialize(BinaryReader reader)
        {
            playerId = reader.ReadByte();
            slotId = reader.ReadInt16();
            item.OnDeserialize(reader);
        }
    }
}

//Json file changed at 2020/6/10 0:52:01