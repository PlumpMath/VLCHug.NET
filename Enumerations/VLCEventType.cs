using System;
using VLCInterface.Bridge.Internal.Enumerations;

namespace VLCInterface.Enumerations
{
    public enum VLCEventType
    {
        MediaMetaChanged                = libvlc_event_e.libvlc_MediaMetaChanged,
        MediaSubItemAdded               = libvlc_event_e.libvlc_MediaSubItemAdded,
        MediaDurationChanged            = libvlc_event_e.libvlc_MediaDurationChanged,
        MediaParsedChanged              = libvlc_event_e.libvlc_MediaParsedChanged,
        MediaFreed                      = libvlc_event_e.libvlc_MediaFreed,
        MediaStateChanged               = libvlc_event_e.libvlc_MediaStateChanged,

        MediaPlayerMediaChanged         = libvlc_event_e.libvlc_MediaPlayerMediaChanged,
        MediaPlayerNothingSpecial       = libvlc_event_e.libvlc_MediaPlayerNothingSpecial,
        MediaPlayerOpening              = libvlc_event_e.libvlc_MediaPlayerOpening,
        MediaPlayerBuffering            = libvlc_event_e.libvlc_MediaPlayerBuffering,
        MediaPlayerPlaying              = libvlc_event_e.libvlc_MediaPlayerPlaying,
        MediaPlayerPaused               = libvlc_event_e.libvlc_MediaPlayerPaused,
        MediaPlayerStopped              = libvlc_event_e.libvlc_MediaPlayerStopped,
        MediaPlayerForward              = libvlc_event_e.libvlc_MediaPlayerForward,
        MediaPlayerBackward             = libvlc_event_e.libvlc_MediaPlayerBackward,
        MediaPlayerEndReached           = libvlc_event_e.libvlc_MediaPlayerEndReached,
        MediaPlayerEncounteredError     = libvlc_event_e.libvlc_MediaPlayerEncounteredError,
        MediaPlayerTimeChanged          = libvlc_event_e.libvlc_MediaPlayerTimeChanged,
        MediaPlayerPositionChanged      = libvlc_event_e.libvlc_MediaPlayerPositionChanged,
        MediaPlayerSeekableChanged      = libvlc_event_e.libvlc_MediaPlayerSeekableChanged,
        MediaPlayerPausableChanged      = libvlc_event_e.libvlc_MediaPlayerPausableChanged,
        MediaPlayerTitleChanged         = libvlc_event_e.libvlc_MediaPlayerTitleChanged,
        MediaPlayerSnapshotTaken        = libvlc_event_e.libvlc_MediaPlayerSnapshotTaken,
        MediaPlayerLengthChanged        = libvlc_event_e.libvlc_MediaPlayerLengthChanged,

        MediaListItemAdded              = libvlc_event_e.libvlc_MediaListItemAdded,
        MediaListWillAddItem            = libvlc_event_e.libvlc_MediaListWillAddItem,
        MediaListItemDeleted            = libvlc_event_e.libvlc_MediaListItemDeleted,
        MediaListWillDeleteItem         = libvlc_event_e.libvlc_MediaListWillDeleteItem,

        MediaListViewItemAdded          = libvlc_event_e.libvlc_MediaListViewItemAdded,
        MediaListViewWillAddItem        = libvlc_event_e.libvlc_MediaListViewWillAddItem,
        MediaListViewItemDeleted        = libvlc_event_e.libvlc_MediaListViewItemDeleted,
        MediaListViewWillDeleteItem     = libvlc_event_e.libvlc_MediaListViewWillDeleteItem,

        MediaListPlayerPlayed           = libvlc_event_e.libvlc_MediaListPlayerPlayed,
        MediaListPlayerNextItemSet      = libvlc_event_e.libvlc_MediaListPlayerNextItemSet,
        MediaListPlayerStopped          = libvlc_event_e.libvlc_MediaListPlayerStopped,

        MediaDiscovererStarted          = libvlc_event_e.libvlc_MediaDiscovererStarted,
        MediaDiscovererEnded            = libvlc_event_e.libvlc_MediaDiscovererEnded,

        VlmMediaAdded                   = libvlc_event_e.libvlc_VlmMediaAdded,
        VlmMediaRemoved                 = libvlc_event_e.libvlc_VlmMediaRemoved,
        VlmMediaChanged                 = libvlc_event_e.libvlc_VlmMediaChanged,
        VlmMediaInstanceStarted         = libvlc_event_e.libvlc_VlmMediaInstanceStarted,
        VlmMediaInstanceStopped         = libvlc_event_e.libvlc_VlmMediaInstanceStopped,
        VlmMediaInstanceStatusInit      = libvlc_event_e.libvlc_VlmMediaInstanceStatusInit,
        VlmMediaInstanceStatusOpening   = libvlc_event_e.libvlc_VlmMediaInstanceStatusOpening,
        VlmMediaInstanceStatusPlaying   = libvlc_event_e.libvlc_VlmMediaInstanceStatusPlaying,
        VlmMediaInstanceStatusPause     = libvlc_event_e.libvlc_VlmMediaInstanceStatusPause,
        VlmMediaInstanceStatusEnd       = libvlc_event_e.libvlc_VlmMediaInstanceStatusEnd,
        VlmMediaInstanceStatusError     = libvlc_event_e.libvlc_VlmMediaInstanceStatusError
    }
}
