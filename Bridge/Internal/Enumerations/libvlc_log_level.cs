using System;

namespace VLCInterface.Bridge.Internal.Enumerations
{
    /// <summary>
    /// Logging messages level.
    /// </summary>
    /// <remarks>
    /// Future LibVLC versions may define new levels.
    /// </remarks>
    internal enum libvlc_log_level
    {
        LIBVLC_DEBUG = 0,   /**< Debug message */
        LIBVLC_NOTICE = 2,  /**< Important informational message */
        LIBVLC_WARNING = 3, /**< Warning (potential error) message */
        LIBVLC_ERROR = 4    /**< Error message */
    }
}
