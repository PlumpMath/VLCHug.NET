using System;
using System.Runtime.InteropServices;

using VLCInterface.Bridge;
using VLCInterface.Enumerations;
using VLCInterface.Bridge.Interfaces;
using VLCInterface.Bridge.Objects;


namespace VLCInterface
{
    class Player : IVLCObject, IVLCSubscribable, IDisposable
    {
        public Boolean IsDisposed
        {
            get;
            private set;
        }

        public IntPtr Handle
        {
            get;
            private set;
        }

        public Boolean IsPlaying
        {
            get
            {
                return VLCAPI.Media.Player.IsPlaying(this);
            }
        }

        public VLCMediaState State
        {
            get { return VLCAPI.Media.Player.GetState(this); }
        }

        private VLCMedia Parent;

        public IntPtr EventManager
        {
            get { return VLCAPI.Media.Player.EventManager(this); }
        }

        private VLCEventBinding Event;

        public Player(VLCMedia Media)
        {
            IsDisposed = false;

            Parent = Media;
            Console.WriteLine("========== MEDIA :: {0}", Media.Source);
            Handle = VLCAPI.Media.Player.FromMedia(Media);

            Event = new VLCEventBinding(VLCEventType.MediaPlayerEncounteredError);
            Event.SetInvoked((o, u) =>
            {
                Console.WriteLine("ERROR: {0}", VLCAPI.GetErrorMsg());
            });

            VLCAPI.Event.Attach(this, Event);
        }

        public Boolean SetVolume(int Volume)
        {
            return VLCAPI.Media.Player.SetVolume(this, Volume);
        }

        public Boolean Play()
        {
            return VLCAPI.Media.Player.Play(this);
        }

        public void Stop()
        {
            VLCAPI.Media.Player.Stop(this);
        }

        public void Dispose()
        {
            if (!IsDisposed)
            {
                IsDisposed = true;
                VLCAPI.Media.Player.Release(this);
                Event.Dispose();
            }
        }

        ~Player()
        {
            Dispose();
        }
    }
}
