using System;

namespace VLCInterface.Bridge.Interfaces
{
    internal interface IVLCSubscribable
    {
        IntPtr EventManager { get; }
    }
}
