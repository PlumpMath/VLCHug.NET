using System;
using VLCInterface.Enumerations;

namespace VLCInterface.Core.Events
{
    internal class VLCPlayerEvents
    {
        public delegate void OnMediaChanged(IntPtr NewMedia);
        public delegate void OnOpening();
        public delegate void OnBuffering(float NewCache);
        public delegate void OnPlaying();
        public delegate void OnPaused();
        public delegate void OnStopped();
        public delegate void OnForward();
        public delegate void OnBackward();
        public delegate void OnEndReached();
        public delegate void OnEncounteredError();
        public delegate void OnTimeChanged(Int64 NewTime);
        public delegate void OnPositionChanged(float NewPosition);
        public delegate void OnSeekableChanged(Int32 NewSeekable);
        public delegate void OnPausableChanged(Int32 NewPausable);
        public delegate void OnTitleChanged(Int32 NewTitle);
        public delegate void OnSnapshotTaken(String Filename);
        public delegate void OnLengthChanged(Int64 NewLength);
        public delegate void OnVout(Int32 NewCount);
        public delegate void OnScrambledChanged(Int32 NewScrambled);
    }
}
