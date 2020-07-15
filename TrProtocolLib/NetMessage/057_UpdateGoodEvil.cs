using System.IO;
using System;
using System.Collections.Generic;
using TrProtocolLib.NetType;

namespace TrProtocolLib.NetMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class Msg57UpdateGoodEvil : INetMessage
    {
        public const int ID = 57;

        public Side Side { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public byte good = default(byte);
        /// <summary>
        /// 
        /// </summary>
        public byte evil = default(byte);
        /// <summary>
        /// 
        /// </summary>
        public byte crimson = default(byte);



        public void OnSerialize(BinaryWriter writer)
        {
            writer.Write(good);
            writer.Write(evil);
            writer.Write(crimson);
        }

        public void OnDeserialize(BinaryReader reader)
        {
            good = reader.ReadByte();
            evil = reader.ReadByte();
            crimson = reader.ReadByte();
        }
    }
}

//Json file changed at 2020/6/9 23:03:50