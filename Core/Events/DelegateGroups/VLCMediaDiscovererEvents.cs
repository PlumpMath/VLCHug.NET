using System;
using VLCInterface.Enumerations;

namespace VLCInterface.Core.Events.DelegateGroups
{
    internal class VLCMediaDiscovererEvents
    {
        public delegate void OnStarted();
        public delegate void OnEnded();
    }
}
