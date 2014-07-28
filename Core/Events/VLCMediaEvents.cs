using System;
using VLCInterface.Enumerations;

namespace VLCInterface.Core.Events
{
    internal class VLCMediaEvents
    {
        public delegate void OnMetaChanged(VLCMetaData NewMeta);
        public delegate void OnSubItemAdded(IntPtr NewChild);
        public delegate void OnDurationChanged(Int64 NewDuration);
        public delegate void OnParsedChanged(Int32 NewStatus);
        public delegate void OnFreed(IntPtr MediaInstance);
        public delegate void OnStateChanged(VLCMediaState NewState);
        public delegate void OnSubItemTreeAdded(IntPtr Item);
    }
}
