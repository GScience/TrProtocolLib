using System.IO;
using System;
using System.Collections.Generic;
using TrProtocol.NetType;

namespace TrProtocol.NetMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class Msg21UpdateItemDrop : INetMessage
    {
        public const int ID = 21;

        public Side Side { get; set; }

        /// <summary>
        /// If below 400 and NetID 0 Then Set NullIf ItemID is 400 Then New Item
        /// </summary>
        public short itemId = default(short);
        /// <summary>
        /// 
        /// </summary>
        public float positionX = default(float);
        /// <summary>
        /// 
        /// </summary>
        public float positionY = default(float);
        /// <summary>
        /// 
        /// </summary>
        public float velocityX = default(float);
        /// <summary>
        /// 
        /// </summary>
        public float velocityY = default(float);
        /// <summary>
        /// 
        /// </summary>
        public short stackSize = default(short);
        /// <summary>
        /// 
        /// </summary>
        public byte prefix = default(byte);
        /// <summary>
        /// If 0 then ownIgnore = 0 and ownTime = 100
        /// </summary>
        public byte noDelay = default(byte);
        /// <summary>
        /// 
        /// </summary>
        public short itemNetId = default(short);



        public void OnSerialize(BinaryWriter writer)
        {
            writer.Write(itemId);
            writer.Write(positionX);
            writer.Write(positionY);
            writer.Write(velocityX);
            writer.Write(velocityY);
            writer.Write(stackSize);
            writer.Write(prefix);
            writer.Write(noDelay);
            writer.Write(itemNetId);
        }

        public void OnDeserialize(BinaryReader reader)
        {
            itemId = reader.ReadInt16();
            positionX = reader.ReadSingle();
            positionY = reader.ReadSingle();
            velocityX = reader.ReadSingle();
            velocityY = reader.ReadSingle();
            stackSize = reader.ReadInt16();
            prefix = reader.ReadByte();
            noDelay = reader.ReadByte();
            itemNetId = reader.ReadInt16();
        }
    }
}

//Json file changed at 2020/6/9 22:20:46