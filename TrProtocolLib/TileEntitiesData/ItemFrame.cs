using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TrProtocolLib.NetType;

namespace TrProtocolLib.TileEntitiesData
{
    public class ItemFrame : INetObject
    {
        public Item item;

        public void OnDeserialize(BinaryReader reader)
        {
            item = new Item();
            item.netId = reader.ReadInt16();
            item.prefix = reader.ReadByte();
            item.stack = reader.ReadInt16();
        }

        public void OnSerialize(BinaryWriter writer)
        {
            writer.Write(item.netId);
            writer.Write(item.prefix);
            writer.Write(item.stack);
        }
    }
}
