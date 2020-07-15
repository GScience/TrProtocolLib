using System.IO;
using System;
using System.Collections.Generic;
using TrProtocol.NetType;

namespace TrProtocol.NetMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class Msg39RemoveItemOwner : INetMessage
    {
        public const int ID = 39;

        public Side Side { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public short itemIndex = default(short);



        public void OnSerialize(BinaryWriter writer)
        {
            writer.Write(itemIndex);
        }

        public void OnDeserialize(BinaryReader reader)
        {
            itemIndex = reader.ReadInt16();
        }
    }
}

//Json file changed at 2020/6/9 22:49:29