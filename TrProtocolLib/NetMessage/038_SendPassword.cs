using System.IO;
using System;
using System.Collections.Generic;
using TrProtocol.NetType;

namespace TrProtocol.NetMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class Msg38SendPassword : INetMessage
    {
        public const int ID = 38;

        public Side Side { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string password = default(string);



        public void OnSerialize(BinaryWriter writer)
        {
            writer.Write(password);
        }

        public void OnDeserialize(BinaryReader reader)
        {
            password = reader.ReadString();
        }
    }
}

//Json file changed at 2020/6/9 22:48:54