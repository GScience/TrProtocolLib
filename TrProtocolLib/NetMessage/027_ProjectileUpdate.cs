using System.IO;
using System;
using System.Collections.Generic;
using TrProtocolLib.NetType;

namespace TrProtocolLib.NetMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class Msg27ProjectileUpdate : INetMessage
    {
        public const int ID = 27;

        public Side Side { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public short projectileId = default(short);
        /// <summary>
        /// 
        /// </summary>
        public float positionX = default(float);
        /// <summary>
        /// 
        /// </summary>
        public float positionY = default(float);
        /// <summary>
        /// 
        /// </summary>
        public float velocityX = default(float);
        /// <summary>
        /// 
        /// </summary>
        public float velocityY = default(float);
        /// <summary>
        /// Player ID
        /// </summary>
        public byte owner = default(byte);
        /// <summary>
        /// 
        /// </summary>
        public short type = default(short);
        /// <summary>
        /// 
        /// </summary>
        public BitsByte projFlags = new BitsByte();
        /// <summary>
        /// Only sent if AI[0] flag is true
        /// </summary>
        public float AI0 = default(float);
        /// <summary>
        /// Only sent if AI[1] flag is true
        /// </summary>
        public float AI1 = default(float);
        /// <summary>
        /// Only sent if Damage flag is true
        /// </summary>
        public short Damage = default(short);
        /// <summary>
        /// Only sent if Knockback flag is true
        /// </summary>
        public float knockback = default(float);
        /// <summary>
        /// Only sent if OriginalDamage flag is true
        /// </summary>
        public short originalDamage = default(short);
        /// <summary>
        /// Only sent if ProjUUID flag is true
        /// </summary>
        public short projUUID = default(short);



        public void OnSerialize(BinaryWriter writer)
        {
            writer.Write(projectileId);
            writer.Write(positionX);
            writer.Write(positionY);
            writer.Write(velocityX);
            writer.Write(velocityY);
            writer.Write(owner);
            writer.Write(type);
            projFlags.OnSerialize(writer);
            if (projFlags[0])
                writer.Write(AI0);
            if (projFlags[1])
                writer.Write(AI1);
            if (projFlags[4])
                writer.Write(Damage);
            if (projFlags[5])
                writer.Write(knockback);
            if (projFlags[6])
                writer.Write(originalDamage);
            if (projFlags[7])
                writer.Write(projUUID);
        }

        public void OnDeserialize(BinaryReader reader)
        {
            projectileId = reader.ReadInt16();
            positionX = reader.ReadSingle();
            positionY = reader.ReadSingle();
            velocityX = reader.ReadSingle();
            velocityY = reader.ReadSingle();
            owner = reader.ReadByte();
            type = reader.ReadInt16();
            projFlags.OnDeserialize(reader);
            if (projFlags[0])
                AI0 = reader.ReadSingle();
            if (projFlags[1])
                AI1 = reader.ReadSingle();
            if (projFlags[4])
                Damage = reader.ReadInt16();
            if (projFlags[5])
                knockback = reader.ReadSingle();
            if (projFlags[6])
                originalDamage = reader.ReadInt16();
            if (projFlags[7])
                projUUID = reader.ReadInt16();
        }
    }
}

//Json file changed at 2020/6/10 14:45:27