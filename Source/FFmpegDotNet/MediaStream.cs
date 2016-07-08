
#region Using

using FFmpegDotNet.Interop.Formats;
using FFmpegDotNet.Interop.Codecs;
using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

#endregion

namespace FFmpegDotNet
{
    /// <summary>
    /// Represents a single stream within a format context.
    /// </summary>
    public class MediaStream
    {
        #region Constructors

        /// <summary>
        /// Initializes a new <see cref="MediaStream"/> instance.
        /// </summary>
        /// <param name="streamPointer">The pointer to the internal FFmpeg stream structure.</param>
        internal MediaStream(IntPtr streamPointer)
        {
            // Stores the pointer ot the internal FFmpeg stream structure for later use
            this.StreamPointer = streamPointer;

            // Converts the internal FFmpeg stream to a managed structures and stores it for later use
            this.InternalStream = Marshal.PtrToStructure<AVStream>(this.StreamPointer);
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
        public CodecContext CodecContext { get; internal set; }

        #endregion
    }
}