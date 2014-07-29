using System;

namespace VLCInterface.Bridge.Internal.Enumerations
{
    /// <summary>
    /// State of Media
    /// <see cref="input_state_e"/>
    /// <remarks>
    /// Expected states by web plugins are:
    /// IDLE/CLOSE=0, OPENING=1, BUFFERING=2, PLAYING=3, PAUSED=4,
    /// STOPPING=5, ENDED=6, ERROR=7
    /// </remarks>
    /// </summary>
    internal enum libvlc_state_t
    {
        libvlc_NothingSpecial = 0,
        libvlc_Opening,
        libvlc_Buffering,
        libvlc_Playing,
        libvlc_Paused,
        libvlc_Stopped,
        libvlc_Ended,
        libvlc_Error
    };
}
