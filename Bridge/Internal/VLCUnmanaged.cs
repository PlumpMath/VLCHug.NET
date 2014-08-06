using System;
using System.Security;
using System.Runtime.InteropServices;

using VLCInterface.Bridge.Internal.Delegates;
using VLCInterface.Bridge.Internal.Enumerations;

namespace VLCInterface.Bridge.Internal
{
    /// <summary>
    /// Complete interop implementation of the LibVLC "Two Flower".
    /// <see cref="http://www.videolan.org/developers/vlc/doc/doxygen/html/group__libvlc.html"/>
    /// </summary>
    /// <remarks>
    /// Parts that are incomplete or or known to need
    /// reviewing are marked with -FLAG-TODO
    /// </remarks>
    internal static class NativeMethods
    {
        const String vlclibname     = "libvlc";

        // [Status] (Commented) Name

        #region [Todo] (✓) Core

            /// <summary>
            /// Create and initialize a libvlc instance.
            /// This functions accept a list of "command line" arguments similar to the
            /// main(). These arguments affect the LibVLC instance default configuration.
            /// </summary>
            /// <remarks>
            /// Arguments are meant to be passed from the command line to LibVLC, just like
            /// VLC media player does. The list of valid arguments depends on the LibVLC
            /// version, the operating system and platform, and set of available LibVLC
            /// plugins. Invalid or unsupported arguments will cause the function to fail
            /// (i.e. return NULL). Also, some arguments may alter the behaviour or
            /// otherwise interfere with other LibVLC functions.
            /// </remarks>
            /// <warning>
            /// There is absolutely no warranty or promise of forward, backward and
            /// cross-platform compatibility with regards to libvlc_new() arguments.
            /// We recommend that you do not use them, other than when debugging.
            /// </warning>
            /// <param name="ArgC">The number of arguments (should be 0)</param>
            /// <param name="ArgV">List of arguments (should be NULL)</param>
            /// <returns>The libvlc instance or NULL in case of error</returns>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static IntPtr libvlc_new(int ArgC, [MarshalAs(UnmanagedType.LPArray)] String[] ArgV);

            /// <summary>
            /// Decrement the reference count of a libvlc instance, and destroy it
            /// if it reaches zero.
            /// </summary>
            /// <param name="InstanceAddr">The instance to destroy</param>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static void libvlc_release(IntPtr InstanceAddr);

            /// <summary>
            /// Increments the reference count of a libvlc instance.
            /// The initial reference count is 1 after libvlc_new() returns.
            /// </summary>
            /// <param name="InstanceAddr">The instance to reference</param>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static void libvlc_retain(IntPtr InstanceAddr);

            /// <summary>
            /// Try to start a user interface for the libvlc instance.
            /// </summary>
            /// <param name="InstanceAddr">The instance</param>
            /// <param name="Name">Interface name, or NULL for default</param>
            /// <returns>0 on success, -1 on error</returns>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static Int32 libvlc_add_intf(IntPtr InstanceAddr, IntPtr Name);

            /// <summary>
            /// Sets the application name. LibVLC passes this as the user agent string
            /// when a protocol requires it.
            /// </summary>
            /// <param name="InstanceAddr">LibVLC instance</param>
            /// <param name="Name">Human-readable application name, e.g. "FooBar player 1.2.3"</param>
            /// <param name="HTTPAgent">HTTP User Agent, e.g. "FooBar/1.2.3 Python/2.6.0"</param>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static void libvlc_set_user_agent(IntPtr InstanceAddr, IntPtr Name, IntPtr HTTPAgent);

            // -FLAG-TODO
            /// <summary>
            /// Registers a callback for the LibVLC exit event. This is mostly useful if
            /// the VLC playlist and/or at least one interface are started with
            /// libvlc_playlist_play() or libvlc_add_intf() respectively.
            /// Typically, this function will wake up your application main loop (from
            /// another thread).
            /// </summary>
            /// <remarks> This function should be called before the playlist or interface are
            /// started. Otherwise, there is a small race condition: the exit event could
            /// be raised before the handler is registered.
            /// </remarks>
            /// <param name="InstanceAddr">LibVLC instance</param>
            /// <param name="Callback">
            /// Callback to invoke when LibVLC wants to exit
            /// or NULL to disable the exit handler (as by default)
            /// </param>
            /// <param name="Opaque">opaque data pointer for the callback</param>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static void libvlc_set_exit_handler(IntPtr InstanceAddr, libvlc_exit_cb Callback, IntPtr Opaque);

            /// <summary>
            /// Sets some meta-information about the application.
            /// </summary>
            /// <seealso cref="libvlc_set_user_agent()"/>
            /// <param name="InstanceAddr">LibVLC instance</param>
            /// <param name="Name">Java-style application identifier, e.g. "com.acme.foobar"</param>
            /// <param name="Version">Application version numbers, e.g. "1.2.3"</param>
            /// <param name="Icon">Application icon name, e.g. "foobar"</param>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static void libvlc_set_app_id(IntPtr InstanceAddr, IntPtr Name, IntPtr Version, IntPtr Icon);

            /// <summary>
            /// Retrieve libvlc version.
            /// </summary>
            /// <example>"1.1.0-git The Luggage"</example>
            /// <returns>A string containing the libvlc version</returns>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static IntPtr libvlc_get_version();

            /// <summary>
            /// Retrieve libvlc compiler version.
            /// </summary>
            /// <example>"gcc version 4.2.3 (Ubuntu 4.2.3-2ubuntu6)"</example>
            /// <returns>A string containing the libvlc compiler version</returns>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static IntPtr libvlc_get_compiler();

            /// <summary>
            /// Retrieve libvlc changeset
            /// </summary>
            /// <example>"aa9bce0bc4"</example>
            /// <returns>A string containing the libvlc changeset</returns>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static IntPtr libvlc_get_changeset();

            /// <summary>
            /// Frees an heap allocation returned by a LibVLC function.
            /// If you know you're using the same underlying C run-time as the LibVLC
            /// implementation, then you can call ANSI C free() directly instead.
            /// </summary>
            /// <param name="Pointer">The pointer to the object.</param>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static void libvlc_free(IntPtr Pointer);

        #endregion

        #region [Todo] (✓) Core Error Handling

            /// <summary>
            /// A human-readable error message for the last LibVLC error in the calling
            /// thread. The resulting string is valid until another error occurs (at least
            /// until the next LibVLC call).
            /// </summary>
            /// <returns>An error message, or NULL if there was no error</returns>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static IntPtr libvlc_errmsg();
        
            /// <summary>
            /// Clears the LibVLC error status for the current thread. This is optional.
            /// By default, the error status is automatically overridden when a new error
            /// occurs, and destroyed when the thread exits.
            /// </summary>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static void libvlc_clearerr();

            // -FLAG-TODO
            //public extern static IntPtr libvlc_vprinterr (IntPtr FMT, va_list ap);
            //public extern static IntPtr libvlc_printerr (IntPtr FMT, ...);

        #endregion

        #region [✓] (✓) Core Modules

            /// <summary>
            /// Release a list of module descriptions.
            /// </summary>
            /// <param name="ModuleDescription">The list to be released</param>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static void libvlc_module_description_list_release(IntPtr ModuleDescription);

            /// <summary>
            /// Returns a list of audio filters that are available.
            /// </summary>
            /// <param name="Instance">LibVLC instance</param>
            /// <returns>
            /// Pointer to a libvlc_module_description_t struct.
            /// A list of module descriptions. It should be freed with libvlc_module_description_list_release().
            /// In case of an error, NULL is returned.
            /// </returns>
            /// <see cref="libvlc_module_description_t"/>
            /// <see cref="libvlc_module_description_list_release"/>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static IntPtr libvlc_audio_filter_list_get(IntPtr Instance);

            /// <summary>
            /// Returns a list of video filters that are available.
            /// </summary>
            /// <param name="Instance">LibVLC instance</param>
            /// <returns>
            /// Pointer to a libvlc_module_description_t struct.
            /// A list of module descriptions. It should be freed with libvlc_module_description_list_release().
            /// In case of an error, NULL is returned.
            /// </returns>
            /// <see cref="libvlc_module_description_t"/>
            /// <see cref="libvlc_module_description_list_release"/>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static IntPtr libvlc_video_filter_list_get(IntPtr Instance);

        #endregion

        #region [✓] (✓) Core Events

            /// <summary>
            /// Register for an event notification.
            /// </summary>
            /// <param name="EventManager">
            /// The event manager to which you want to attach to.
            /// Generally it is obtained by vlc_my_object_event_manager() where
            /// my_object is the object you want to listen to.
            /// </param>
            /// <param name="EventType">The desired event to which we want to listen</param>
            /// <param name="Callback">The function to call when the event occurs</param>
            /// <param name="UserData">User provided data to carry with the event</param>
            /// <returns>0 on success, ENOMEM on error</returns>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static Int32 libvlc_event_attach(IntPtr EventManager, libvlc_event_e EventType, libvlc_callback_t Callback, IntPtr UserData);

            /// <summary>
            /// Unregister an event notification.
            /// </summary>
            /// <param name="EventManager">The event manager</param>
            /// <param name="EventType">The desired event to which we want to unregister</param>
            /// <param name="Callback">The function to call when the event occurs</param>
            /// <param name="UserData">User provided data to carry with the event</param>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static void libvlc_event_detach(IntPtr EventManager, libvlc_event_e EventType, libvlc_callback_t Callback, IntPtr UserData);

            /// <summary>
            /// Get an event's type name
            /// </summary>
            /// <param name="EventType">The desired event</param>
            /// <returns>The event's type name</returns>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static IntPtr libvlc_event_type_name(libvlc_event_e EventType);

        #endregion

        #region [Todo] (✓) Logging

            // -FLAG-TODO
            /// <summary>
            /// Gets debugging information about a log message: the name of the VLC module
            /// emitting the message and the message location within the source code.
            /// The returned module name and file name will be NULL if unknown.
            /// The returned line number will similarly be zero if unknown.
            /// </summary>
            /// <warning>
            /// The returned module name and source code file name, if non-NULL,
            /// are only valid until the logging callback returns.
            /// </warning>
            /// <param name="Context">Message context (as passed to the libvlc_log_cb callback)</param>
            /// <param name="ModuleName">Module name storage (or NULL) [OUT]</param>
            /// <param name="FileName">Source code file name storage (or NULL) [OUT]</param>
            /// <param name="FileLine">Source code file line number storage (or NULL) [OUT]</param>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static void libvlc_log_get_context(IntPtr Context, out IntPtr ModuleName, out IntPtr FileName, out UInt32 FileLine);

            /// <summary>
            /// Gets VLC object information about a log message: the type name of the VLC
            /// object emitting the message, the object header if any and a temporaly-unique
            /// object identifier. This information is mainly meant for <b>manual</b>
            /// troubleshooting.
            ///
            /// The returned type name may be "generic" if unknown, but it cannot be NULL.
            /// The returned header will be NULL if unset; in current versions, the header
            /// is used to distinguish for VLM inputs.
            /// The returned object ID will be zero if the message is not associated with
            /// any VLC object.
            /// </summary>
            /// <warning>
            /// The returned module name and source code file name, if non-NULL,
            /// are only valid until the logging callback returns.
            /// </warning>
            /// <param name="Context">Message context (as passed to the libvlc_log_cb callback)</param
            /// <param name="Name">Object name storage (or NULL) [OUT]</param>
            /// <param name="Header">Object header (or NULL) [OUT]</param>
            /// <param name="LinePtr">Source code file line number storage (or NULL) [OUT]</param>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static void libvlc_log_get_object(IntPtr Context, IntPtr Name, IntPtr Header, IntPtr LinePtr);

            /// <summary>
            /// Unsets the logging callback for a LibVLC instance. This is rarely needed:
            /// the callback is implicitly unset when the instance is destroyed.
            /// This function will wait for any pending callbacks invocation to complete
            /// (causing a deadlock if called from within the callback).
            /// </summary>
            /// <param name="Instance">LibVLC instance</param>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static void libvlc_log_unset(IntPtr Instance);

            /// <summary>
            /// Sets the logging callback for a LibVLC instance.
            /// This function is thread-safe: it will wait for any pending callbacks
            /// invocation to complete.
            /// </summary>
            /// <param name="Instance">LibVLC instance</param>
            /// <param name="Callback">Callback function pointer</param>
            /// <param name="Data">Opaque data pointer for the callback function</param>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static void libvlc_log_set(IntPtr Instance, libvlc_log_cb Callback, IntPtr Data);

            /// <summary>
            /// Sets up logging to a file.
            /// </summary>
            /// <param name="Instance">LibVLC instance</param>
            /// <param name="FilePtr">
            /// FILE pointer opened for writing
            /// (the FILE pointer must remain valid until libvlc_log_unset())
            /// </param>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static void libvlc_log_set_file(IntPtr Instance, IntPtr FilePtr);

        #endregion

        #region [Todo] (✓) Media

            /// <summary>
            /// Create a media with a certain given media resource location,
            /// for instance a valid URL.
            ///
            /// To refer to a local file with this function,
            /// the file://... URI syntax <b>must</b> be used (see IETF RFC3986).
            /// </summary>
            /// <remarks>
            /// It is recommended to use libvlc_media_new_path() instead when dealing with
            /// local files.
            /// </remarks>
            /// <see cref="libvlc_media_release"/>
            /// <param name="Instance">LibVLC Instance</param>
            /// <param name="MRL">The media location</param>
            /// <returns>Pointer to the newly created media or NULL on error</returns>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static IntPtr libvlc_media_new_location(IntPtr Instance, IntPtr MRL);

            /// <summary>
            /// Create a media for a certain file path.
            /// </summary>
            /// <see cref="libvlc_media_release"/>
            /// <param name="Instance">LibVLC Instance</param>
            /// <param name="Path">Local filesystem path</param>
            /// <returns>Pointer to the newly created media or NULL on error</returns>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static IntPtr libvlc_media_new_path(IntPtr Instance, IntPtr Path);

            /// <summary>
            /// Create a media for an already open file descriptor.
            /// The file descriptor shall be open for reading (or reading and writing).
            ///
            /// Regular file descriptors, pipe read descriptors and character device
            /// descriptors (including TTYs) are supported on all platforms.
            /// Block device descriptors are supported where available.
            /// Directory descriptors are supported on systems that provide fdopendir().
            /// Sockets are supported on all platforms where they are file descriptors,
            /// i.e. all except Windows.
            /// </summary>
            /// <remarks>
            /// This library will <b>not</b> automatically close the file descriptor
            /// under any circumstance. Nevertheless, a file descriptor can usually only be
            /// rendered once in a media player. To render it a second time, the file
            /// descriptor should probably be rewound to the beginning.
            /// </remarks>
            /// <see cref="libvlc_media_release"/>
            /// <param name="Instance">LibVLC Instance</param>
            /// <param name="FileDescPtr">Open file descriptor</param>
            /// <returns>Pointer to the newly created media or NULL on error</returns>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static IntPtr libvlc_media_new_fd(IntPtr Instance, IntPtr FileDescPtr);

            /// <summary>
            /// Create a media as an empty node with a given name.
            /// </summary>
            /// <see cref="libvlc_media_release"/>
            /// <param name="Instance">LibVLC Instance</param>
            /// <param name="Name">The name of the node</param>
            /// <returns>Pointer to the newly created media or NULL on error</returns>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static IntPtr libvlc_media_new_as_node(IntPtr Instance, IntPtr Name);

            /// <summary>
            /// Add an option to the media.
            /// This option will be used to determine how the media_player will
            /// read the media. This allows to use VLC's advanced
            /// reading/streaming options on a per-media basis.
            /// </summary>
            /// <remarks>
            /// The options are listed in 'vlc --long-help' from the command line,
            /// e.g. "-sout-all". Keep in mind that available options and their semantics
            /// vary across LibVLC versions and builds.
            /// </remarks>
            /// <warning>
            /// Not all options affects libvlc_media_t objects:
            /// Specifically, due to architectural issues most audio and video options,
            /// such as text renderer options, have no effects on an individual media.
            /// These options must be set through libvlc_new() instead.
            /// </warning>
            /// <param name="MediaInstance">The media descriptor</param>
            /// <param name="Option">The options (as a string)</param>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static void libvlc_media_add_option(IntPtr MediaInstance, IntPtr Option);

            /// <summary>
            /// Add an option to the media with configurable flags.
            /// This option will be used to determine how the media_player will
            /// read the media. This allows to use VLC's advanced
            /// reading/streaming options on a per-media basis.
            /// </summary>
            /// <remarks>
            /// The options are listed in 'vlc --long-help' from the command line,
            /// e.g. "-sout-all". Keep in mind that available options and their semantics
            /// vary across LibVLC versions and builds.
            /// </remarks>
            /// <warning>
            /// Not all options affects libvlc_media_t objects:
            /// Specifically, due to architectural issues most audio and video options,
            /// such as text renderer options, have no effects on an individual media.
            /// These options must be set through libvlc_new() instead.
            /// </warning>
            /// <param name="MediaInstance">The media descriptor</param>
            /// <param name="Option">The options (as a string)</param>
            /// <param name="Flags">The flags for this option</param>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static void libvlc_media_add_option_flag(IntPtr MediaInstance, IntPtr Option, UInt32 Flags);

            /// <summary>
            /// Retain a reference to a media descriptor object (libvlc_media_t). Use
            /// libvlc_media_release() to decrement the reference count of a
            /// media descriptor object.
            /// </summary>
            /// <param name="Instance">The media instance</param>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static void libvlc_media_retain(IntPtr Instance);

            /// <summary>
            /// Decrement the reference count of a media descriptor object. If the
            /// reference count is 0, then libvlc_media_release() will release the
            /// media descriptor object. It will send out an libvlc_MediaFreed event
            /// to all listeners. If the media descriptor object has been released it
            /// should not be used again.
            /// </summary>
            /// <param name="MediaInstance">The media instance</param>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static void libvlc_media_release(IntPtr MediaInstance);

            /// <summary>
            /// Get the media resource locator (mrl) from a media descriptor object
            /// </summary>
            /// <param name="Instance">The media instance</param>
            /// <returns>String with mrl of media descriptor object</returns>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static IntPtr libvlc_media_get_mrl(IntPtr Instance);

            /// <summary>
            /// Duplicate a media descriptor object.
            /// </summary>
            /// <param name="Instance">A media instance</param>
            /// <returns>>A media instance</returns>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static IntPtr libvlc_media_duplicate(IntPtr Instance);

            /// <summary>
            /// Read the meta of the media.
            /// If the media has not yet been parsed this will return NULL.
            /// This methods automatically calls libvlc_media_parse_async(), so after calling
            /// it you may receive a libvlc_MediaMetaChanged event. If you prefer a synchronous
            /// version ensure that you call libvlc_media_parse() before get_meta().
            /// </summary>
            /// <see cref="libvlc_media_parse"/>
            /// <see cref="libvlc_media_parse_async"/>
            /// <see cref="libvlc_MediaMetaChanged"/>
            /// <param name="MediaInstance">A media instance</param>
            /// <param name="MetaOption">The meta to read</param>
            /// <returns>The media's meta, or NULL if not parsed</returns>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static IntPtr libvlc_media_get_meta(IntPtr MediaInstance, libvlc_meta_t MetaOption);

            /// <summary>
            /// Set the meta of the media (this function will not save the meta, call
            /// libvlc_media_save_meta in order to save the meta).
            /// </summary>
            /// <param name="MediaInstance">A media instance</param>
            /// <param name="MetaOption">The meta to write</param>
            /// <param name="Value">The media's meta</param>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static void libvlc_media_set_meta(IntPtr MediaInstance, libvlc_meta_t MetaOption, IntPtr Value);

            /// <summary>
            /// Save the meta previously set
            /// </summary>
            /// <param name="MediaInstance">A media instance</param>
            /// <returns>True if the write operation was successful</returns>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static Int32 libvlc_media_save_meta(IntPtr MediaInstance);

            /// <summary>
            /// Get current state of media descriptor object.
            /// </summary>
            /// <remarks>
            /// Possible media states
            /// are defined in libvlc_structures.c ( libvlc_NothingSpecial=0,
            /// libvlc_Opening, libvlc_Buffering, libvlc_Playing, libvlc_Paused,
            /// libvlc_Stopped, libvlc_Ended,
            /// libvlc_Error).
            /// </remarks>
            /// <see cref="libvlc_state_t"/>
            /// <param name="MediaInstance">A media instance</param>
            /// <returns>State of media instance</returns>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static libvlc_state_t libvlc_media_get_state(IntPtr MediaInstance);

            /// <summary>
            /// Get the current statistics about the media
            /// </summary>
            /// <param name="MediaInstance">A media instance</param>
            /// <param name="StatsPtr">
            /// Structure that contain the statistics about the media
            /// (this structure must be allocated by the caller)
            /// </param>
            /// <returns>True if the statistics are available, false otherwise</returns>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static Int32 libvlc_media_get_stats(IntPtr MediaInstance, IntPtr StatsPtr);

            /// <summary>
            /// Get subitems of media descriptor object. This will increment
            /// the reference count of supplied media descriptor object. Use
            /// libvlc_media_list_release() to decrement the reference counting.
            /// </summary>
            /// <param name="MediaInstance">A media instance</param>
            /// <returns>List of media descriptor subitems or NULL</returns>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static IntPtr libvlc_media_subitems(IntPtr MediaInstance);

            /// <summary>
            /// Get event manager from media descriptor object.
            /// </summary>
            /// <remarks>
            /// This function doesn't increment reference counting.
            /// </remarks>
            /// <param name="MediaInstance">A media instance</param>
            /// <returns>Pointer to a event manager object</returns>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static IntPtr libvlc_media_event_manager(IntPtr MediaInstance);

            /// <summary>
            /// Get duration (in ms) of media instance item.
            /// </summary>
            /// <param name="MediaInstance">A media instance</param>
            /// <returns>Duration of media item or -1 on error</returns>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static Int64 libvlc_media_get_duration(IntPtr MediaInstance);

            /// <summary>
            /// Parse a media.
            /// This fetches (local) meta data and tracks information.
            /// The method is synchronous.
            /// </summary>
            /// <see cref="libvlc_media_parse_async"/>
            /// <see cref="libvlc_media_get_meta"/>
            /// <see cref="libvlc_media_get_tracks_info"/>
            /// <param name="MediaInstance">A media instance</param>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static void libvlc_media_parse(IntPtr MediaInstance);

            /// <summary>
            /// Parse a media.
            /// This fetches (local) meta data and tracks information.
            /// The method is the asynchronous of libvlc_media_parse().
            /// To track when this is over you can listen to libvlc_MediaParsedChanged
            /// event. However if the media was already parsed you will not receive this
            /// event.
            /// </summary>
            /// <see cref="libvlc_media_parse"/>
            /// <see cref="libvlc_MediaParsedChanged"/>
            /// <see cref="libvlc_media_get_meta"/>
            /// <see cref="libvlc_media_get_tracks_info"/>
            /// <param name="MediaInstance">A media instance</param>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static void libvlc_media_parse_async(IntPtr MediaInstance);

            /// <summary>
            /// Get Parsed status for media descriptor object.
            /// </summary>
            /// <see cref="libvlc_MediaParsedChanged"/>
            /// <param name="MediaInstance">A media instance</param>
            /// <returns>True if media object has been parsed otherwise it returns false</returns>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static Int32 libvlc_media_is_parsed(IntPtr MediaInstance);

            /// <summary>
            /// Sets media descriptor's user_data. user_data is specialized data
            /// accessed by the host application, VLC.framework uses it as a pointer to
            /// an native object that references a libvlc_media_t pointer
            /// </summary>
            /// <param name="MediaInstance">A media instance</param>
            /// <param name="UserData">Pointer to user data</param>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static void libvlc_media_set_user_data(IntPtr MediaInstance, IntPtr UserData);

            /// <summary>
            /// Get media descriptor's user_data. user_data is specialized data
            /// accessed by the host application, VLC.framework uses it as a pointer to
            /// an native object that references a libvlc_media_t pointer
            /// </summary>
            /// <param name="MediaInstance">A media instance</param>
            /// <returns>Pointer to user data</returns>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static IntPtr libvlc_media_get_user_data(IntPtr MediaInstance);

            // -FLAG-TODO
            /*  WTF are with these pointers?!
            
                [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
                public extern static UInt32 libvlc_media_tracks_get(IntPtr MediaInstance, libvlc_media_track_t ***tracks);

                [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
                public extern static void libvlc_media_tracks_release(libvlc_media_track_t **p_tracks, UInt32 Count);
            */

        #endregion

        /* -FLAG-TODO
         * Player has quite a lot of functions 
         * yet to implement
         */
        #region [Todo] (✓) Player

            /// <summary>
            /// Create an empty Media Player object
            /// </summary>
            /// <param name="VLCInstance">
            /// The libvlc instance in which the Media Player
            /// should be created.
            /// </param>
            /// <returns>A new media player object, or NULL on error.</returns>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static IntPtr libvlc_media_player_new(IntPtr VLCInstance);
        
            /// <summary>
            /// Create a Media Player object from a Media
            /// </summary>
            /// <param name="MediaInstance">
            /// The media. After the player contruction the pointer to the media 
            /// can be safely destroyed.
            /// </param>
            /// <returns>A new media player object, or NULL on error.</returns>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static IntPtr libvlc_media_player_new_from_media(IntPtr MediaInstance);

            /// <summary>
            /// Release a media_player after use
            /// Decrement the reference count of a media player object. If the
            /// reference count is 0, then libvlc_media_player_release() will
            /// release the media player object. If the media player object
            /// has been released, then it should not be used again.
            /// </summary>
            /// <param name="PlayerInstance">The Media Player to free</param>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static void libvlc_media_player_release(IntPtr PlayerInstance);

            /// <summary>
            /// Retain a reference to a media player object. Use
            /// libvlc_media_player_release() to decrement reference count.
            /// </summary>
            /// <param name="PlayerInstance">Media player object</param>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static void libvlc_media_player_retain(IntPtr PlayerInstance);

            /// <summary>
            /// Set the media that will be used by the media_player. If any,
            /// previous media will be released.
            /// </summary>
            /// <param name="PlayerInstance">The Media Player</param>
            /// <param name="MediaInstance">
            /// The Media. Afterwards the pointer to the media 
            /// can be safely destroyed.
            /// </param>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static void libvlc_media_player_set_media(IntPtr PlayerInstance, IntPtr MediaInstance);
        
            /// <summary>
            /// Get the media used by the media_player.
            /// </summary>
            /// <param name="PlayerInstance">The Media Player</param>
            /// <returns>
            /// The media associated with the player instance,
            /// or NULL if no media is associated
            /// </returns>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static IntPtr libvlc_media_player_get_media(IntPtr PlayerInstance);

            /// <summary>
            /// Get the Event Manager from which the media player sends events.
            /// </summary>
            /// <param name="PlayerInstance">The Media Player</param>
            /// <returns>The event manager associated with the player instance.</returns>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static IntPtr libvlc_media_player_event_manager(IntPtr PlayerInstance);

            /// <summary>
            /// Gets the playing state of the player.
            /// </summary>
            /// <param name="PlayerInstance">The Media Player</param>
            /// <returns>1 if playing, 0 if not</returns>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static Int32 libvlc_media_player_is_playing(IntPtr PlayerInstance);

            /// <summary>
            /// Start the media player.
            /// </summary>
            /// <param name="PlayerInstance">The Media Player</param>
            /// <returns>0 if playback started (and was already started), or -1 on error</returns>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static Int32 libvlc_media_player_play(IntPtr PlayerInstance);

            /// <summary>
            /// Pause or resume (no effect if there is no media)
            /// </summary>
            /// <param name="PlayerInstance">The Media Player</param>
            /// <param name="DoPause">Play/resume if zero, pause if non-zero</param>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static void libvlc_media_player_set_pause(IntPtr PlayerInstance, Int32 DoPause);

            /// <summary>
            /// Toggle pause (no effect if there is no media)
            /// </summary>
            /// <param name="PlayerInstance">The Media Player</param>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static void libvlc_media_player_pause(IntPtr PlayerInstance);

            /// <summary>
            /// Stop (no effect if there is no media)
            /// </summary>
            /// <param name="PlayerInstance">The Media Player</param>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static void libvlc_media_player_stop(IntPtr PlayerInstance);

            // -FLAG-TODO
            // (Quite alot of functions to implement)

            /// <summary>
            /// Get current movie state
            /// </summary>
            /// <param name="PlayerInstance">The Media Player</param>
            /// <see cref="libvlc_state_t"/>
            /// <returns>The current state of the media player (playing, paused, ...)</returns>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static libvlc_state_t libvlc_media_player_get_state(IntPtr PlayerInstance);

            /// <summary>
            /// Set current software audio volume.
            /// </summary>
            /// <param name="PlayerInstance">The Media Player</param>
            /// <param name="Volume">The volume in percents (0 = mute, 100 = 0dB)</param>
            /// <returns>0 if the volume was set, -1 if it was out of range</returns>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static Int32 libvlc_audio_set_volume(IntPtr PlayerInstance, Int32 Volume);

        #endregion

        #region [✓] (✓) List Player

            /// <summary>
            /// Create new Media List Player.
            /// </summary>
            /// <param name="VLCInstance">LibVLC instance</param>
            /// <returns>Media list player instance or NULL on error</returns>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static IntPtr libvlc_media_list_player_new(IntPtr VLCInstance);

            /// <summary>
            /// Release a media_list_player after use
            /// Decrement the reference count of a media player object. If the
            /// reference count is 0, then libvlc_media_list_player_release() will
            /// release the media player object. If the media player object
            /// has been released, then it should not be used again.
            /// </summary>
            /// <param name="ListPlayerInstance">The List Player Instance</param>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static void libvlc_media_list_player_release(IntPtr ListPlayerInstance);

            /// <summary>
            /// Retain a reference to a media player list object. Use
            /// libvlc_media_list_player_release() to decrement reference count.
            /// </summary>
            /// <param name="ListPlayerInstance">The List Player Instance</param>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static void libvlc_media_list_player_retain(IntPtr ListPlayerInstance);

            /// <summary>
            /// Return the event manager of this Media List Player.
            /// </summary>
            /// <param name="ListPlayerInstance">The List Player Instance</param>
            /// <returns>The event manager</returns>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static IntPtr libvlc_media_list_player_event_manager(IntPtr ListPlayerInstance);

            /// <summary>
            /// Replace media player in Media List Player with this instance.
            /// </summary>
            /// <param name="ListPlayerInstance">The List Player Instance</param>
            /// <param name="PlayerInstance">Media player instance</param>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static void libvlc_media_list_player_set_media_player(IntPtr ListPlayerInstance, IntPtr PlayerInstance);

            /// <summary>
            /// Set the media list associated with the player
            /// </summary>
            /// <param name="ListPlayerInstance">The List Player Instance</param>
            /// <param name="MediaList">List of media</param>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static void libvlc_media_list_player_set_media_list(IntPtr ListPlayerInstance, IntPtr MediaList);

            /// <summary>
            /// Play media list
            /// </summary>
            /// <param name="ListPlayerInstance">The List Player Instance</param>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static void libvlc_media_list_player_play(IntPtr ListPlayerInstance);

            /// <summary>
            /// Toggle pause (or resume) media list
            /// </summary>
            /// <param name="ListPlayerInstance">The List Player Instance</param>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static void libvlc_media_list_player_pause(IntPtr ListPlayerInstance);

            /// <summary>
            /// Is media list playing?
            /// </summary>
            /// <param name="ListPlayerInstance">The List Player Instance</param>
            /// <returns>1 if playing, 0 if not</returns>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static Int32 libvlc_media_list_player_is_playing(IntPtr ListPlayerInstance);

            /// <summary>
            /// Get current libvlc_state of media list player
            /// </summary>
            /// <param name="ListPlayerInstance">The List Player Instance</param>
            /// <returns>libvlc_state_t for media list player</returns>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static libvlc_state_t libvlc_media_list_player_get_state(IntPtr ListPlayerInstance);

            /// <summary>
            /// Play media list item at position index
            /// </summary>
            /// <param name="ListPlayerInstance">The List Player Instance</param>
            /// <param name="Index">Index in media list to play</param>
            /// <returns>0 upon success -1 if the item wasn't found</returns>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static Int32 libvlc_media_list_player_play_item_at_index(IntPtr ListPlayerInstance, Int32 Index);

            /// <summary>
            /// Play the given media item
            /// </summary>
            /// <param name="ListPlayerInstance">The List Player Instance</param>
            /// <param name="MediaInstance">The media instance</param>
            /// <returns>0 upon success, -1 if the media is not part of the media list</returns>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static int libvlc_media_list_player_play_item(IntPtr ListPlayerInstance, IntPtr MediaInstance);

            /// <summary>
            /// Stop playing media list
            /// </summary>
            /// <param name="ListPlayerInstance">The List Player Instance</param>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static void libvlc_media_list_player_stop(IntPtr ListPlayerInstance);

            /// <summary>
            /// Play next item from media list
            /// </summary>
            /// <param name="ListPlayerInstance">The List Player Instance</param>
            /// <returns>0 upon success -1 if there is no next item</returns>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static Int32 libvlc_media_list_player_next(IntPtr ListPlayerInstance);

            /// <summary>
            /// Play previous item from media list
            /// </summary>
            /// <param name="ListPlayerInstance">The List Player Instance</param>
            /// <returns>0 upon success -1 if there is no previous item</returns>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static Int32 libvlc_media_list_player_previous(IntPtr ListPlayerInstance);

            /// <summary>
            /// Sets the playback mode for the playlist
            /// </summary>
            /// <param name="ListPlayerInstance">The List Player Instance</param>
            /// <param name="Mode">Playback mode specification</param>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static void libvlc_media_list_player_set_playback_mode(IntPtr ListPlayerInstance, libvlc_playback_mode_t Mode);

        #endregion

        #region [✓] (✓) Discoverer

            /// <summary>
            /// Discover media service by name.
            /// </summary>
            /// <param name="VLCInstance">LibVLC instance</param>
            /// <param name="Name">service name</param>
            /// <returns>Media discover object or NULL in case of error</returns>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static IntPtr libvlc_media_discoverer_new_from_name(IntPtr VLCInstance, IntPtr Name);

            /// <summary>
            /// Release media discover object. If the reference count reaches 0, then
            /// the object will be released.
            /// </summary>
            /// <param name="DiscoverInstance">Media service discover object</param>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static void libvlc_media_discoverer_release(IntPtr DiscoverInstance);

            /// <summary>
            /// Get media service discover object its localized name.
            /// </summary>
            /// <param name="DiscoverInstance">Media service discover object</param>
            /// <returns>Localized name</returns>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static IntPtr libvlc_media_discoverer_localized_name(IntPtr DiscoverInstance);

            /// <summary>
            /// Get media service discover media list.
            /// </summary>
            /// <param name="DiscoverInstance">Media service discover object</param>
            /// <returns>List of media items</returns>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static IntPtr libvlc_media_discoverer_media_list(IntPtr DiscoverInstance);

            /// <summary>
            /// Get event manager from media service discover object.
            /// </summary>
            /// <param name="DiscoverInstance">Media service discover object</param>
            /// <returns>Event manager object</returns>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static IntPtr libvlc_media_discoverer_event_manager(IntPtr DiscoverInstance);

            /// <summary>
            /// Query if media service discover object is running.
            /// </summary>
            /// <param name="DiscoverInstance">Media service discover object</param>
            /// <returns>Return 1 if running, 0 if not</returns>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static Int32 libvlc_media_discoverer_is_running(IntPtr DiscoverInstance);

        #endregion

        #region [✓] (✓) Library

            /// <summary>
            /// Create an new Media Library object
            /// </summary>
            /// <param name="VLCInstance">The LibVLC instance</param>
            /// <returns>A new object or NULL on error</returns>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static IntPtr libvlc_media_library_new(IntPtr VLCInstance);

            /// <summary>
            /// Release media library object. This functions decrements the
            /// reference count of the media library object. If it reaches 0,
            /// then the object will be released.
            /// </summary>
            /// <param name="MediaLibInstance">Media library object</param>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static void libvlc_media_library_release(IntPtr MediaLibInstance);

            /// <summary>
            /// Retain a reference to a media library object. This function will
            /// increment the reference counting for this object. Use
            /// libvlc_media_library_release() to decrement the reference count.
            /// </summary>
            /// <param name="MediaLibInstance">Media library object</param>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static void libvlc_media_library_retain(IntPtr MediaLibInstance);

            /// <summary>
            /// Load media library.
            /// </summary>
            /// <param name="MediaLibInstance">Media library object</param>
            /// <returns>0 on success, -1 on error</returns>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static Int32 libvlc_media_library_load(IntPtr MediaLibInstance);

            /// <summary>
            /// Get media library subitems.
            /// </summary>
            /// <param name="MediaLibInstance">Media library object</param>
            /// <returns>Media list subitems</returns>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static IntPtr libvlc_media_library_media_list(IntPtr MediaLibInstance);

        #endregion

        #region [✓] (✓) Time

            /// <summary>
            /// Return the current time as defined by LibVLC. The unit is the microsecond.
            /// Time increases monotonically (regardless of time zone changes and RTC
            /// adjustements).
            /// The origin is arbitrary but consistent across the whole system
            /// (e.g. the system uptim, the time since the system was booted).
            /// </summary>
            /// <remarks>
            /// On systems that support it, the POSIX monotonic clock is used.
            /// </remarks>
            /// <returns>>Current time defined by LibVLC</returns>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static Int64 libvlc_clock();

            /// <summary>
            /// Return the delay (in microseconds) until a certain timestamp.
            /// </summary>
            /// <param name="Timestamp">Timestamp to compare to</param>
            /// <returns>Negative if timestamp is in the past, positive if it is in the future</returns>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            public extern static Int64 libvlc_delay(Int64 Timestamp);

        #endregion

        /* -FLAG-TODO
         * VLM also has quite a few functions
         * yet to implement
         */
        #region [Todo] (✓) VLM

            /// <summary>
            /// Release the vlm instance related to the given libvlc_instance_t
            /// </summary>
            /// <param name="Instance">The LibVLC instance</param>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            private extern static void libvlc_vlm_release(IntPtr Instance);

            /// <summary>
            /// Add a broadcast, with one input.
            /// </summary>
            /// <param name="Instance">The LibVLC instance</param>
            /// <param name="Name">The name of the new broadcast</param>
            /// <param name="Input">The input MRL</param>
            /// <param name="Output">The output MRL (the parameter to the "sout" variable)</param>
            /// <param name="NoOptions">Number of additional options</param>
            /// <param name="Options">Additional options</param>
            /// <param name="Enable">Boolean for enabling the new broadcast</param>
            /// <param name="Loop">Should this broadcast be played in loop?</param>
            /// <returns>0 on success, -1 on error</returns>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            private extern static Int32 libvlc_vlm_add_broadcast(
                IntPtr Instance,
                IntPtr Name,
                IntPtr Input,
                IntPtr Output,
                int NoOptions,
                IntPtr Options,
                Boolean Enable,
                Boolean Loop
            );
            
            /// <summary>
            /// Add a vod, with one input.
            /// </summary>
            /// <param name="Instance">The instance</param>
            /// <param name="Name">The name of the new vod media</param>
            /// <param name="Input">The input MRL</param>
            /// <param name="NoOptions">Number of additional options</param>
            /// <param name="Options">Additional options</param>
            /// <param name="Enable">Boolean for enabling the new VOD</param>
            /// <param name="Mux">The muxer of the vod media</param>
            /// <returns>0 on success, -1 on error</returns>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            private extern static Int32 libvlc_vlm_add_vod(
                IntPtr Instance,
                IntPtr Name,
                IntPtr Input,
                int NoOptions,
                IntPtr Options,
                Int32 Enable,
                IntPtr Mux
            );

            /// <summary>
            /// Delete a media (VOD or broadcast).
            /// </summary>
            /// <param name="Instance">The instance</param>
            /// <param name="Name">The media to delete</param>
            /// <returns>0 on success, -1 on error</returns>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            private extern static Int32 libvlc_vlm_del_media(IntPtr Instance, IntPtr Name);

            /// <summary>
            /// Enable or disable a media (VOD or broadcast).
            /// </summary>
            /// <param name="Instance">The instance</param>
            /// <param name="Name">The media to work on</param>
            /// <param name="Enabled">The new status</param>
            /// <returns>0 on success, -1 on error</returns>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            private extern static Int32 libvlc_vlm_set_enabled(IntPtr Instance, IntPtr Name, Int32 Enabled);

            /// <summary>
            /// Set the output for a media.
            /// </summary>
            /// <param name="Instance">The instance</param>
            /// <param name="Name">The media to work on</param>
            /// <param name="Output">The output MRL (the parameter to the "sout" variable)</param>
            /// <returns>0 on success, -1 on error</returns>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            private extern static Int32 libvlc_vlm_set_output(IntPtr Instance, IntPtr Name, IntPtr Output);

            /// <summary>
            /// Set a media's input MRL. This will delete all existing inputs and
            /// add the specified one.
            /// </summary>
            /// <param name="Instance">The instance</param>
            /// <param name="Name">The media to work on</param>
            /// <param name="Input">The input MRL</param>
            /// <returns>0 on success, -1 on error</returns>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            private extern static Int32 libvlc_vlm_set_input(IntPtr Instance, IntPtr Name, IntPtr Input);

            /// <summary>
            /// Add a media's input MRL. This will add the specified one.
            /// </summary>
            /// <param name="Instance">The LibVLC instance</param>
            /// <param name="Name">The media to work on</param>
            /// <param name="InputMRL">The input MRL</param>
            /// <returns>0 on success, -1 on error</returns>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            private extern static Int32 libvlc_vlm_add_input(IntPtr Instance, IntPtr Name, IntPtr InputMRL);
     
            /// <summary>
            /// Set a media's loop status.
            /// </summary>
            /// <param name="Instance">The LibVLC instance</param>
            /// <param name="Name">The media to work on</param>
            /// <param name="Loop">The new status</param>
            /// <returns>0 on success, -1 on error</returns>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            private extern static Int32 libvlc_vlm_set_loop(IntPtr Instance, IntPtr Name, Int32 Loop); 
            
            /// <summary>
            /// 
            /// </summary>
            /// <param name="Instance"></param>
            /// <param name="Name"></param>
            /// <param name="Mux"></param>
            /// <returns></returns>
            [DllImport(vlclibname, CallingConvention = CallingConvention.Cdecl)]
            private extern static Int32 libvlc_vlm_set_mux(IntPtr Instance, IntPtr Name, IntPtr Mux);

        #endregion
    }
}