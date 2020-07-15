using System.IO;
using System;
using System.Collections.Generic;

namespace TrProtocolLib.NetType
{
    /// <summary>
    /// Color
    /// </summary>
    public class Item : INetObject
    {
        /// <summary>
        /// Stack
        /// </summary>
        public short stack = default(short);
        /// <summary>
        /// Prefix
        /// </summary>
        public byte prefix = default(byte);
        /// <summary>
        /// Net ID
        /// </summary>
        public short netId = default(short);

        public bool IsAir
        {
            get
            {
                if (netId > 0)
                    return stack <= 0;
                return true;
            }
        }

        public void OnSerialize(BinaryWriter writer)
        {
            writer.Write(stack);
            writer.Write(prefix);
            writer.Write(netId);
        }

        public void OnDeserialize(BinaryReader reader)
        {
            stack = reader.ReadInt16();
            prefix = reader.ReadByte();
            netId = reader.ReadInt16();
        }
    }
}

//Json file changed at 2020/6/9 16:35:51