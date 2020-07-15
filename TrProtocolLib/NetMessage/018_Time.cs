using System.IO;
using System;
using System.Collections.Generic;
using TrProtocolLib.NetType;

namespace TrProtocolLib.NetMessage
{
    /// <summary>
    /// 
    /// </summary>
    public class Msg18Time : INetMessage
    {
        public const int ID = 18;

        public Side Side { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool dayTime = default(bool);
        /// <summary>
        /// 
        /// </summary>
        public int timeValue = default(int);
        /// <summary>
        /// 
        /// </summary>
        public short sunModY = default(short);
        /// <summary>
        /// 
        /// </summary>
        public short moonModY = default(short);



        public void OnSerialize(BinaryWriter writer)
        {
            writer.Write(dayTime);
            writer.Write(timeValue);
            writer.Write(sunModY);
            writer.Write(moonModY);
        }

        public void OnDeserialize(BinaryReader reader)
        {
            dayTime = reader.ReadBoolean();
            timeValue = reader.ReadInt32();
            sunModY = reader.ReadInt16();
            moonModY = reader.ReadInt16();
        }
    }
}

//Json file changed at 2020/6/9 22:11:40