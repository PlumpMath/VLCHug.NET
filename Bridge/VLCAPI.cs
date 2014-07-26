using System;
using System.IO;
using System.Runtime.InteropServices;

using VLCInterface.Bridge.Utils;
using VLCInterface.Enumerations;
using VLCInterface.Bridge.Objects;
using VLCInterface.Bridge.Internal;

namespace VLCInterface.Bridge
{
    internal static class VLCAPI
    {
        #region Core

        public static VLCInstance New(int ArgC, String[] ArgV)
        {
            return new VLCInstance(VLCUnmanaged.libvlc_new(ArgC, ArgV));
        }

        public static void Release(IVLCObject Object)
        {
            VLCUnmanaged.libvlc_release(Object.Handle);
        }

        public static void Free(IVLCObject Object)
        {
            VLCUnmanaged.libvlc_free(Object.Handle);
        }

        public static void SetUserAgent(IVLCObject Object, String Name, String HTTPAgent)
        {
            IntPtr NamePtr      = Transform.ToIntPtr(Name),
                   HTTPAgentPtr = Transform.ToIntPtr(HTTPAgent);
            try
            {
                VLCUnmanaged.libvlc_set_user_agent(Object.Handle, NamePtr, HTTPAgentPtr);
            }
            finally
            {
                Transform.Free(NamePtr);
                Transform.Free(HTTPAgentPtr);
            }
        }

        public static String GetVersion()
        {
            return Transform.ToString(VLCUnmanaged.libvlc_get_version());
        }

        public static String GetCompiler()
        {
            return Transform.ToString(VLCUnmanaged.libvlc_get_compiler());
        }

        public static String GetErrorMsg()
        {
            return Transform.ToString(VLCUnmanaged.libvlc_errmsg());
        }

        #endregion

        public static class Media
        {
            #region Media

            public static IntPtr FromFile(IVLCObject Object, IntPtr FileHandle)
            {
                VLCUnmanaged.libvlc_media_new_fd(Object, FileHandle);
            }

            public static IntPtr FromPath(IVLCObject Object, String Path)
            {
                IntPtr PathPtr = IntPtr.Zero,
                       MediaPtr = IntPtr.Zero;

                try
                {
                    PathPtr = Transform.ToIntPtr(Path);

                    MediaPtr = VLCUnmanaged.libvlc_media_new_path(Object.Handle, PathPtr);
                }
                finally
                {
                    Transform.Free(PathPtr);
                }

                return MediaPtr;
            }

            public static IntPtr FromMRL(IVLCObject Object, String MRL)
            {
                IntPtr MRLPtr = IntPtr.Zero,
                        MediaPtr = IntPtr.Zero;

                try
                {
                    MRLPtr = Transform.ToIntPtr(MRL);

                    MediaPtr = VLCUnmanaged.libvlc_media_new_location(Object.Handle, MRLPtr);
                }
                finally
                {
                    Transform.Free(MRLPtr);
                }

                return MediaPtr;
            }

            public static IntPtr AsNode(IVLCObject Object, String Name)
            {
                IntPtr NamePtr = Transform.ToIntPtr(Name),
                       NodePtr = IntPtr.Zero;

                try
                {
                    VLCUnmanaged.libvlc_media_new_as_node(Object, NamePtr);
                }
                finally
                {
                    Transform.Free(NamePtr);
                }

                return NodePtr;
            }

            public static void AddOption(IVLCObject Object, String Option)
            {
                IntPtr OptionPtr = IntPtr.Zero;

                try
                {
                    OptionPtr = Transform.ToIntPtr(Option);

                    VLCUnmanaged.libvlc_media_add_option(Object.Handle, OptionPtr);
                }
                finally
                {
                    Transform.Free(OptionPtr);
                }
            }

            public static void AddOptionFlag(IVLCObject Object, String Option, UInt32 Flags)
            {
                IntPtr OptionPtr = IntPtr.Zero;

                try
                {
                    OptionPtr = Transform.ToIntPtr(Option);

                    VLCUnmanaged.libvlc_media_add_option(Object.Handle, OptionPtr);
                }
                finally
                {
                    Transform.Free(OptionPtr);
                }
            }

            public static void Retain(IVLCObject Object)
            {
                VLCUnmanaged.libvlc_media_retain(Object.Handle);
            }

            public static String GetMRL(IVLCObject Object)
            {
                return Transform.ToString(VLCUnmanaged.libvlc_media_get_mrl(Object.Handle));
            }

            public static VLCMediaState GetState(IVLCObject Object)
            {
                return (VLCMediaState)VLCUnmanaged.libvlc_media_get_state(Object.Handle);
            }

            public static void Release(IVLCObject Object)
            {
                VLCUnmanaged.libvlc_media_release(Object.Handle);
            }

            public static IntPtr Duplicate(IVLCObject Object)
            {
                return VLCUnmanaged.libvlc_media_duplicate(Object.Handle);
            }

            #endregion

            public static class Player
            {
                #region Player

                public static IntPtr FromMedia(IVLCObject Object)
                {
                    return VLCUnmanaged.libvlc_media_player_new_from_media(Object.Handle);
                }

                public static Boolean SetVolume(IVLCObject Object, int Volume)
                {
                    return VLCUnmanaged.libvlc_audio_set_volume(Object.Handle, Volume) > -1;
                }

                public static Boolean Play(IVLCObject Object)
                {
                    return VLCUnmanaged.libvlc_media_player_play(Object.Handle) > -1;
                }

                public static void Stop(IVLCObject Object)
                {
                    VLCUnmanaged.libvlc_media_player_stop(Object.Handle);
                }

                public static void Release(IVLCObject Object)
                {
                    VLCUnmanaged.libvlc_media_player_release(Object.Handle);
                }

                public static Boolean IsPlaying(IVLCObject Object)
                {
                    return VLCUnmanaged.libvlc_media_player_is_playing(Object.Handle) == 1;
                }

                public static VLCMediaState GetState(IVLCObject Object)
                {
                    return (VLCMediaState)VLCUnmanaged.libvlc_media_player_get_state(Object.Handle);
                }

                #endregion
            }
        }
    }
}
