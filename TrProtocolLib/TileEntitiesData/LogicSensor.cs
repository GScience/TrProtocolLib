using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TrProtocolLib.TileEntitiesData
{
    public class LogicSensor : INetObject
    {
        public bool on;
        public byte logicCheck;

        public void OnDeserialize(BinaryReader reader)
        {
            logicCheck = reader.ReadByte();
            on = reader.ReadBoolean();
        }

        public void OnSerialize(BinaryWriter writer)
        {
            writer.Write(logicCheck);
            writer.Write(on);
        }
    }
}
