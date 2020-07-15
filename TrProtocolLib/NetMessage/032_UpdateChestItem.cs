using System.IO;
using System;
using System.Collections.Generic;
using TrProtocolLib.NetType;

namespace TrProtocolLib.NetMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class Msg32UpdateChestItem : INetMessage
    {
        public const int ID = 32;

        public Side Side { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public short chestId = default(short);
        /// <summary>
        /// 
        /// </summary>
        public byte itemSlot = default(byte);
        /// <summary>
        /// 
        /// </summary>
        public short stack = default(short);
        /// <summary>
        /// 
        /// </summary>
        public byte prefix = default(byte);
        /// <summary>
        /// 
        /// </summary>
        public short itemNetId = default(short);



        public void OnSerialize(BinaryWriter writer)
        {
            writer.Write(chestId);
            writer.Write(itemSlot);
            writer.Write(stack);
            writer.Write(prefix);
            writer.Write(itemNetId);
        }

        public void OnDeserialize(BinaryReader reader)
        {
            chestId = reader.ReadInt16();
            itemSlot = reader.ReadByte();
            stack = reader.ReadInt16();
            prefix = reader.ReadByte();
            itemNetId = reader.ReadInt16();
        }
    }
}

//Json file changed at 2020/6/9 22:39:47