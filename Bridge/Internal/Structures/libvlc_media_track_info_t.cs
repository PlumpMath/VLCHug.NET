using System;
using System.Runtime.InteropServices;
using VLCInterface.Bridge.Internal.Enumerations;

namespace VLCInterface.Bridge.Internal.Structures
{
    [StructLayout(LayoutKind.Explicit)]
    internal struct libvlc_media_track_info_t
    {
        /* Codec fourcc */
        [FieldOffset(0)]
        UInt32 i_codec;

        [FieldOffset(4)]
        Int32 i_id;

        [FieldOffset(8)]
        libvlc_track_type_t i_type;

        /* Codec specific */
        [FieldOffset(12)]
        Int32 i_profile;

        [FieldOffset(16)]
        Int32 i_level;

        /* Audio specific */
        [FieldOffset(20)]
        libvlc_media_track_info_t_audio audio;

        /* Video specific */
        [FieldOffset(20)]
        libvlc_media_track_info_t_video video;
    }
    
    [StructLayout(LayoutKind.Sequential)]
    internal struct libvlc_media_track_info_t_audio 
    {
        UInt32 i_channels;
        UInt32 i_rate;
    } 

    [StructLayout(LayoutKind.Sequential)]
    internal struct libvlc_media_track_info_t_video
    {
        UInt32 i_height;
        UInt32 i_width;
    }
}
