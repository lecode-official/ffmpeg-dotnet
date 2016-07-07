
namespace FFmpegDotNet.Interop.Utilities
{
    /// <summary>
    /// Represents an enumeration for the different media types that can be supported by codecs.
    /// </summary>
    public enum AVMediaType
    {
        /// <summary>
        /// Usually treated as AVMEDIA_TYPE_DATA.
        /// </summary>
        AVMEDIA_TYPE_UNKNOWN = -1,

        /// <summary>
        /// The media type is video.
        /// </summary>
        AVMEDIA_TYPE_VIDEO,

        /// <summary>
        /// The media type is audio.
        /// </summary>
        AVMEDIA_TYPE_AUDIO,

        /// <summary>
        /// Opaque data information usually continuous.
        /// </summary>
        AVMEDIA_TYPE_DATA,

        /// <summary>
        /// The media type is subtitle.
        /// </summary>
        AVMEDIA_TYPE_SUBTITLE,

        /// <summary>
        /// Opaque data information usually sparse.
        /// </summary>
        AVMEDIA_TYPE_ATTACHMENT,

        AVMEDIA_TYPE_NB
    }
}