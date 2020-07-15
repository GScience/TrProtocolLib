using System.IO;
using System;
using System.Collections.Generic;
using TrProtocolLib.NetType;

namespace TrProtocolLib.NetMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class Msg28NPCStrike : INetMessage
    {
        public const int ID = 28;

        public Side Side { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public short npcId = default(short);
        /// <summary>
        /// -1 = Kill
        /// </summary>
        public short damage = default(short);
        /// <summary>
        /// 
        /// </summary>
        public float knockback = default(float);
        /// <summary>
        /// 
        /// </summary>
        public byte hitDirection = default(byte);
        /// <summary>
        /// 
        /// </summary>
        public bool cirt = default(bool);



        public void OnSerialize(BinaryWriter writer)
        {
            writer.Write(npcId);
            writer.Write(damage);
            writer.Write(knockback);
            writer.Write(hitDirection);
            writer.Write(cirt);
        }

        public void OnDeserialize(BinaryReader reader)
        {
            npcId = reader.ReadInt16();
            damage = reader.ReadInt16();
            knockback = reader.ReadSingle();
            hitDirection = reader.ReadByte();
            cirt = reader.ReadBoolean();
        }
    }
}

//Json file changed at 2020/6/9 22:38:04