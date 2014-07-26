using System;
using System.Runtime.InteropServices;

namespace VLCInterface.Bridge.Internal
{
    internal static class VLCUnmanaged
    {
        const String vlclibname     = "libvlc";

        #region Core

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

        #region Media

        // libvlc_media_new_location
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr libvlc_media_new_location(IntPtr MediaInstance, IntPtr MRL);

        // libvlc_media_new_path
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr libvlc_media_new_path(IntPtr MediaInstance, IntPtr Path);

        // libvlc_media_add_option
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static void libvlc_media_add_option(IntPtr MediaInstance, IntPtr Option);

        // libvlc_media_release
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static void libvlc_media_release(IntPtr MediaInstance);

        // libvlc_media_get_state
        [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
        public extern static libvlc_state_t libvlc_media_get_state(IntPtr MediaInstance);

        #endregion  

        #region Player
        
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

        #region Events

        #endregion

        // VLM is not used.
        #region VLM

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
