using System.IO;
using System;
using System.Collections.Generic;
using TrProtocolLib.NetType;

namespace TrProtocolLib.NetMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class Msg72TravellingMerchantInventory : INetMessage
    {
        public const int ID = 72;

        public Side Side { get; set; }

        /// <summary>
        /// Each short related to an item type NetID.
        /// </summary>
        public short[] items = new short[40];



        public void OnSerialize(BinaryWriter writer)
        {
            for (var i = 0; i < 40; ++i) writer.Write(items[i]);
        }

        public void OnDeserialize(BinaryReader reader)
        {
            for (var i = 0; i < 40; ++i) items[i] = reader.ReadInt16();
        }
    }
}

//Json file changed at 2020/6/9 23:19:02