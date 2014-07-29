using System;

namespace VLCInterface.Bridge.Internal.Structures
{
    internal struct libvlc_module_description_t
    {
        public IntPtr psz_name;
        public IntPtr psz_shortname;
        public IntPtr psz_longname;
        public IntPtr psz_help;
        public IntPtr p_next;
    }
}