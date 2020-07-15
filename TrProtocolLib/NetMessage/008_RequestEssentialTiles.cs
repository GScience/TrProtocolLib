using System.IO;
using System;
using System.Collections.Generic;
using TrProtocolLib.NetType;

namespace TrProtocolLib.NetMessage
{
    /// <summary>
    /// This packet is used once in the connecting phase and does the following:\n1.Sends you the spawn section\n2.Optionally, if spawn coords aren't -1 - sends you the sections of the selected position (which is the player's spawnpoint)\nSynchronises all portals and sections around them
    /// </summary>
    public class Msg8RequestEssentialTiles : INetMessage
    {
        public const int ID = 8;

        public Side Side { get; set; }

        /// <summary>
        /// Player spawn x
        /// </summary>
        public int x = default(int);
        /// <summary>
        /// Player spawn y
        /// </summary>
        public int y = default(int);



        public void OnSerialize(BinaryWriter writer)
        {
            writer.Write(x);
            writer.Write(y);
        }

        public void OnDeserialize(BinaryReader reader)
        {
            x = reader.ReadInt32();
            y = reader.ReadInt32();
        }
    }
}

//Json file changed at 2020/6/9 19:52:36