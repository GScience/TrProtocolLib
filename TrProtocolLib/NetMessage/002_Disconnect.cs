using System.IO;
using System;
using System.Collections.Generic;
using TrProtocolLib.NetType;

namespace TrProtocolLib.NetMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class Msg2Disconnect : INetMessage
    {
        public const int ID = 2;

        public Side Side { get; set; }

        /// <summary>
        /// Kick message
        /// </summary>
        public NetworkText kickMsg = new NetworkText();



        public void OnSerialize(BinaryWriter writer)
        {
            kickMsg.OnSerialize(writer);
        }

        public void OnDeserialize(BinaryReader reader)
        {
            kickMsg.OnDeserialize(reader);
        }
    }
}

//Json file changed at 2020/6/9 19:45:29