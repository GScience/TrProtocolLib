using System.IO;
using System;
using System.Collections.Generic;
using TrProtocol.NetType;

namespace TrProtocol.NetMessage
{
    /// <summary>
    /// This packet is used to tell the server that you've exited the chest view (sending ID -1), that you're looking at your piggy bank (sending ID -2), that you're looking at your safe (sending ID -3) and that you're looking at your defender's forge (sending ID -4). Those are sent at every chest interaction. Packet [33]'s main function is to synchronize the sending client's active chest to the server, and its side function is to rename the chest.\nIt should be noted that this packet is not sent when you open a regular chest. The server knows which chest you opened when you send [31], so the [33] is only sent upon exit to unblock the chest (as opposed to both open & exit for banks like piggy, safe & defender forge)
    /// </summary>
    public class Msg33SyncActiveChest : INetMessage
    {
        public const int ID = 33;

        public Side Side { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public short chestId = default(short);
        /// <summary>
        /// 
        /// </summary>
        public short chestX = default(short);
        /// <summary>
        /// 
        /// </summary>
        public short chestY = default(short);
        /// <summary>
        /// 
        /// </summary>
        public byte nameLength = default(byte);
        /// <summary>
        /// 
        /// </summary>
        public string chestName = default(string);



        public void OnSerialize(BinaryWriter writer)
        {
            writer.Write(chestId);
            writer.Write(chestX);
            writer.Write(chestY);
            writer.Write(nameLength);
            writer.Write(chestName);
        }

        public void OnDeserialize(BinaryReader reader)
        {
            chestId = reader.ReadInt16();
            chestX = reader.ReadInt16();
            chestY = reader.ReadInt16();
            nameLength = reader.ReadByte();
            chestName = reader.ReadString();
        }
    }
}

//Json file changed at 2020/6/9 22:48:45