using System;

using VLCInterface.Bridge.Utils;
using VLCInterface.Bridge.Internal;
using VLCInterface.Bridge.Interfaces;

using VLCInterface.Bridge.Internal.Structures;

namespace VLCInterface.Bridge.Objects
{
    class VLCInstance : IVLCObject
    {
        public IntPtr Handle { get; private set; }

        public libvlc_instance_t Instance 
        {
            get
            {
                return Transform.ToStructure<libvlc_instance_t>(Handle);
            }
        }

        public VLCInstance(IntPtr Handle)
        {
            this.Handle = Handle;
        }
    }
}
