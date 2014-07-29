using System;
using System.Runtime.InteropServices;

namespace VLCInterface.Bridge.Internal.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct libvlc_log_t
    {
        IntPtr i_object_id;
        IntPtr psz_object_type;
        IntPtr psz_module;
        IntPtr psz_header;
    }
}
