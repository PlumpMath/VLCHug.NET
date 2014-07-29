using System;
using System.Runtime.InteropServices;

namespace VLCInterface.Bridge.Internal.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct libvlc_log_message_t
    {
        Int32 i_severity;
        IntPtr psz_type;
        IntPtr psz_name;
        IntPtr psz_header;
        IntPtr psz_message;
    }
}
