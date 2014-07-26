using System;
using VLCInterface.Bridge.Internal.Structures;

namespace VLCInterface.Media
{
    internal class VLCMediaStats
    {
        private libvlc_media_stats_t stats;

        public VLCMediaStats(libvlc_media_stats_t StatsStruct)
        {
            this.stats = StatsStruct;

            Demux = new VLCStatsDemux(StatsStruct);
        }

        public Int32 ReadBytes
        {
            get { return stats.i_read_bytes; }
        }

        public float InputBitrate
        {
            get { return stats.f_input_bitrate; }
        }

        public VLCStatsDemux Demux
        {
            get;
            private set;
        }

        public Int32 DecodedVideo
        {
            get { return stats.i_decoded_video; }
        }

        public Int32 DecodedAudio
        {
            get { return stats.i_decoded_audio; }
        }

        public Int32 DisplayedPictures
        {
            get { return stats.i_displayed_pictures; }
        }

        public Int32 LostPictures
        {
            get { return stats.i_lost_pictures; }
        }

        public Int32 PlayedABuffers
        {
            get { return stats.i_played_abuffers; }
        }

        public Int32 LostABuffers
        {
            get { return stats.i_lost_abuffers; }
        }

        public Int32 SentPackets
        {
            get { return stats.i_sent_packets; }
        }

        public Int32 SentBytes
        {
            get { return stats.i_sent_bytes; }
        }

        public float SendBitrate
        {
            get { return stats.f_send_bitrate; }
        }
    }
}
