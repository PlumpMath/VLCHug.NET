using System;
using VLCInterface.Bridge.Internal.Enumerations;

namespace VLCInterface.Enumerations
{
    public enum VLCMediaState
    {
        NothingSpecial  = libvlc_state_t.libvlc_NothingSpecial,
        Opening         = libvlc_state_t.libvlc_Opening,
        Buffering       = libvlc_state_t.libvlc_Buffering,
        Playing         = libvlc_state_t.libvlc_Playing,
        Paused          = libvlc_state_t.libvlc_Paused,
        Stopped         = libvlc_state_t.libvlc_Stopped,
        Ended           = libvlc_state_t.libvlc_Ended,
        Error           = libvlc_state_t.libvlc_Error
    }
}
