using System;

using VLCInterface.Bridge.Utils;
using VLCInterface.Bridge.Internal;
using VLCInterface.Bridge.Interfaces;

using VLCInterface.Bridge.Internal.Structures;

namespace VLCInterface.Bridge.Objects
{
    class VLCMediaInstance : IVLCObject
    {
         public IntPtr Handle { get; private set; }

        /*public libvlc_media_t Instance 
        {
            get
            {
                return Transform.ToStructure<libvlc_media_t>(Handle);
            }
        }*/

        public VLCMediaInstance(IntPtr Handle)
        {
            this.Handle = Handle;
        }
    }
}
