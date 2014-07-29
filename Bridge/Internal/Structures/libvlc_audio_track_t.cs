using System;

namespace VLCInterface.Bridge.Internal.Structures
{
    internal struct libvlc_audio_track_t
    {
        public UInt32 i_channels;
        public UInt32 i_rate;
    }
}
