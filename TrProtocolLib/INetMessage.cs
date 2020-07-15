using System.IO;
using System;

namespace TrProtocol
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