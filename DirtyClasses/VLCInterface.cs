using System;
using System.Runtime.InteropServices;

using VLCInterface.Bridge;
using VLCInterface.Bridge.Objects;
using VLCInterface.Bridge.Interfaces;


namespace VLCInterface
{
    public class VLCInterface : IDisposable, IVLCObject
    {

        #region Public Properties

        public Boolean IsDisposed 
        { 
            get; private set; 
        }

        public String Version
        {
            get
            {
                return VLCAPI.GetVersion();
            }
        }

        public String Compiler
        {
            get
            {
                return VLCAPI.GetCompiler();
            }
        }

        public String LastError
        {
            get
            {
                return VLCAPI.GetErrorMsg();
            }
        }

        public IntPtr Handle
        {
            get { return Instance.Handle; }
        }

        #endregion

        private VLCInstance Instance;

        #region Initialisation and Disposal

        public VLCInterface()
        {
            Init(0, new String[0]);
        }

        public VLCInterface(String[] ArgV)
        {
            Init(ArgV.Length, ArgV);
        }

        public VLCInterface(int ArgC, String[] ArgV)
        {
            Init(ArgC, ArgV);
        }

        private void Init(int ArgC, String[] ArgV)
        {
            IsDisposed = false;

            Instance = VLCAPI.New(ArgC, ArgV);

            if (Instance.Handle.Equals(IntPtr.Zero))
            {
                throw new NullReferenceException("Failed to initialise VLC instance!");
            }
        }

        public void Dispose()
        {
            if (!IsDisposed)
            {
                VLCAPI.Release(this);
                IsDisposed = true;
            }
        }

        ~VLCInterface()
        {
            Dispose();
        }

        #endregion

        #region Public Interface

        public void SetUserAgent(String Name, String HTTPAgent)
        {
            VLCAPI.SetUserAgent(this, Name, HTTPAgent);
        }

        public VLCMedia CreateMedia(String PlayString, Boolean IsFilePath = false)
        {
            return new VLCMedia(this, PlayString, IsFilePath);
        }

        #endregion
    }
}
