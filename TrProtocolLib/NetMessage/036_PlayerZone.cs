using System.IO;
using System;
using System.Collections.Generic;
using TrProtocolLib.NetType;

namespace TrProtocolLib.NetMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class Msg36PlayerZone : INetMessage
    {
        public const int ID = 36;

        public Side Side { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public byte playerId = default(byte);
        /// <summary>
        /// 
        /// </summary>
        public byte zoneFlags1 = default(byte);
        /// <summary>
        /// 
        /// </summary>
        public byte zoneFlags2 = default(byte);
        /// <summary>
        /// 
        /// </summary>
        public byte zoneFlags3 = default(byte);
        /// <summary>
        /// 
        /// </summary>
        public byte zoneFlags4 = default(byte);



        public void OnSerialize(BinaryWriter writer)
        {
            writer.Write(playerId);
            writer.Write(zoneFlags1);
            writer.Write(zoneFlags2);
            writer.Write(zoneFlags3);
            writer.Write(zoneFlags4);
        }

        public void OnDeserialize(BinaryReader reader)
        {
            playerId = reader.ReadByte();
            zoneFlags1 = reader.ReadByte();
            zoneFlags2 = reader.ReadByte();
            zoneFlags3 = reader.ReadByte();
            zoneFlags4 = reader.ReadByte();
        }
    }
}

//Json file changed at 2020/6/9 22:47:14