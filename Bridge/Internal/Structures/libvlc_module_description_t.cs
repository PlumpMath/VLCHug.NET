using System;

namespace VLCInterface.Bridge.Internal.Structures
{
    internal struct libvlc_module_description_t
    {
        IntPtr psz_name;
        IntPtr psz_shortname;
        IntPtr psz_longname;
        IntPtr psz_help;
        IntPtr p_next;
    }
}