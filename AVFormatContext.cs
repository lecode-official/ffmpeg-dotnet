
#region Using Directives

using System.Runtime.InteropServices;

#endregion

namespace System.Media.FFmpeg.Interop
{
    /// <summary>
    /// Represents the format I/O context.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct AVFormatContext
    {
        #region Public Fields

        /// <summary>
        /// Contains a class for logging and avoptions. Set by avformat_alloc_context(). Exports (de)muxer private options if they exist.
        /// </summary>
        public IntPtr av_class;

        /// <summary>
        /// Contains the input container format (as a pointer to an <see cref="AVInputFormat"/> struct). Demuxing only, set by avformat_open_input().
        /// </summary>
        public IntPtr iformat;

        /// <summary>
        /// Contains the output container format (as a pointer to an <see cref="AVOutputFormat"/> struct). Muxing only, must be set by the caller before
        /// avformat_write_header().
        /// </summary>
        public IntPtr oformat;

        /// <summary>
        /// Contains format private data. This is an <see cref="AVOptions"/>-enabled struct if and only if
        /// <see cref="iformat.priv_class"/>/<see cref="oformat.priv_class"/> is not <c>null</c>. When muxing it is set by avformat_write_header() and when
        /// demuxing it is set by avformat_open_intput().
        /// </summary>
        public IntPtr priv_data;

        #endregion
    }
}