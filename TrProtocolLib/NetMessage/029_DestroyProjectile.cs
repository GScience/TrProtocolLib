using System.IO;
using System;
using System.Collections.Generic;
using TrProtocol.NetType;

namespace TrProtocol.NetMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class Msg29DestroyProjectile : INetMessage
    {
        public const int ID = 29;

        public Side Side { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public short projectileId = default(short);
        /// <summary>
        /// Player ID
        /// </summary>
        public byte owner = default(byte);



        public void OnSerialize(BinaryWriter writer)
        {
            writer.Write(projectileId);
            writer.Write(owner);
        }

        public void OnDeserialize(BinaryReader reader)
        {
            projectileId = reader.ReadInt16();
            owner = reader.ReadByte();
        }
    }
}

//Json file changed at 2020/6/10 1:48:44