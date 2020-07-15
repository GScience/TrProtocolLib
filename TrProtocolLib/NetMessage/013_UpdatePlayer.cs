using System.IO;
using System;
using System.Collections.Generic;
using TrProtocol.NetType;

namespace TrProtocol.NetMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class Msg13UpdatePlayer : INetMessage
    {
        public const int ID = 13;

        public Side Side { get; set; }

        /// <summary>
        /// Remote player ID
        /// </summary>
        public byte playerId = default(byte);
        /// <summary>
        /// 
        /// </summary>
        public byte control = default(byte);
        /// <summary>
        /// 
        /// </summary>
        public BitsByte pulley = new BitsByte();
        /// <summary>
        /// 
        /// </summary>
        public BitsByte misc = new BitsByte();
        /// <summary>
        /// 
        /// </summary>
        public byte sleepingInfo = default(byte);
        /// <summary>
        /// 
        /// </summary>
        public byte selectedItem = default(byte);
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
        /// 
        /// </summary>
        public float originalPositionX = default(float);
        /// <summary>
        /// 
        /// </summary>
        public float originalPositionY = default(float);
        /// <summary>
        /// 
        /// </summary>
        public float homePositionX = default(float);
        /// <summary>
        /// 
        /// </summary>
        public float homePositionY = default(float);



        public void OnSerialize(BinaryWriter writer)
        {
            writer.Write(playerId);
            writer.Write(control);
            pulley.OnSerialize(writer);
            misc.OnSerialize(writer);
            writer.Write(sleepingInfo);
            writer.Write(selectedItem);
            writer.Write(positionX);
            writer.Write(positionY);
            
            if (pulley[2])
            {
                writer.Write(velocityX);
                writer.Write(velocityY);
            }
            
            if (misc[6])
            {
                writer.Write(originalPositionX);
                writer.Write(originalPositionY);
                writer.Write(homePositionX);
                writer.Write(homePositionY);
            }
        }

        public void OnDeserialize(BinaryReader reader)
        {
            playerId = reader.ReadByte();
            control = reader.ReadByte();
            pulley.OnDeserialize(reader);
            misc.OnDeserialize(reader);
            sleepingInfo = reader.ReadByte();
            selectedItem = reader.ReadByte();
            positionX = reader.ReadSingle();
            positionY = reader.ReadSingle();
            
            if (pulley[2])
            {
                velocityX = reader.ReadSingle();
                velocityY = reader.ReadSingle();
            }
            
            if (misc[6])
            {
                originalPositionX = reader.ReadSingle();
                originalPositionY = reader.ReadSingle();
                homePositionX = reader.ReadSingle();
                homePositionY = reader.ReadSingle();
            }
        }
    }
}

//Json file changed at 2020/6/10 14:19:55