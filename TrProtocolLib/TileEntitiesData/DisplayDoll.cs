using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TrProtocol.NetType;

namespace TrProtocol.TileEntitiesData
{
    public class DisplayDoll : INetObject
    {
        public Item[] items = new Item[8];
        private Item[] dyes = new Item[8];

        public void OnDeserialize(BinaryReader reader)
        {
            BitsByte bitsByte1 = new BitsByte();
            BitsByte bitsByte2 = new BitsByte();
            bitsByte1.OnDeserialize(reader);
            bitsByte2.OnDeserialize(reader);

            for (int index = 0; index < 8; ++index)
            {
                items[index] = new Item();
                Item obj = items[index];
                if (bitsByte1[index])
                {
                    obj.netId = reader.ReadInt16();
                    obj.prefix = reader.ReadByte();
                    obj.stack = reader.ReadInt16();
                }
            }
            for (int index = 0; index < 8; ++index)
            {
                dyes[index] = new Item();
                Item dye = dyes[index];
                if (bitsByte2[index])
                {
                    dye.netId = reader.ReadInt16();
                    dye.prefix = reader.ReadByte();
                    dye.stack = reader.ReadInt16();
                }
            }
        }

        public void OnSerialize(BinaryWriter writer)
        {
            BitsByte bitsByte1 = new BitsByte();
            bitsByte1[0] = !items[0].IsAir;
            bitsByte1[1] = !items[1].IsAir;
            bitsByte1[2] = !items[2].IsAir;
            bitsByte1[3] = !items[3].IsAir;
            bitsByte1[4] = !items[4].IsAir;
            bitsByte1[5] = !items[5].IsAir;
            bitsByte1[6] = !items[6].IsAir;
            bitsByte1[7] = !items[7].IsAir;
            BitsByte bitsByte2 = new BitsByte();
            bitsByte2[0] = !dyes[0].IsAir;
            bitsByte2[1] = !dyes[1].IsAir;
            bitsByte2[2] = !dyes[2].IsAir;
            bitsByte2[3] = !dyes[3].IsAir;
            bitsByte2[4] = !dyes[4].IsAir;
            bitsByte2[5] = !dyes[5].IsAir;
            bitsByte2[6] = !dyes[6].IsAir;
            bitsByte2[7] = !dyes[7].IsAir;
            bitsByte1.OnSerialize(writer);
            bitsByte2.OnSerialize(writer);
            for (int index = 0; index < 8; ++index)
            {
                Item obj = items[index];
                if (!obj.IsAir)
                {
                    writer.Write(obj.netId);
                    writer.Write(obj.prefix);
                    writer.Write(obj.stack);
                }
            }
            for (int index = 0; index < 8; ++index)
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
