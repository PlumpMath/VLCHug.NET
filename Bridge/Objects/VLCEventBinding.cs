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
        /// <summary>
        /// Raw delegate passed to the libvlc instance to 
        /// handle the binded event.
        /// </summary>
        public libvlc_callback_t EventDelegate
        {
            get;
            private set;
        }

        /// <summary>
        /// Indicates whether the event has been detached from 
        /// the instance and is safe to dispose.
        /// </summary>
        public Boolean Detached
        {
            get;
            private set;
        }

        /// <summary>
        /// Type of event to bind to.
        /// Eg. MediaStateChange.
        /// </summary>
        public VLCEventType Type
        {
            get;
            private set;
        }

        public IntPtr? UserData
        {
            get;
            private set;
        }

        /// <summary>
        /// Event that is raised when the binded 
        /// event is invoked.
        /// </summary>
        private VLCEventDelegate Invoked = delegate { };

        public VLCEventBinding(VLCEventType EventType, IntPtr? UserData = null)
        {
            Type = EventType;

            EventDelegate = new libvlc_callback_t(delegate(IntPtr EventPtr, IntPtr UserDataPtr)
            {
                var Event = Transform.ToStructure<libvlc_event_t>(EventPtr);
                if(Event.type == (libvlc_event_e)Type) Invoked(Event, UserDataPtr);
            });
        }

        public void SetInvoked(VLCEventDelegate Delegate)
        {
            Invoked = Delegate;
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
