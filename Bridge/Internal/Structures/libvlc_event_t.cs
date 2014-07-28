using System;
using VLCInterface.Bridge.Internal.Enumerations;
using System.Runtime.InteropServices;

namespace VLCInterface.Bridge.Internal.Structures
{
    [StructLayout(LayoutKind.Explicit)]
    internal struct libvlc_event_t
    {
        [FieldOffset(0)]
        public libvlc_event_e type;

        [FieldOffset(4)]
        public IntPtr p_obj;

        #region Sub-Parts

        [FieldOffset(8)]
        public media_meta_changed media_meta_changed;

        [FieldOffset(8)]
        public media_subitem_added media_subitem_added;

        [FieldOffset(8)]
        public media_duration_changed media_duration_changed;

        [FieldOffset(8)]
        public media_parsed_changed media_parsed_changed;

        [FieldOffset(8)]
        public media_freed media_freed;

        [FieldOffset(8)]
        public media_state_changed media_state_changed;

        [FieldOffset(8)]
        public media_subitemtree_added media_subitemtree_added;

        [FieldOffset(8)]
        public media_player_buffering media_player_buffering;

        [FieldOffset(8)]
        public media_player_position_changed media_player_position_changed;

        [FieldOffset(8)]
        public media_player_time_changed media_player_time_changed;

        [FieldOffset(8)]
        public media_player_title_changed media_player_title_changed;

        [FieldOffset(8)]
        public media_player_seekable_changed media_player_seekable_changed;

        [FieldOffset(8)]
        public media_player_pausable_changed media_player_pausable_changed;

        [FieldOffset(8)]
        public media_player_scrambled_changed media_player_scrambled_changed;

        [FieldOffset(8)]
        public media_player_vout media_player_vout;

        [FieldOffset(8)]
        public media_list_item_added media_list_item_added;

        [FieldOffset(8)]
        public media_list_will_add_item media_list_will_add_item;

        [FieldOffset(8)]
        public media_list_will_delete_item media_list_will_delete_item;

        [FieldOffset(8)]
        public media_list_player_next_item_set media_list_player_next_item_set;

        [FieldOffset(8)]
        public media_player_snapshot_taken media_player_snapshot_taken;

        [FieldOffset(8)]
        public media_player_length_changed media_player_length_changed;

        [FieldOffset(8)]
        public vlm_media_event vlm_media_event;

        [FieldOffset(8)]
        public media_player_media_changed media_player_media_changed;

        #endregion
    }

    #region Event Sub-Parts

    [StructLayout(LayoutKind.Sequential)]
    internal struct media_meta_changed
    {
        public libvlc_meta_t meta_type;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct media_subitem_added
    {
        public IntPtr new_child;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct media_duration_changed
    {
        public Int64 new_duration;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct media_parsed_changed
    {
        public Int32 new_status;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct media_freed
    {
        public IntPtr md;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct media_state_changed
    {
        public libvlc_state_t new_state;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct media_subitemtree_added
    {
        public IntPtr item;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct media_player_buffering
    {
        public float new_cache;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct media_player_position_changed
    {
        public float new_position;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct media_player_time_changed
    {
        public Int64 new_time;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct media_player_title_changed
    {
        public Int32 new_title;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct media_player_seekable_changed
    {
        public Int32 new_seekable;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct media_player_pausable_changed
    {
        public Int32 new_pausable;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct media_player_scrambled_changed
    {
        public Int32 new_scrambled;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct media_player_vout
    {
        public Int32 new_count;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct media_list_item_added
    {
        public IntPtr item;
        public Int32 index;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct media_list_will_add_item
    {
        public IntPtr item;
        public Int32 index;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct media_list_will_delete_item
    {
        IntPtr item;
        Int32 index;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct media_list_player_next_item_set
    {
        public IntPtr item;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct media_player_snapshot_taken
    {
        public IntPtr psz_filename;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct media_player_length_changed
    {
        public Int64 new_length;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct vlm_media_event
    {
        public IntPtr psz_media_name;
        public IntPtr psz_instance_name;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct media_player_media_changed
    {
        public IntPtr new_media;
    }

    #endregion
}
