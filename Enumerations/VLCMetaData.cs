using System;
using VLCInterface.Bridge.Internal.Enumerations;

namespace VLCInterface.Enumerations
{
    enum VLCMetaData
    {
        Title           = libvlc_meta_t.libvlc_meta_Title,
        Artist          = libvlc_meta_t.libvlc_meta_Artist,
        Genre           = libvlc_meta_t.libvlc_meta_Genre,
        Copyright       = libvlc_meta_t.libvlc_meta_Copyright,
        Album           = libvlc_meta_t.libvlc_meta_Album,
        TrackNumber     = libvlc_meta_t.libvlc_meta_TrackNumber,
        Description     = libvlc_meta_t.libvlc_meta_Description,
        Rating          = libvlc_meta_t.libvlc_meta_Rating,
        Date            = libvlc_meta_t.libvlc_meta_Date,
        Setting         = libvlc_meta_t.libvlc_meta_Setting,
        URL             = libvlc_meta_t.libvlc_meta_URL,
        Language        = libvlc_meta_t.libvlc_meta_Language,
        NowPlaying      = libvlc_meta_t.libvlc_meta_NowPlaying,
        Publisher       = libvlc_meta_t.libvlc_meta_Publisher,
        EncodedBy       = libvlc_meta_t.libvlc_meta_EncodedBy,
        ArtworkURL      = libvlc_meta_t.libvlc_meta_ArtworkURL,
        TrackID         = libvlc_meta_t.libvlc_meta_TrackID,
        TrackTotal      = libvlc_meta_t.libvlc_meta_TrackTotal,
        Director        = libvlc_meta_t.libvlc_meta_Director,
        Season          = libvlc_meta_t.libvlc_meta_Season,
        Episode         = libvlc_meta_t.libvlc_meta_Episode,
        ShowName        = libvlc_meta_t.libvlc_meta_ShowName,
        Actors          = libvlc_meta_t.libvlc_meta_Actors
    }
}
