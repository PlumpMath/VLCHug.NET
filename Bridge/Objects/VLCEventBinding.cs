using System;
using VLCInterface.Enumerations;
using VLCInterface.Bridge.Utils;
using VLCInterface.Bridge.Internal.Enumerations;
using VLCInterface.Bridge.Internal.Delegates;
using VLCInterface.Bridge.Internal.Structures;

namespace VLCInterface.Bridge.Objects
{
    internal class VLCEventBinding : IDisposable
    {
        public libvlc_callback_t EventDelegate
        {
            get;
            private set;
        }

        public Boolean Detached
        {
            get;
            private set;
        }

        public IntPtr? UserData
        {
            get;
            private set;
        }

        public VLCEventType Type
        {
            get;
            private set;
        }

        public event VLCEventDelegate Invoked = delegate { };

        public VLCEventBinding(VLCEventType EventType, IntPtr? UserData = null)
        {
            Type = EventType;

            EventDelegate = new libvlc_callback_t(delegate(IntPtr EventPtr, IntPtr UserDataPtr)
            {
                var Event = Transform.ToStructure<libvlc_event_t>(EventPtr);
                if(Event.type == (libvlc_event_e)Type) Invoked(Event, UserDataPtr);
            });
        }

        internal void NotifyDetached()
        {
            Detached = true;
        }

        public void Dispose()
        {
            if (!Detached)
            {
                throw new InvalidOperationException("Need to detach event before disposal");
            }

            EventDelegate = null;
        }

        ~VLCEventBinding()
        {
            Dispose();
        }
    }
}
