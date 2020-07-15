using System.IO;
using System;
using System.Collections.Generic;
using TrProtocol.NetType;

namespace TrProtocol.NetMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class Msg75CompleteAnglerQuestToday : INetMessage
    {
        public const int ID = 75;

        public Side Side { get; set; }





        public void OnSerialize(BinaryWriter writer)
        {

        }

        public void OnDeserialize(BinaryReader reader)
        {

        }
    }
}

//Json file changed at 2020/6/9 23:20:27