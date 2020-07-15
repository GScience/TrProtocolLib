using System.IO;
using System;
using System.Collections.Generic;
using TrProtocol.NetType;

namespace TrProtocol.NetMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class Msg31OpenChest : INetMessage
    {
        public const int ID = 31;

        public Side Side { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public short tileX = default(short);
        /// <summary>
        /// 
        /// </summary>
        public short tileY = default(short);



        public void OnSerialize(BinaryWriter writer)
        {
            writer.Write(tileX);
            writer.Write(tileY);
        }

        public void OnDeserialize(BinaryReader reader)
        {
            tileX = reader.ReadInt16();
            tileY = reader.ReadInt16();
        }
    }
}

//Json file changed at 2020/6/9 22:38:43