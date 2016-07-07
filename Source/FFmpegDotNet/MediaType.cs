
namespace FFmpegDotNet
{
    /// <summary>
    /// Represents an enumeration for the different media types that can be supported by codecs.
    /// </summary>
    public enum MediaType
    {
        /// <summary>
        /// The media type is unknow, this is usually treated like <c>MediaType.Data</c>.
        /// </summary>
        Unknown = -1,

        /// <summary>
        /// The media type is video.
        /// </summary>
        Video,

        /// <summary>
        /// The media type is audio.
        /// </summary>
        Audio,

        /// <summary>
        /// Opaque data information usually continuous.
        /// </summary>
        Data,

        /// <summary>
        /// The media type is subtitle.
        /// </summary>
        Subtitle,

        /// <summary>
        /// Opaque data information usually sparse.
        /// </summary>
        Attachment,

        NB
    }
}