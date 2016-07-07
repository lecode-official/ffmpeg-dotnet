
#region Using Directives

using System;
using System.Runtime.InteropServices;

#endregion

namespace FFmpegDotNet.Interop.Formats
{
    /// <summary>
    /// Represents a single stream within a format context.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct AVStream
    {
        #region Public Fields

        /// <summary>
        /// Contains the stream index in the <see cref="AVFormatContext"/>.
        /// </summary>
        public int index;

        /// <summary>
        /// Contains the format-specific stream ID. When decoding this is set by libavformat. When encoding this is set by the user, but it is being
        /// replaced by libavformat if left unset.
        /// </summary>
        public int id;

        /// <summary>
        /// Contains a pointer to the codec context of the frame.
        /// </summary>
        public IntPtr codec;

        /// <summary>
        /// Contains format private data.
        /// </summary>
        public IntPtr priv_data;

        #endregion
    }
}