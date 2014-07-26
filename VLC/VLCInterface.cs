using System;
using System.Runtime.InteropServices;

using VLCInterface.Bridge;

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

        public IntPtr Handle
        { 
            get; 
            private set; 
        }

        #endregion

        #region Initialisation and Disposal

        public VLCInstance()
        {
            Init(0, new String[0]);
        }

        public VLCInstance(int ArgC, String[] ArgV)
        {
            Init(ArgC, ArgV);
        }

        private void Init(int ArgC, String[] ArgV)
        {
            IsDisposed = false;

            Handle = VLCAPI.New(ArgC, ArgV);
        }

        public void Dispose()
        {
            if (!IsDisposed)
            {
                VLCAPI.Release(this);
                IsDisposed = true;
            }
        }

        ~VLCInstance()
        {
            Dispose();
        }

        #endregion

        #region Public Interface

        public void SetUserAgent(String Name, String HTTPAgent)
        {
            VLCAPI.SetUserAgent(this, Name, HTTPAgent);
        }

        public Media CreateMedia(String PlayString, Boolean IsFilePath = false)
        {
            return new Media(this, PlayString, IsFilePath);
        }

        #endregion
    }
}
