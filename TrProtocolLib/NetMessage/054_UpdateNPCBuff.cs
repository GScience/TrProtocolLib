using System.IO;
using System;
using System.Collections.Generic;
using TrProtocolLib.NetType;

namespace TrProtocolLib.NetMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class Msg54UpdateNPCBuff : INetMessage
    {
        public const int ID = 54;

        public Side Side { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public short npcId = default(short);
        /// <summary>
        /// 
        /// </summary>
        public ushort buffId1 = default(ushort);
        /// <summary>
        /// 
        /// </summary>
        public short time1 = default(short);
        /// <summary>
        /// 
        /// </summary>
        public ushort buffId2 = default(ushort);
        /// <summary>
        /// 
        /// </summary>
        public short time2 = default(short);
        /// <summary>
        /// 
        /// </summary>
        public ushort buffId3 = default(ushort);
        /// <summary>
        /// 
        /// </summary>
        public short time3 = default(short);
        /// <summary>
        /// 
        /// </summary>
        public ushort buffId4 = default(ushort);
        /// <summary>
        /// 
        /// </summary>
        public short time4 = default(short);
        /// <summary>
        /// 
        /// </summary>
        public ushort buffId5 = default(ushort);
        /// <summary>
        /// 
        /// </summary>
        public short time5 = default(short);



        public void OnSerialize(BinaryWriter writer)
        {
            writer.Write(npcId);
            writer.Write(buffId1);
            writer.Write(time1);
            writer.Write(buffId2);
            writer.Write(time2);
            writer.Write(buffId3);
            writer.Write(time3);
            writer.Write(buffId4);
            writer.Write(time4);
            writer.Write(buffId5);
            writer.Write(time5);
        }

        public void OnDeserialize(BinaryReader reader)
        {
            npcId = reader.ReadInt16();
            buffId1 = reader.ReadUInt16();
            time1 = reader.ReadInt16();
            buffId2 = reader.ReadUInt16();
            time2 = reader.ReadInt16();
            buffId3 = reader.ReadUInt16();
            time3 = reader.ReadInt16();
            buffId4 = reader.ReadUInt16();
            time4 = reader.ReadInt16();
            buffId5 = reader.ReadUInt16();
            time5 = reader.ReadInt16();
        }
    }
}

//Json file changed at 2020/6/9 23:01:40