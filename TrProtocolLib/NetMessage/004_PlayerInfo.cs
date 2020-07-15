using System.IO;
using System;
using System.Collections.Generic;
using TrProtocolLib.NetType;

namespace TrProtocolLib.NetMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class Msg4PlayerInfo : INetMessage
    {
        public const int ID = 4;

        public Side Side { get; set; }

        /// <summary>
        /// Remote player ID
        /// </summary>
        public byte playerId = default(byte);
        /// <summary>
        /// Skin Variant
        /// </summary>
        public byte skinVariant = default(byte);
        /// <summary>
        /// Hair
        /// </summary>
        public byte hair = default(byte);
        /// <summary>
        /// Name
        /// </summary>
        public string name = default(string);
        /// <summary>
        /// Hair Dye
        /// </summary>
        public byte hairDye = default(byte);
        /// <summary>
        /// Hide visible accessory part 1
        /// </summary>
        public BitsByte hideVisibleAccessory1 = new BitsByte();
        /// <summary>
        /// Hide visible accessory part 2
        /// </summary>
        public BitsByte hideVisibleAccessory2 = new BitsByte();
        /// <summary>
        /// Hide Misc
        /// </summary>
        public byte hideMisc = default(byte);
        /// <summary>
        /// Hair Color
        /// </summary>
        public Color hairColor = new Color();
        /// <summary>
        /// Skin Color
        /// </summary>
        public Color skinColor = new Color();
        /// <summary>
        /// Eye Color
        /// </summary>
        public Color eyeColor = new Color();
        /// <summary>
        /// Shirt Color
        /// </summary>
        public Color shirtColor = new Color();
        /// <summary>
        /// Under Shirt Color
        /// </summary>
        public Color underShirtColor = new Color();
        /// <summary>
        /// Pants Color
        /// </summary>
        public Color pantsColor = new Color();
        /// <summary>
        /// Shoe Color
        /// </summary>
        public Color shoeColor = new Color();
        /// <summary>
        /// Difficulty
        /// </summary>
        public BitsByte difficulty = new BitsByte();
        /// <summary>
        /// 
        /// </summary>
        public BitsByte torchFlags = new BitsByte();



        public void OnSerialize(BinaryWriter writer)
        {
            writer.Write(playerId);
            writer.Write(skinVariant);
            writer.Write(hair);
            writer.Write(name);
            writer.Write(hairDye);
            hideVisibleAccessory1.OnSerialize(writer);
            hideVisibleAccessory2.OnSerialize(writer);
            writer.Write(hideMisc);
            hairColor.OnSerialize(writer);
            skinColor.OnSerialize(writer);
            eyeColor.OnSerialize(writer);
            shirtColor.OnSerialize(writer);
            underShirtColor.OnSerialize(writer);
            pantsColor.OnSerialize(writer);
            shoeColor.OnSerialize(writer);
            difficulty.OnSerialize(writer);
            torchFlags.OnSerialize(writer);
        }

        public void OnDeserialize(BinaryReader reader)
        {
            playerId = reader.ReadByte();
            skinVariant = reader.ReadByte();
            hair = reader.ReadByte();
            name = reader.ReadString();
            hairDye = reader.ReadByte();
            hideVisibleAccessory1.OnDeserialize(reader);
            hideVisibleAccessory2.OnDeserialize(reader);
            hideMisc = reader.ReadByte();
            hairColor.OnDeserialize(reader);
            skinColor.OnDeserialize(reader);
            eyeColor.OnDeserialize(reader);
            shirtColor.OnDeserialize(reader);
            underShirtColor.OnDeserialize(reader);
            pantsColor.OnDeserialize(reader);
            shoeColor.OnDeserialize(reader);
            difficulty.OnDeserialize(reader);
            torchFlags.OnDeserialize(reader);
        }
    }
}

//Json file changed at 2020/6/10 0:56:34