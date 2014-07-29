using System;

namespace VLCInterface.Bridge.Internal.Structures
{
    internal struct libvlc_video_track_t
    {
        public UInt32 i_height;
        public UInt32 i_width;
        public UInt32 i_sar_num;
        public UInt32 i_sar_den;
        public UInt32 i_frame_rate_num;
        public UInt32 i_frame_rate_den;
    }
}
