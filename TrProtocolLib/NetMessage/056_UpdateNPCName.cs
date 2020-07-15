using System.IO;
using System;
using System.Collections.Generic;
using TrProtocol.NetType;

namespace TrProtocol.NetMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class Msg56UpdateNPCName : INetMessage
    {
        public const int ID = 56;

        public Side Side { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public short npcId = default(short);
        /// <summary>
        /// 
        /// </summary>
        public string name = default(string);
        /// <summary>
        /// 
        /// </summary>
        public int townNpcVariationIndex = default(int);



        public void OnSerialize(BinaryWriter writer)
        {
            writer.Write(npcId);
            if (Side == Side.Client)
            {
            }
            else if (Side == Side.Server)
            {
                writer.Write(name);
                writer.Write(townNpcVariationIndex);
            }
            else
            {
                throw new Exception("Unknown side");
            }
        }

        public void OnDeserialize(BinaryReader reader)
        {
            npcId = reader.ReadInt16();
            if (Side == Side.Client)
            {
            }
            else if (Side == Side.Server)
            {
                name = reader.ReadString();
                townNpcVariationIndex = reader.ReadInt32();
            }
            else
            {
                throw new Exception("Unknown side");
            }
        }
    }
}

//Json file changed at 2020/6/10 13:24:17