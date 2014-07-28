using System;
using VLCInterface.Enumerations;
using VLCInterface.Bridge.Internal.Structures;

namespace VLCInterface.Bridge.Internal.Delegates
{
    internal delegate void VLCEventDelegate(libvlc_event_t EventStruct, IntPtr UserData);
}
