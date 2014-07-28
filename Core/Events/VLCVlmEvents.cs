using System;
using VLCInterface.Enumerations;

namespace VLCInterface.Core.Events
{
    internal class VLCVlmEvents
    {
        public delegate void OnAdded(String MediaName);
        public delegate void OnRemoved(String MediaName);
        public delegate void OnChanged(String MediaName);
        public delegate void OnInstanceStarted(String MediaName);
        public delegate void OnInstanceStopped(String MediaName);

        public delegate void OnInstanceStatusInit(String MediaName, String InstanceName);
        public delegate void OnInstanceStatusOpening(String MediaName, String InstanceName);
        public delegate void OnInstanceStatusPlaying(String MediaName, String InstanceName);
        public delegate void OnInstanceStatusPause(String MediaName, String InstanceName);
        public delegate void OnInstanceStatusEnd(String MediaName, String InstanceName);
        public delegate void OnInstanceStatusError(String MediaName, String InstanceName);
    }
}
