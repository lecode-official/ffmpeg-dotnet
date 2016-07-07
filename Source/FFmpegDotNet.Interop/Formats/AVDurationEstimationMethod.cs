
namespace FFmpegDotNet.Interop.Formats
{
    /// <summary>
    /// The duration of a video can be estimated through various ways, and this enum can be used to know how the duration was estimated.
    /// </summary>
    public enum AVDurationEstimationMethod
    {
        /// <summary>
        /// The duration is accurately estimated from PTSes.
        /// </summary>
        AVFMT_DURATION_FROM_PTS,

        /// <summary>
        /// The duration is estimated from a stream with a known duration.
        /// </summary>
        AVFMT_DURATION_FROM_STREAM,

        /// <summary>
        /// The duration is estimated from bitrate (less accurate) 
        /// </summary>
        AVFMT_DURATION_FROM_BITRATE
    }
}