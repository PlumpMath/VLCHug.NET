using System;
using System.IO;
using System.Runtime.InteropServices;

using VLCInterface.Media;
using VLCInterface.Enumerations;

using VLCInterface.Bridge.Utils;
using VLCInterface.Bridge.Objects;
using VLCInterface.Bridge.Internal;
using VLCInterface.Bridge.Interfaces;
using VLCInterface.Bridge.Internal.Delegates;
using VLCInterface.Bridge.Internal.Structures;
using VLCInterface.Bridge.Internal.Enumerations;

namespace VLCInterface.Bridge
{
    internal static class VLCAPI
    {
        #region [✓] Core

        public static VLCInstance New(int ArgC, String[] ArgV)
        {
            Trace("libvlc_new");

            return new VLCInstance(VLCUnmanaged.libvlc_new(ArgC, ArgV));
        }

        public static void Release(IVLCObject Object)
        {
            Trace("libvlc_release");
            VLCUnmanaged.libvlc_release(Object.Handle);
        }

        public static void Free(IVLCObject Object)
        {
            Trace("libvlc_free");
            VLCUnmanaged.libvlc_free(Object.Handle);
        }

        public static void SetUserAgent(IVLCObject Object, String Name, String HTTPAgent)
        {
            IntPtr NamePtr      = Transform.ToIntPtr(Name),
                   HTTPAgentPtr = Transform.ToIntPtr(HTTPAgent);
            try
            {
                Trace("libvlc_set_user_agent");
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
            Trace("libvlc_get_version");
            return Transform.ToString(VLCUnmanaged.libvlc_get_version());
        }

        public static String GetCompiler()
        {
            Trace("libvlc_get_compiler");
            return Transform.ToString(VLCUnmanaged.libvlc_get_compiler());
        }

        public static String GetErrorMsg()
        {
            Trace("libvlc_errmsg");
            var ErrorPtr = VLCUnmanaged.libvlc_errmsg();
            return Transform.ToString(ErrorPtr);
        }

        #endregion

        public static class Event
        {
            public static Boolean Attach(IVLCSubscribable Object, VLCEventType Event, libvlc_callback_t Callback, IntPtr? UserData = null)
            {
                IntPtr UsrData = (UserData.HasValue) ? (IntPtr)UserData : IntPtr.Zero;

                return VLCUnmanaged.libvlc_event_attach(
                    Object.EventManager,
                    (libvlc_event_e)Event,
                    Callback,
                    UsrData
                ) > 0;
            }
            
            public static Boolean Attach(IVLCSubscribable Object, VLCEventBinding Event)
            {
                return Attach(Object, Event.Type, Event.EventDelegate, Event.UserData);
            }

            public static void Detach(IVLCSubscribable Object, VLCEventType Event, libvlc_callback_t Callback, IntPtr? UserData = null)
            {
                IntPtr UsrData = (UserData.HasValue) ? (IntPtr)UserData : IntPtr.Zero;

                VLCUnmanaged.libvlc_event_detach(
                    Object.EventManager,
                    (libvlc_event_e)Event,
                    Callback,
                    UsrData
                );
            }

            public static void Detach(IVLCSubscribable Object, VLCEventBinding Event)
            {
                Detach(Object, Event.Type, Event.EventDelegate, Event.UserData);
                Event.NotifyDetached();
            }

            public static String Name(VLCEventType Event)
            {
                return Transform.ToString(VLCUnmanaged.libvlc_event_type_name((libvlc_event_e) Event));
            }
        }

        public static class Media
        {
            #region Media

            public static IntPtr FromFile(IVLCObject Object, IntPtr FileHandle)
            {
                Trace("libvlc_media_new_fd");
                return VLCUnmanaged.libvlc_media_new_fd(Object.Handle, FileHandle);
            }

            public static IntPtr FromPath(IVLCObject Object, String Path)
            {
                IntPtr PathPtr = IntPtr.Zero,
                       MediaPtr = IntPtr.Zero;

                try
                {
                    PathPtr = Transform.ToIntPtr(Path);

                    Trace("libvlc_media_new_path");
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

                    Trace("libvlc_media_new_location");
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
                    Trace("libvlc_media_new_as_node");
                    VLCUnmanaged.libvlc_media_new_as_node(Object.Handle, NamePtr);
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

                    Trace("libvlc_media_add_option");
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

                    Trace("libvlc_media_add_option");
                    VLCUnmanaged.libvlc_media_add_option(Object.Handle, OptionPtr);
                }
                finally
                {
                    Transform.Free(OptionPtr);
                }
            }

            public static void Retain(IVLCObject Object)
            {
                Trace("libvlc_media_retain");
                VLCUnmanaged.libvlc_media_retain(Object.Handle);
            }

            public static String GetMRL(IVLCObject Object)
            {
                Trace("libvlc_media_get_mrl");
                return Transform.ToString(VLCUnmanaged.libvlc_media_get_mrl(Object.Handle));
            }

            public static VLCMediaState GetState(IVLCObject Object)
            {
                Trace("libvlc_media_get_state");
                return (VLCMediaState)VLCUnmanaged.libvlc_media_get_state(Object.Handle);
            }

            public static void Release(IVLCObject Object)
            {
                Trace("libvlc_media_release");
                VLCUnmanaged.libvlc_media_release(Object.Handle);
            }

            public static IntPtr Duplicate(IVLCObject Object)
            {
                Trace("libvlc_media_duplicate");
                return VLCUnmanaged.libvlc_media_duplicate(Object.Handle);
            }

            public static String GetMeta(IVLCObject Object, VLCMetaData MetaOption)
            {
                Trace("libvlc_media_get_meta");
                var DataPtr = VLCUnmanaged.libvlc_media_get_meta(Object.Handle, (libvlc_meta_t)MetaOption);

                return Transform.ToString(DataPtr);
            }

            public static void SetMeta(IVLCObject Object, VLCMetaData MetaOption, String Value)
            {
                IntPtr ValuePtr = IntPtr.Zero;

                try
                {
                    ValuePtr = Transform.ToIntPtr(Value);

                    Trace("libvlc_media_set_meta");
                    VLCUnmanaged.libvlc_media_set_meta(Object.Handle, (libvlc_meta_t)MetaOption, ValuePtr);
                }
                finally
                {
                    Transform.Free(ValuePtr);
                }
            }

            public static Boolean SaveMeta(IVLCObject Object)
            {
                Trace("libvlc_media_save_meta");
                return VLCUnmanaged.libvlc_media_save_meta(Object.Handle) > 0;
            }

            public static VLCMediaStats GetStats(IVLCObject Object)
            {
                //IntPtr StatsPtr = Transform.StructDefToPtr<libvlc_media_stats_t>();

                var SizeOf = Marshal.SizeOf(typeof(libvlc_media_stats_t));

                var structs = new libvlc_media_stats_t();

                var StatsPtr = Marshal.AllocHGlobal(SizeOf);

                Marshal.StructureToPtr(structs, StatsPtr, false);

                Boolean Success = VLCUnmanaged.libvlc_media_get_stats(Object.Handle, StatsPtr) > 0;

                if(Success)
                {
                    Success = false;

                    libvlc_media_stats_t MediaStats;

                    try
                    {
                        MediaStats = Transform.ToStructure<libvlc_media_stats_t>(StatsPtr);

                        Success = true;
                    }
                    finally
                    {
                        Transform.Free(StatsPtr);
                    }

                    return (Success) ? new VLCMediaStats(MediaStats) : null;
                }

                return null;
            }

            public static IntPtr EventManager(IVLCObject Object)
            {
                return VLCUnmanaged.libvlc_media_event_manager(Object.Handle);
            }

            #endregion

            public static class Player
            {
                #region Player

                public static IntPtr FromMedia(IVLCObject Object)
                {
                    Trace("libvlc_media_player_new_from_media");
                    return VLCUnmanaged.libvlc_media_player_new_from_media(Object.Handle);
                }

                public static Boolean SetVolume(IVLCObject Object, int Volume)
                {
                    Trace("libvlc_audio_set_volume");
                    return VLCUnmanaged.libvlc_audio_set_volume(Object.Handle, Volume) > -1;
                }

                public static Boolean Play(IVLCObject Object)
                {
                    Trace("libvlc_media_player_play");
                    return VLCUnmanaged.libvlc_media_player_play(Object.Handle) > -1;
                }

                public static void Stop(IVLCObject Object)
                {
                    Trace("libvlc_media_player_stop");
                    VLCUnmanaged.libvlc_media_player_stop(Object.Handle);
                }

                public static void Release(IVLCObject Object)
                {
                    Trace("libvlc_media_player_release");
                    VLCUnmanaged.libvlc_media_player_release(Object.Handle);
                }

                public static Boolean IsPlaying(IVLCObject Object)
                {
                    Trace("libvlc_media_player_is_playing");
                    return VLCUnmanaged.libvlc_media_player_is_playing(Object.Handle) == 1;
                }

                public static VLCMediaState GetState(IVLCObject Object)
                {
                    Trace("libvlc_media_player_get_state");
                    return (VLCMediaState)VLCUnmanaged.libvlc_media_player_get_state(Object.Handle);
                }

                public static IntPtr EventManager(IVLCObject Object)
                {
                    return VLCUnmanaged.libvlc_media_player_event_manager(Object.Handle);
                }

                #endregion
            }
        }

        private static void Trace(String Name)
        {
            Console.WriteLine("TRACE: {0}", Name);
        }
    }
}
