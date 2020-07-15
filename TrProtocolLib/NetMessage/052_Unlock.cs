using System.IO;
using System;
using System.Collections.Generic;
using TrProtocolLib.NetType;

namespace TrProtocolLib.NetMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class Msg52Unlock : INetMessage
    {
        public const int ID = 52;

        public Side Side { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public UnlockType type = default(UnlockType);
        /// <summary>
        /// 
        /// </summary>
        public short x = default(short);
        /// <summary>
        /// 
        /// </summary>
        public short y = default(short);



        public void OnSerialize(BinaryWriter writer)
        {
            writer.Write((byte)type);
            writer.Write(x);
            writer.Write(y);
        }

        public void OnDeserialize(BinaryReader reader)
        {
            type = (UnlockType)reader.ReadByte();
            x = reader.ReadInt16();
            y = reader.ReadInt16();
        }
    }
}

//Json file changed at 2020/6/9 22:59:35