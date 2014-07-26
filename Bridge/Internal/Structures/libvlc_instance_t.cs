using System;
using System.Runtime.InteropServices;

namespace VLCInterface.Bridge.Internal.Structures
{
    [StructLayout(LayoutKind.Sequential)]

    internal struct libvlc_instance_t
    {
        public IntPtr   p_libvlc_int;
        public IntPtr   p_vlm;
        public Int32    b_playlist_locked;
        public UInt32   ref_count;
        public IntPtr   instance_lock; // vlc_mutex_t == win32 HANDLE
        public IntPtr   event_callback_lock;
        public IntPtr   p_callback_list;
    }
}