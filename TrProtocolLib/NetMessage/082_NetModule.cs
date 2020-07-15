using System.IO;
using System;
using System.Collections.Generic;
using TrProtocol.NetType;

namespace TrProtocol.NetMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class Msg82NetModule : INetMessage
    {
        public const int ID = 82;

        public Side Side { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public short moduleId = default(short);
        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string,object> moduleValue = new Dictionary<string,object>();

        private void ReadAmbienceModule(BinaryReader reader)
        {
            moduleValue.Clear();
            moduleValue["playerId"] = reader.ReadByte();
            moduleValue["random"] = reader.ReadInt32();
            moduleValue["type"] = reader.ReadByte();
        }
        private void WriteAmbienceModule(BinaryWriter writer)
        {
            writer.Write((byte)moduleValue["playerId"]);
            writer.Write((int)moduleValue["random"]);
            writer.Write((byte)moduleValue["type"]);
        }
        private void ReadBestiaryModule(BinaryReader reader)
        {
            moduleValue.Clear();
            var type = reader.ReadByte();
            moduleValue["type"] = type;
            switch (type)
            {
                case 0:
                    moduleValue["npcId"] = reader.ReadInt16();
                    moduleValue["killCount"] = reader.ReadUInt16();
                    break;
                case 1:
                    moduleValue["wasSeen"] = reader.ReadInt16();
                    break;
                case 2:
                    moduleValue["wasChatWith"] = reader.ReadInt16();
                    break;
            }
        }
        private void WriteBestiaryModule(BinaryWriter writer)
        {
            var type = (byte)moduleValue["type"];
            writer.Write(type);
            switch (type)
            {
                case 0:
                    writer.Write((short)moduleValue["npcId"]);
                    writer.Write((ushort)moduleValue["killCount"]);
                    break;
                case 1:
                    writer.Write((short)moduleValue["wasSeen"]);
                    break;
                case 2:
                    writer.Write((short)moduleValue["wasChatWith"]);
                    break;
            }
        }
        private void ReadCreativePowerPermissionsModule(BinaryReader reader)
        {
            moduleValue.Clear();
            moduleValue["type"] = reader.ReadByte();
            moduleValue["powerId"] = reader.ReadUInt16();
            moduleValue["level"] = reader.ReadByte();
        }
        private void WriteCreativePowerPermissionsModule(BinaryWriter writer)
        {
            writer.Write((byte)moduleValue["type"]);
            writer.Write((ushort)moduleValue["powerId"]);
            writer.Write((byte)moduleValue["level"]);
        }
        private void ReadLiquidModule(BinaryReader reader)
        {
            var count = reader.ReadUInt16();
            var changes = new List<Tuple<int, ushort, ushort>>(); 
            for (var i = 0; i < count; ++i)
            {
                var change = reader.ReadInt32();
                var liquid = reader.ReadUInt16();
                var liquidType = reader.ReadUInt16();
                changes.Add(new Tuple<int, ushort, ushort>(change, liquid, liquidType));
            }
            moduleValue["changes"] = changes;
        }
        private void WriteLiquidModule(BinaryWriter writer)
        {
            var changes = (List<Tuple<int, ushort, ushort>>)moduleValue["changes"];
            writer.Write((ushort)changes.Count);
            foreach (var change in changes)
            {
                writer.Write(change.Item1);
                writer.Write(change.Item2);
                writer.Write(change.Item3);
            }
        }
        private void ReadParticlesModule(BinaryReader reader)
        {
            moduleValue.Clear();
            moduleValue["particleType"] = reader.ReadByte();
            moduleValue["positionInWorldX"] = reader.ReadSingle();
            moduleValue["positionInWorldY"] = reader.ReadSingle();
            moduleValue["movementVectorX"] = reader.ReadSingle();
            moduleValue["movementVectorY"] = reader.ReadSingle();
            moduleValue["packedShaderIndex"] = reader.ReadInt32();
            moduleValue["indexOfPlayerWhoInvokedThis"] = reader.ReadByte();
        }
        private void WriteParticlesModule(BinaryWriter writer)
        {
            writer.Write((byte)moduleValue["particleType"]);
            writer.Write((float)moduleValue["positionInWorldX"]);
            writer.Write((float)moduleValue["positionInWorldY"]);
            writer.Write((float)moduleValue["movementVectorX"]);
            writer.Write((float)moduleValue["movementVectorY"]);
            writer.Write((int)moduleValue["packedShaderIndex"]);
            writer.Write((byte)moduleValue["indexOfPlayerWhoInvokedThis"]);
        }
        private void ReadPingModule(BinaryReader reader)
        {
            moduleValue.Clear();
            moduleValue["positionX"] = reader.ReadSingle();
            moduleValue["positionY"] = reader.ReadSingle();
        }
        private void WritePingModule(BinaryWriter writer)
        {
            writer.Write((float)moduleValue["positionX"]);
            writer.Write((float)moduleValue["positionY"]);
        }
        private void ReadTeleportPylonModule(BinaryReader reader)
        {
            moduleValue.Clear();
            moduleValue["packetType"] = reader.ReadByte();
            moduleValue["positionInTilesX"] = reader.ReadInt16();
            moduleValue["positionInTilesY"] = reader.ReadInt16();
            moduleValue["typeOfPylon"] = reader.ReadByte();
        }
        private void WriteTeleportPylonModule(BinaryWriter writer)
        {
            writer.Write((byte)moduleValue["packetType"]);
            writer.Write((short)moduleValue["positionInTilesX"]);
            writer.Write((short)moduleValue["positionInTilesY"]);
            writer.Write((byte)moduleValue["typeOfPylon"]);
        }
        private void ReadTextModule(BinaryReader reader)
        {
            moduleValue.Clear();
            if (Side == Side.Server)
            {
                moduleValue["authorId"] = reader.ReadByte();
                var text = new NetworkText();
                text.OnDeserialize(reader);
                moduleValue["text"] = text;
                var color = new Color();
                color.OnDeserialize(reader);
                moduleValue["color"] = color;
            }
            else if (Side == Side.Client)
            {
                var cmdId = reader.ReadString();
                moduleValue["cmdId"] = cmdId;
                var text = reader.ReadString();
                moduleValue["text"] = text;
            }
        }
        private void WriteTextModule(BinaryWriter writer)
        {
            if (Side == Side.Server)
            {
                writer.Write((byte)moduleValue["authorId"]);
                ((NetworkText)moduleValue["text"]).OnSerialize(writer);
                ((Color)moduleValue["color"]).OnSerialize(writer);
            }
            else if (Side == Side.Client)
            {
                writer.Write((string)moduleValue["cmdId"]);
                writer.Write((string)moduleValue["text"]);
            }
        }

        public void OnSerialize(BinaryWriter writer)
        {
            writer.Write(moduleId);
            switch (moduleId)
            {
                case 0:
                    WriteLiquidModule(writer);
                    break;
                case 1:
                    WriteTextModule(writer);
                    break;
                case 2:
                    WritePingModule(writer);
                    break;
                case 3:
                    WriteAmbienceModule(writer);
                    break;
                case 4:
                    WriteBestiaryModule(writer);
                    break;
                case 5:
                case 6:
                case 7:
                    throw new NotImplementedException();
                case 8:
                    WriteTeleportPylonModule(writer);
                    break;
                case 9:
                    WriteParticlesModule(writer);
                    break;
                case 10:
                    throw new NotImplementedException();
            }
        }

        public void OnDeserialize(BinaryReader reader)
        {
            moduleId = reader.ReadInt16();
            switch (moduleId)
            {
                case 0:
                    ReadLiquidModule(reader);
                    break;
                case 1:
                    ReadTextModule(reader);
                    break;
                case 2:
                    ReadPingModule(reader);
                    break;
                case 3:
                    ReadAmbienceModule(reader);
                    break;
                case 4:
                    ReadBestiaryModule(reader);
                    break;
                case 5:
                case 6:
                case 7:
                    throw new NotImplementedException();
                case 8:
                    ReadTeleportPylonModule(reader);
                    break;
                case 9:
                    ReadParticlesModule(reader);
                    break;
                case 10:
                    throw new NotImplementedException();
            }
        }
    }
}

//Json file changed at 2020/6/10 16:07:26