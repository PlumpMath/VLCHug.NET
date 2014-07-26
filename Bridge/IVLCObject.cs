using System;

namespace VLCInterface.Bridge
{
    internal interface IVLCObject
    {
        IntPtr Handle { get; }
    }
}
