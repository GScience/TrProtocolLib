using System.IO;
using System;
using System.Collections.Generic;
using TrProtocolLib.NetType;

namespace TrProtocolLib.NetMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class Msg69GetChestName : INetMessage
    {
        public const int ID = 69;

        public Side Side { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public short chestId = default(short);
        /// <summary>
        /// 
        /// </summary>
        public short chestX = default(short);
        /// <summary>
        /// 
        /// </summary>
        public short chestY = default(short);
        /// <summary>
        /// 
        /// </summary>
        public string name = default(string);



        public void OnSerialize(BinaryWriter writer)
        {
            writer.Write(chestId);
            writer.Write(chestX);
            writer.Write(chestY);
            writer.Write(name);
        }

        public void OnDeserialize(BinaryReader reader)
        {
            chestId = reader.ReadInt16();
            chestX = reader.ReadInt16();
            chestY = reader.ReadInt16();
            name = reader.ReadString();
        }
    }
}

//Json file changed at 2020/6/9 23:52:03