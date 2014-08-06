using System;

namespace VLCInterface.Bridge.Internal.Delegates
{
    /**
* Callback prototype for LibVLC log message handler.
* \param data data pointer as given to libvlc_log_set()
* \param level message level (@ref enum libvlc_log_level)
* \param ctx message context (meta-information about the message)
* \param fmt printf() format string (as defined by ISO C11)
* \param args variable argument list for the format
* \note Log message handlers <b>must</b> be thread-safe.
* \warning The message context pointer, the format string parameters and the
* variable arguments are only valid until the callback returns.
*/
    internal delegate void libvlc_log_cb(IntPtr DataPtr, Int32 Level, IntPtr Context, IntPtr FMT, IntPtr ArgsList);
}
