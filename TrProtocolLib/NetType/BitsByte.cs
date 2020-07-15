using System.IO;
using System;
using System.Collections.Generic;

namespace TrProtocol.NetType
{
    /// <summary>
    /// 
    /// </summary>
    public class BitsByte : INetObject
    {
        /// <summary>
        /// Data
        /// </summary>
        public byte data = default(byte);

        public bool this[int key]
        {
            get
            {
                return ((uint)data & (uint)(1 << key)) > 0U;
            }
            set
            {
                if (value)
                    data |= (byte)(1 << key);
                else
                    data &= (byte)~(1 << key);
            }
        }

        public void OnSerialize(BinaryWriter writer)
        {
            writer.Write(data);
        }

        public void OnDeserialize(BinaryReader reader)
        {
            data = reader.ReadByte();
        }
    }
}

//Json file changed at 2020/6/10 14:01:42