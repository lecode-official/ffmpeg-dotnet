
namespace FFmpegDotNet.Interop.Utilities
{
    /// <summary>
    /// Represents an enumeration for MPEG vs JPEG YUV color ranges.
    /// </summary>
    public enum AVColorRange
    {
        /// <summary>
        /// The color range is unspecified.
        /// </summary>
        AVCOL_RANGE_UNSPECIFIED = 0,

        /// <summary>
        /// The normal 219*2^(n-8) "MPEG" YUV ranges.
        /// </summary>
        AVCOL_RANGE_MPEG = 1,

        /// <summary>
        /// The normal 2^n-1 "JPEG" YUV ranges.
        /// </summary>
        AVCOL_RANGE_JPEG = 2,

        /// <summary>
        /// Not part of the ABI.
        /// </summary>
        AVCOL_RANGE_NB
    }
}