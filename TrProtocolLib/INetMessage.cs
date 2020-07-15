using System.IO;
using System;

namespace TrProtocolLib
{
    public enum Side
    {
        Server, Client
    }
    public interface INetMessage : INetObject
    {
        Side Side { get; set; }
    }
}