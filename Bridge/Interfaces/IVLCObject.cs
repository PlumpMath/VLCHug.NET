using System;

namespace VLCInterface.Bridge.Interfaces
{
    internal interface IVLCObject
    {
        IntPtr Handle { get; }
    }
}
