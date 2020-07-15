using System.IO;
using System;

namespace TrProtocolLib
{
    public interface INetObject
    {
        void OnSerialize(BinaryWriter writer);
        void OnDeserialize(BinaryReader reader);
    }
}