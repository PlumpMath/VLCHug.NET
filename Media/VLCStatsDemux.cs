using System;
using VLCInterface.Bridge.Internal.Structures;

namespace VLCInterface.Media
{
    class VLCStatsDemux
    {
        private libvlc_media_stats_t stats;

        public VLCStatsDemux(libvlc_media_stats_t StatsStruct)
        {
            this.stats = StatsStruct;
        }

        public Int32 ReadBytes
        {
            get { return stats.i_demux_read_bytes; }
        }

        public float Bitrate
        {
            get { return stats.f_demux_bitrate; }
        }

        public Int32 Corrupted
        {
            get { return stats.i_demux_corrupted; }
        }

        public Int32 Discontinuity
        {
            get { return stats.i_demux_discontinuity; }
        }
    }
}
