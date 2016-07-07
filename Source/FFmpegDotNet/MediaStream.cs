
#region Using

using FFmpegDotNet.Interop.Formats;
using System;
using System.Runtime.InteropServices;

#endregion

namespace FFmpegDotNet
{
    /// <summary>
    /// Represents a single stream within a format context.
    /// </summary>
    public class MediaStream
    {
        #region Constructoars

        /// <summary>
        /// Initializes a new <see cref="MediaStream"/> instance.
        /// </summary>
        /// <param name="streamPointer">The pointer to the internal FFmpeg stream structure.</param>
        internal MediaStream(IntPtr streamPointer)
        {
            // Stores the pointer ot the internal FFmpeg stream structure for later use
            this.StreamPointer = streamPointer;

            // Converts the internal FFmpeg stream and codec context structures to a managed structures and stores them for later use
            this.InternalStream = Marshal.PtrToStructure<AVStream>(this.StreamPointer);
            this.Codec = new CodecContext(this.InternalStream.codec);
        }

        #endregion

        #region Internal Properties

        /// <summary>
        /// Gets a pointer to the internal FFmpeg stream structure.
        /// </summary>
        internal IntPtr StreamPointer { get; private set; }

        /// <summary>
        /// Gets the internal FFmpeg stream converted to a managed structure.
        /// </summary>
        internal AVStream InternalStream { get; private set; }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the codec context for the codec, that can be used to decode this stream.
        /// </summary>
        public CodecContext Codec { get; private set; }

        #endregion
    }
}