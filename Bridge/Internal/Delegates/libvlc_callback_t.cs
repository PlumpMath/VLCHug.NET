using System;
using System.Runtime.InteropServices;
using VLCInterface.Bridge.Internal.Structures;

namespace VLCInterface.Bridge.Internal.Delegates
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void libvlc_callback_t(IntPtr Event, IntPtr UserData);
}
