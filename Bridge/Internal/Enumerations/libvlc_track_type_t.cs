using System;

namespace VLCInterface.Bridge.Internal.Enumerations
{
    internal enum libvlc_track_type_t
    {
        libvlc_track_unknown = -1,
        libvlc_track_audio = 0,
        libvlc_track_video = 1,
        libvlc_track_text = 2
    }
}
