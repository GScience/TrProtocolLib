using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TrProtocol.TileEntitiesData
{
    public class TrainingDummy : INetObject
    {
        public short npc;

        public void OnDeserialize(BinaryReader reader)
        {
            npc = reader.ReadInt16();
        }

        public void OnSerialize(BinaryWriter writer)
        {
            writer.Write(npc);
        }
    }
}
