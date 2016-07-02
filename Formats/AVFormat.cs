
#region Using Directives

using System.Runtime.InteropServices;

#endregion

namespace System.Media.FFmpeg.Interop.Formats
{
	/// <summary>
	/// Represents a simple PInvoke wrapper aroung the libavformat library of the FFmpeg project.
	/// </summary>
    public class AVFormat
    {
        #region Public Methods
        
        /// <summary>
        /// Initializes libavformat and registers all the muxers, demuxers and protocols.
        /// </summary>
        [DllImport(Libraries.AVFormat)]
        public static extern void av_register_all();

        /// <summary>
        /// Open an input stream and read the header. The codecs are not opened. The stream must be closed with avformat_close_input().
        /// </summary>
        /// <param name="ps"> <summary>
        /// Pointer to the user-supplied AVFormatContext (allocated by avformat_alloc_context). May be a pointer to <c>null</c>, in which case an
        /// <see cref="AVFormatContext"/> is allocated by this function and written into <see cref="ps"/> Note that a user-supplied
        /// <see cref="AVFormatContext"/> will be freed on failure.
        /// </summary>
        /// <param name="url">URL of the stream to open.</param>
        /// <param name="fmt">If non-<c>null</c>, this parameter forces a specific input format. Otherwise the format is autodetected.</param>
        /// <param name="options">
        /// A dictionary filled with <see cref="AVFormatContext"/> and demuxer-private options. On return this parameter will be destroyed and replaced
        /// with a dictionary containing options that were not found. May be <c>null</c>.
        /// </param>
        /// <returns>Returns 0 on success, and a negative AVERROR on failure.</returns>
        [DllImport(Libraries.AVFormat)]
        public static extern int avformat_open_input([Out] out IntPtr ps, [MarshalAs(UnmanagedType.LPStr)] string url, IntPtr fmt, IntPtr options);

        /// <summary>
        /// Close an opened input <see cref="AVFormatContext"/>. Free it and all its contents and set <see cref="s"/> to <c>null</c>.
        /// </summary>
        /// <param name="s">The <see cref="AVFormatContext"/> that is to be closed.</param>
        [DllImport(Libraries.AVFormat)]
        public static extern void avformat_close_input(IntPtr s);

        #endregion
    }
}