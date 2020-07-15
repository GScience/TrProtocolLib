using System.IO;
using System;
using System.Collections.Generic;
using TrProtocolLib.NetType;

namespace TrProtocolLib.NetMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class Msg23NPCUpdate : INetMessage
    {
        public const int ID = 23;

        public Side Side { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public short npcId = default(short);
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
        public ushort target = default(ushort);
        /// <summary>
        /// 
        /// </summary>
        public BitsByte npcFlags1 = new BitsByte();
        /// <summary>
        /// 
        /// </summary>
        public BitsByte npcFlags2 = new BitsByte();
        /// <summary>
        /// 
        /// </summary>
        public float[] ai = new float[4];
        /// <summary>
        /// 
        /// </summary>
        public short npcNetID = default(short);
        /// <summary>
        /// 
        /// </summary>
        public byte playerCountForMultiplayerDifficultyOverride = default(byte);
        /// <summary>
        /// 
        /// </summary>
        public float strengthMultiplier = default(float);
        /// <summary>
        /// 
        /// </summary>
        public byte lifeBytes = default(byte);
        /// <summary>
        /// 
        /// </summary>
        public int life = default(int);
        /// <summary>
        /// 
        /// </summary>
        public byte releaseOwner = default(byte);
        /// <summary>
        /// 
        /// </summary>
        public bool catchable = default(bool);



        public void OnSerialize(BinaryWriter writer)
        {
            writer.Write(npcId);
            writer.Write(positionX);
            writer.Write(positionY);
            writer.Write(velocityX);
            writer.Write(velocityY);
            writer.Write(target);
            npcFlags1.OnSerialize(writer);
            npcFlags2.OnSerialize(writer);
            for (var i = 0; i < 4; ++i)
                if (npcFlags1[i + 2])
                    writer.Write(ai[i]);
            writer.Write(npcNetID);
            if (npcFlags2[0])
                writer.Write(playerCountForMultiplayerDifficultyOverride);
            if (npcFlags2[2])
                writer.Write(strengthMultiplier);
            if (!npcFlags1[7])
            {
                writer.Write(lifeBytes);
                switch (lifeBytes)
                {
                    case 2:
                        writer.Write((short)life);
                        break;
                    case 4:
                        writer.Write(life);
                        break;
                    default:
                        writer.Write((sbyte)life);
                        break;
                }
            }
            if (catchable)
                writer.Write(releaseOwner);
        }

        public void OnDeserialize(BinaryReader reader)
        {
            npcId = reader.ReadInt16();
            positionX = reader.ReadSingle();
            positionY = reader.ReadSingle();
            velocityX = reader.ReadSingle();
            velocityY = reader.ReadSingle();
            target = reader.ReadUInt16();
            npcFlags1.OnDeserialize(reader);
            npcFlags2.OnDeserialize(reader);
            for (var i = 0; i < 4; ++i)
                if (npcFlags1[i + 2])
                    ai[i] = reader.ReadSingle();
            npcNetID = reader.ReadInt16();
            if (npcFlags2[0])
                playerCountForMultiplayerDifficultyOverride = reader.ReadByte();
            if (npcFlags2[2])
                strengthMultiplier = reader.ReadSingle();
            if (!npcFlags1[7])
            {
                lifeBytes = reader.ReadByte();
                switch (lifeBytes)
                {
                    case 2:
                        life = reader.ReadInt16();
                        break;
                    case 4:
                        life = reader.ReadInt32();
                        break;
                    default:
                        life = reader.ReadSByte();
                        break;
                }
            }
            try
            {
                releaseOwner = reader.ReadByte();
                catchable = true;
            }
            catch (EndOfStreamException)
            {
                catchable = false;
            }
        }
    }
}

//Json file changed at 2020/6/10 14:35:10