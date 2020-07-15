using System.IO;
using System;
using System.Collections.Generic;

namespace TrProtocolLib.NetType
{
    /// <summary>
    /// 
    /// </summary>
    public class NetworkText : INetObject
    {
        /// <summary>
        /// 
        /// </summary>
        public NetworkTextMode mode = default(NetworkTextMode);
        /// <summary>
        /// 
        /// </summary>
        public string text = default(string);
        /// <summary>
        /// 
        /// </summary>
        public NetworkText[] substitution = new NetworkText[0];



        public void OnSerialize(BinaryWriter writer)
        {
            writer.Write((byte)mode);
            writer.Write(text);
            if (mode == NetworkTextMode.Literal)
                return;
            writer.Write((byte)substitution.Length);
            for (int index = 0; index < (substitution.Length & byte.MaxValue); ++index)
                substitution[index].OnSerialize(writer);
        }

        public void OnDeserialize(BinaryReader reader)
        {
            mode = (NetworkTextMode)reader.ReadByte();
            text = reader.ReadString();
            if (mode == NetworkTextMode.Literal)
                return;
            substitution = new NetworkText[reader.ReadByte()];
            for (int index = 0; index < substitution.Length; ++index)
            {
                substitution[index] = new NetworkText();
                substitution[index].OnDeserialize(reader);
            }
        }
    }
}

//Json file changed at 2020/6/10 1:15:19