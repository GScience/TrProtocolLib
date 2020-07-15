using System.IO;
using System;
using System.Collections.Generic;
using TrProtocolLib.NetType;

namespace TrProtocolLib.NetMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class Msg79PlaceObject : INetMessage
    {
        public const int ID = 79;

        public Side Side { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public short x = default(short);
        /// <summary>
        /// 
        /// </summary>
        public short y = default(short);
        /// <summary>
        /// 
        /// </summary>
        public short type = default(short);
        /// <summary>
        /// 
        /// </summary>
        public short style = default(short);
        /// <summary>
        /// 
        /// </summary>
        public sbyte random = default(sbyte);
        /// <summary>
        /// 
        /// </summary>
        public bool direction = default(bool);



        public void OnSerialize(BinaryWriter writer)
        {
            writer.Write(x);
            writer.Write(y);
            writer.Write(type);
            writer.Write(style);
            writer.Write(random);
            writer.Write(direction);
        }

        public void OnDeserialize(BinaryReader reader)
        {
            x = reader.ReadInt16();
            y = reader.ReadInt16();
            type = reader.ReadInt16();
            style = reader.ReadInt16();
            random = reader.ReadSByte();
            direction = reader.ReadBoolean();
        }
    }
}

//Json file changed at 2020/6/9 23:25:18