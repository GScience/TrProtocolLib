using System.IO;
using System;
using System.Collections.Generic;
using TrProtocolLib.NetType;

namespace TrProtocolLib.NetMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class Msg30TogglePVP : INetMessage
    {
        public const int ID = 30;

        public Side Side { get; set; }

        /// <summary>
        /// Player ID
        /// </summary>
        public short owner = default(short);
        /// <summary>
        /// 
        /// </summary>
        public bool pvpEnabled = default(bool);



        public void OnSerialize(BinaryWriter writer)
        {
            writer.Write(owner);
            writer.Write(pvpEnabled);
        }

        public void OnDeserialize(BinaryReader reader)
        {
            owner = reader.ReadInt16();
            pvpEnabled = reader.ReadBoolean();
        }
    }
}

//Json file changed at 2020/6/9 22:37:52