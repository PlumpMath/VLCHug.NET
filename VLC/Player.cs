using System;
using System.Runtime.InteropServices;

using VLCInterface.Bridge;
using VLCInterface.Enumerations;

namespace VLCInterface
{
    class Player : IVLCObject
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

        private Media Parent;

        public Player(Media Media)
        {
            IsDisposed = false;

            Parent = Media;

            Handle = VLCAPI.Media.Player.FromMedia(Media);
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
            }
        }

        ~Player()
        {
            Dispose();
        }
    }
}
