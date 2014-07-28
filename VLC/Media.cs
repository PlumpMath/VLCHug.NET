using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using VLCInterface.Media;
using VLCInterface.Bridge;
using VLCInterface.Bridge.Objects;
using VLCInterface.Enumerations;
using VLCInterface.Bridge.Interfaces;

namespace VLCInterface
{
    public class VLCMedia : IDisposable, IVLCObject, IVLCSubscribable
    {
        public VLCMediaState State
        {
            get
            {
                return VLCAPI.Media.GetState(this);
            }
        }

        public VLCMediaState PlayerState
        {
            get
            {
                return Player.State;
            }
        }

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

        public VLCMediaStats Statistics
        {
            get { return VLCAPI.Media.GetStats(this); }
        }

        private VLCInterface Parent;

        private Player Player;

        public IntPtr EventManager
        {
            get { return VLCAPI.Media.EventManager(this); }
        }

        private VLCEventBinding Event;

        public VLCMedia(VLCInterface VLCInstance, String PlayString, Boolean IsFilePath = false)
        {
            IsDisposed = false;

            Parent = VLCInstance;

            Handle = IsFilePath ?
                VLCAPI.Media.FromPath(VLCInstance, PlayString) :
                VLCAPI.Media.FromMRL(VLCInstance, PlayString);

            Event = new VLCEventBinding(VLCEventType.MediaStateChanged);
            Event.SetInvoked((o, u) =>
            {
                Console.WriteLine((VLCMediaState)o.media_state_changed.new_state);
            });

            VLCAPI.Event.Attach(this, Event);
            
            Player = new Player(this);
        }

        public Boolean Play()
        {
            return Player.Play();
        }

        public void Stop()
        {
            Player.Stop();
        }

        public void AddOption(String Option)
        {
            Boolean Restart = false;

            if (
                Player.State != VLCMediaState.Stopped && 
                Player.State != VLCMediaState.Ended && 
                Player.State != VLCMediaState.NothingSpecial
                )
            {
                Restart = true;
                Stop();
            }

            VLCAPI.Media.AddOption(this, Option);
            
            if (Restart) Play();
        }

        public void Dispose()
        {
            if (!IsDisposed)
            {
                IsDisposed = true;
                VLCAPI.Media.Release(this);
            }
        }

        ~VLCMedia()
        {
            Dispose();
        }
    }
}
