using System.IO;
using System;
using System.Collections.Generic;
using TrProtocolLib.NetType;

namespace TrProtocolLib.NetMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class Msg17ModifyTile : INetMessage
    {
        public const int ID = 17;

        public Side Side { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ModifyTileAction action = default(ModifyTileAction);
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
        public short flags1 = default(short);
        /// <summary>
        /// 
        /// </summary>
        public byte flags2 = default(byte);



        public void OnSerialize(BinaryWriter writer)
        {
            writer.Write((byte)action);
            writer.Write(tileX);
            writer.Write(tileY);
            writer.Write(flags1);
            writer.Write(flags2);
        }

        public void OnDeserialize(BinaryReader reader)
        {
            action = (ModifyTileAction)reader.ReadByte();
            tileX = reader.ReadInt16();
            tileY = reader.ReadInt16();
            flags1 = reader.ReadInt16();
            flags2 = reader.ReadByte();
        }
    }
}

//Json file changed at 2020/6/9 22:10:30