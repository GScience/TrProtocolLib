using System.IO;
using System;
using System.Collections.Generic;
using TrProtocol.NetType;

namespace TrProtocol.NetMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class Msg47UpdateSign : INetMessage
    {
        public const int ID = 47;

        public Side Side { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public short signId = default(short);
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
        public string text = default(string);
        /// <summary>
        /// 
        /// </summary>
        public byte playerId = default(byte);
        /// <summary>
        /// 
        /// </summary>
        public byte signFlags = default(byte);



        public void OnSerialize(BinaryWriter writer)
        {
            writer.Write(signId);
            writer.Write(x);
            writer.Write(y);
            writer.Write(text);
            writer.Write(playerId);
            writer.Write(signFlags);
        }

        public void OnDeserialize(BinaryReader reader)
        {
            signId = reader.ReadInt16();
            x = reader.ReadInt16();
            y = reader.ReadInt16();
            text = reader.ReadString();
            playerId = reader.ReadByte();
            signFlags = reader.ReadByte();
        }
    }
}

//Json file changed at 2020/6/9 22:54:54