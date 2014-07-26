using System;
using System.Runtime.InteropServices;

using VLCInterface.Bridge.Internal.Enumerations;

namespace VLCInterface.Bridge.Internal
{
    /// <summary>
    /// Complete interop implementation of the LibVLC "Two Flower".
    /// <see cref="http://www.videolan.org/developers/vlc/doc/doxygen/html/group__libvlc.html"/>
    /// </summary>
    internal static class VLCUnmanaged
    {
        const String vlclibname     = "libvlc";

        #region [Check] Core

        // libvlc_new
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr libvlc_new(int argc, [MarshalAs(UnmanagedType.LPArray)] String[] argv);

        // libvlc_release
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static void libvlc_release(IntPtr InstanceAddr);

        // libvlc_set_user_agent
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static void libvlc_set_user_agent(IntPtr InstanceAddr, IntPtr Name, IntPtr HTTPAgent);

        // libvlc_get_version
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr libvlc_get_version();

        // libvlc_get_compiler
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr libvlc_get_compiler();

        // libvlc_errmsg 
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr libvlc_errmsg();

        // libvlc_free
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static void libvlc_free(IntPtr Pointer);

        #endregion

        #region [Check] Media

        // libvlc_media_new_location
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr libvlc_media_new_location(IntPtr Instance, IntPtr MRL);

        // libvlc_media_new_fd
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr libvlc_media_new_fd(IntPtr Instance, IntPtr FileDescPtr);

        // libvlc_media_new_as_node
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr libvlc_media_new_as_node(IntPtr Instance, IntPtr Path);

        // libvlc_media_new_path
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr libvlc_media_new_path(IntPtr Instance, IntPtr Path);

        // libvlc_media_retain
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static void libvlc_media_retain(IntPtr Instance);

        // libvlc_media_get_mrl
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr libvlc_media_get_mrl(IntPtr Instance);

        // libvlc_media_duplicate
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr libvlc_media_duplicate(IntPtr Instance);

        // libvlc_media_add_option
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static void libvlc_media_add_option(IntPtr MediaInstance, IntPtr Option);

        // libvlc_media_release
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static void libvlc_media_release(IntPtr MediaInstance);

        // libvlc_media_get_state
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static libvlc_state_t libvlc_media_get_state(IntPtr MediaInstance);

        // libvlc_media_get_meta
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr libvlc_media_get_meta(IntPtr MediaInstance, libvlc_meta_t MetaOption);

        // libvlc_media_set_meta
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr libvlc_media_set_meta(IntPtr MediaInstance, libvlc_meta_t MetaOption, IntPtr Value);

        // libvlc_media_save_meta
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static int libvlc_media_save_meta(IntPtr MediaInstance);

        // libvlc_media_get_stats 
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static int libvlc_media_get_stats(IntPtr MediaInstance, IntPtr StatsPtr);

        // libvlc_media_subitems
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr libvlc_media_subitems(IntPtr MediaInstance);

        // libvlc_media_event_manager
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr libvlc_media_event_manager(IntPtr MediaInstance);

        // libvlc_media_get_duration
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static Int64 libvlc_media_get_duration(IntPtr MediaInstance);

        // libvlc_media_parse
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static void libvlc_media_parse(IntPtr MediaInstance);

        // libvlc_media_parse_async
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static void libvlc_media_parse_async(IntPtr MediaInstance);

        // libvlc_media_is_parsed
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static int libvlc_media_is_parsed(IntPtr MediaInstance);

        // libvlc_media_set_user_data
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static void libvlc_media_set_user_data(IntPtr MediaInstance, IntPtr UserData);

        // libvlc_media_get_user_data
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr libvlc_media_get_user_data(IntPtr MediaInstance);

        /*
        // libvlc_media_tracks_get
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static UInt32 libvlc_media_tracks_get(IntPtr MediaInstance, libvlc_media_track_t ***tracks);

        // libvlc_media_tracks_release
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static void libvlc_media_tracks_release(libvlc_media_track_t **p_tracks, UInt32 Count);
        */

        #endregion  

        #region [Check] Player
        
        // libvlc_media_player_new
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr libvlc_media_player_new(IntPtr VLCInstance);

        // libvlc_media_player_new_from_media
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr libvlc_media_player_new_from_media(IntPtr MediaInstance);

        // libvlc_media_player_release
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static void libvlc_media_player_release(IntPtr PlayerInstance);

        // libvlc_media_player_set_media
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static void libvlc_media_player_set_media(IntPtr PlayerInstance, IntPtr MediaInstance);

        // libvlc_media_player_play
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static int libvlc_media_player_play(IntPtr PlayerInstance);

        // libvlc_media_player_set_pause
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static void libvlc_media_player_set_pause(IntPtr PlayerInstance, int DoPause);

        // libvlc_media_player_stop
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static void libvlc_media_player_stop(IntPtr PlayerInstance);

        // libvlc_media_player_is_playing
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static int libvlc_media_player_is_playing(IntPtr PlayerInstance);

        // libvlc_media_player_get_state
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static libvlc_state_t libvlc_media_player_get_state(IntPtr PlayerInstance);

        // libvlc_audio_set_volume
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static int libvlc_audio_set_volume(IntPtr PlayerInstance, Int32 Volume);

        #endregion

        #region [Check] List Player

        // libvlc_media_list_player_new
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr libvlc_media_list_player_new(IntPtr VLCInstance);

        // libvlc_media_list_player_release
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static void libvlc_media_list_player_release(IntPtr ListPlayerInstance);

        // libvlc_media_list_player_retain
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static void libvlc_media_list_player_retain(IntPtr ListPlayerInstance);

        // libvlc_media_list_player_event_manager
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr libvlc_media_list_player_event_manager(IntPtr ListPlayerInstance);

        // libvlc_media_list_player_set_media_player
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static void libvlc_media_list_player_set_media_player(IntPtr ListPlayerInstance, IntPtr PlayerInstance);

        // libvlc_media_list_player_set_media_list
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static void libvlc_media_list_player_set_media_list(IntPtr ListPlayerInstance, IntPtr MediaList);

        // libvlc_media_list_player_play
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static void libvlc_media_list_player_play(IntPtr ListPlayerInstance);

        // libvlc_media_list_player_pause
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static void libvlc_media_list_player_pause(IntPtr ListPlayerInstance);

        // libvlc_media_list_player_is_playing
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static Int32 libvlc_media_list_player_is_playing(IntPtr ListPlayerInstance);

        // libvlc_media_list_player_get_state
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static libvlc_state_t libvlc_media_list_player_get_state(IntPtr ListPlayerInstance);

        // libvlc_media_list_player_play_item_at_index
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static int libvlc_media_list_player_play_item_at_index(IntPtr ListPlayerInstance, Int32 Index);

        // libvlc_media_list_player_play_item
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static int libvlc_media_list_player_play_item(IntPtr ListPlayerInstance, IntPtr MediaInstance);

        // libvlc_media_list_player_stop
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static void libvlc_media_list_player_stop(IntPtr ListPlayerInstance);

        // libvlc_media_list_player_next
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static Int32 libvlc_media_list_player_next(IntPtr ListPlayerInstance);

        // libvlc_media_list_player_previous
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static Int32 libvlc_media_list_player_previous(IntPtr ListPlayerInstance);

        // libvlc_media_list_player_set_playback_mode
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static void libvlc_media_list_player_set_playback_mode(IntPtr ListPlayerInstance, libvlc_playback_mode_t Mode);

        #endregion

        #region [Check] Discoverer

        // libvlc_media_discoverer_new_from_name
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr libvlc_media_discoverer_new_from_name(IntPtr VLCInstance, IntPtr Name);

        // libvlc_media_discoverer_release
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static void libvlc_media_discoverer_release(IntPtr DiscoverInstance);

        // libvlc_media_discoverer_localized_name
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr libvlc_media_discoverer_localized_name(IntPtr DiscoverInstance);

        // libvlc_media_discoverer_media_list
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr libvlc_media_discoverer_media_list(IntPtr DiscoverInstance);

        // libvlc_media_discoverer_event_manager
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr libvlc_media_discoverer_event_manager(IntPtr DiscoverInstance);

        // libvlc_media_discoverer_is_running
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static Int32 libvlc_media_discoverer_is_running(IntPtr DiscoverInstance);

        #endregion

        #region [Check] Library

        // libvlc_media_library_new
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr libvlc_media_library_new(IntPtr VLCInstance);

        // libvlc_media_library_release
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static void libvlc_media_library_release(IntPtr MediaLibInstance);

        // libvlc_media_library_retain
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static void libvlc_media_library_retain(IntPtr MediaLibInstance);

        // libvlc_media_library_load
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static Int32 libvlc_media_library_load(IntPtr MediaLibInstance);

        // libvlc_media_library_media_list
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr libvlc_media_library_media_list(IntPtr MediaLibInstance);

        #endregion

        #region [✓] Time

        // libvlc_clock
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static Int64 libvlc_clock();

        // libvlc_delay
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static Int64 libvlc_delay(Int64 Timestamp);

        #endregion

        #region [Todo] VLM

        // libvlc_vlm_release
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        private extern static void libvlc_vlm_release(IntPtr Instance);

        // libvlc_vlm_add_broadcast
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        private extern static int libvlc_vlm_add_broadcast(
            IntPtr Instance,
            IntPtr Name,
            IntPtr Input,
            IntPtr Output,
            int NoOptions,
            IntPtr Options,
            Boolean Enable,
            Boolean Loop
        );

        // libvlc_vlm_add_input
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        private extern static int libvlc_vlm_add_input(IntPtr Instance, IntPtr Name, IntPtr InputMRL);

        #endregion
    }
}