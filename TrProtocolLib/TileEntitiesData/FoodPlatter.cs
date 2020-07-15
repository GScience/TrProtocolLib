using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TrProtocolLib.NetType;

namespace TrProtocolLib.TileEntitiesData
{
    public class FoodPlatter : INetObject
    {
        public Item item;

        public void OnSerialize(BinaryWriter writer)
        {
            writer.Write((short)item.netId);
            writer.Write(item.prefix);
            writer.Write(item.stack);
        }

        public void OnDeserialize(BinaryReader reader)
        {
            item = new Item();
            item.netId = reader.ReadInt16();
            item.prefix = reader.ReadByte();
            item.stack = reader.ReadInt16();
        }
    }
}
