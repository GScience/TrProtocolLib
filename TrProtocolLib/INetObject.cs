using System.IO;
using System;

namespace TrProtocol
{
    public interface INetObject
    {
        void OnSerialize(BinaryWriter writer);
        void OnDeserialize(BinaryReader reader);
    }
}