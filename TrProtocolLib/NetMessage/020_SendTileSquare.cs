using System.IO;
using System;
using System.Collections.Generic;
using TrProtocolLib.NetType;
using TrProtocolLib.TrObject;

namespace TrProtocolLib.NetMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class Msg20SendTileSquare : INetMessage
    {
        public const int ID = 20;

        public Side Side { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ushort size = default(ushort);
        /// <summary>
        /// 
        /// </summary>
        public byte tileChangeType = default(byte);
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
        public Tile tiles = new Tile();



        public void OnSerialize(BinaryWriter writer)
        {
            writer.Write(size);
            writer.Write(tileChangeType);
            writer.Write(tileX);
            writer.Write(tileY);
            //tiles.OnSerialize(writer);

            throw new NotImplementedException();
        }

        public void OnDeserialize(BinaryReader reader)
        {
            size = reader.ReadUInt16();
            tileChangeType = reader.ReadByte();
            tileX = reader.ReadInt16();
            tileY = reader.ReadInt16();
            //tiles.OnDeserialize(reader);

            throw new NotImplementedException();
        }
    }
}

//Json file changed at 2020/6/9 22:17:29