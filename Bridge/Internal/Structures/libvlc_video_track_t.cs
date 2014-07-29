using System;

namespace VLCInterface.Bridge.Internal.Structures
{
    internal struct libvlc_video_track_t
    {
        UInt32 i_height;
        UInt32 i_width;
        UInt32 i_sar_num;
        UInt32 i_sar_den;
        UInt32 i_frame_rate_num;
        UInt32 i_frame_rate_den;
    }
}
