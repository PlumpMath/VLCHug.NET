using System;
using System.Runtime.InteropServices;

namespace VLCInterface.Bridge.Internal.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct libvlc_log_t
    {
        public IntPtr i_object_id;
        public IntPtr psz_object_type;
        public IntPtr psz_module;
        public IntPtr psz_header;
    }
}
