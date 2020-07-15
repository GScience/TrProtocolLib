using System.IO;
using System;
using System.Collections.Generic;
using TrProtocolLib.NetType;

namespace TrProtocolLib.NetMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class Msg34PlaceChest : INetMessage
    {
        public const int ID = 34;

        public Side Side { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public PlaceChestAction action = default(PlaceChestAction);
        /// <summary>
        /// 
        /// </summary>
        public short tileX = default(short);
        /// <summary>
        /// 
        /// </summary>
        public short tileY = default(short);
        /// <summary>
        /// 
        /// </summary>
        public short style = default(short);
        /// <summary>
        /// 
        /// </summary>
        public short chestIdToDestroy = default(short);



        public void OnSerialize(BinaryWriter writer)
        {
            writer.Write((byte)action);
            writer.Write(tileX);
            writer.Write(tileY);
            writer.Write(style);
            writer.Write(chestIdToDestroy);
        }

        public void OnDeserialize(BinaryReader reader)
        {
            action = (PlaceChestAction)reader.ReadByte();
            tileX = reader.ReadInt16();
            tileY = reader.ReadInt16();
            style = reader.ReadInt16();
            chestIdToDestroy = reader.ReadInt16();
        }
    }
}

//Json file changed at 2020/6/9 22:45:46