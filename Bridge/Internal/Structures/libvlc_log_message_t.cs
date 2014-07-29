using System;
using System.Runtime.InteropServices;

namespace VLCInterface.Bridge.Internal.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct libvlc_log_message_t
    {
        public Int32 i_severity;
        public IntPtr psz_type;
        public IntPtr psz_name;
        public IntPtr psz_header;
        public IntPtr psz_message;
    }
}
