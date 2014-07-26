using System;
using System.Runtime.InteropServices;

namespace VLCInterface.Bridge.Internal.Structures
{
    [StructLayout(LayoutKind.Sequential)]

    internal struct libvlc_media_stats_t
    {
        public Int32 i_read_bytes;
        public float f_input_bitrate;
        public Int32 i_demux_read_bytes;
        public float f_demux_bitrate;
        public Int32 i_demux_corrupted;
        public Int32 i_demux_discontinuity;
        public Int32 i_decoded_video;
        public Int32 i_decoded_audio;
        public Int32 i_displayed_pictures;
        public Int32 i_lost_pictures;
        public Int32 i_played_abuffers;
        public Int32 i_lost_abuffers;
        public Int32 i_sent_packets;
        public Int32 i_sent_bytes;
        public float f_send_bitrate;
    }
}
