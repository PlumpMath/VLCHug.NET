using System;
using System.Runtime.InteropServices;

namespace VLCInterface.Bridge.Utils
{
    static class Transform
    {
        public static IntPtr ToIntPtr(String String)
        {
            return Marshal.StringToHGlobalAnsi(String);
        }

        public static String ToString(IntPtr Handle)
        {
            return Marshal.PtrToStringAnsi(Handle);
        }

        public static void Free(IntPtr Handle)
        {
            Marshal.FreeHGlobal(Handle);
        }

        public static T ToStructure<T>(IntPtr Handle)
        {
            return (T)Marshal.PtrToStructure(Handle, typeof(T));
        }
    }
}
