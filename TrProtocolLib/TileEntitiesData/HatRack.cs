using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TrProtocol.NetType;

namespace TrProtocol.TileEntitiesData
{
    public class HatRack : INetObject
    {
        public Item[] items = new Item[2];
        public Item[] dyes = new Item[2];

        public void OnDeserialize(BinaryReader reader)
        {
            BitsByte bitsByte = new BitsByte();
            bitsByte.OnDeserialize(reader);
            for (int index = 0; index < 2; ++index)
            {
                items[index] = new Item();
                Item obj = items[index];
                if (bitsByte[index])
                {
                    obj.netId = reader.ReadInt16();
                    obj.prefix = reader.ReadByte();
                    obj.stack = reader.ReadInt16();
                }
            }
            for (int index = 0; index < 2; ++index)
            {
                dyes[index] = new Item();
                Item dye = dyes[index];
                if (bitsByte[index + 2])
                {
                    dye.netId = reader.ReadInt16();
                    dye.prefix = reader.ReadByte();
                    dye.stack = reader.ReadInt16();
                }
            }
        }

        public void OnSerialize(BinaryWriter writer)
        {
            BitsByte bitsByte = new BitsByte();
            bitsByte[0] = !items[0].IsAir;
            bitsByte[1] = !items[1].IsAir;
            bitsByte[2] = !dyes[0].IsAir;
            bitsByte[3] = !dyes[1].IsAir;
            bitsByte.OnSerialize(writer);
            for (int index = 0; index < 2; ++index)
            {
                Item obj = items[index];
                if (!obj.IsAir)
                {
                    writer.Write(obj.netId);
                    writer.Write(obj.prefix);
                    writer.Write(obj.stack);
                }
            }
            for (int index = 0; index < 2; ++index)
            {
                Item dye = dyes[index];
                if (!dye.IsAir)
                {
                    writer.Write(dye.netId);
                    writer.Write(dye.prefix);
                    writer.Write(dye.stack);
                }
            }
        }
    }
}
