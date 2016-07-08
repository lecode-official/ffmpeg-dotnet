
#region Using

using FFmpegDotNet.Interop.Codecs;
using System;
using System.Runtime.InteropServices;

#endregion

namespace FFmpegDotNet
{
    /// <summary>
    /// Represents a codec.
    /// </summary>
    public class Codec
    {
        #region Constructoars

        /// <summary>
        /// Initializes a new <see cref="Codec"/> instance.
        /// </summary>
        /// <param name="codecPointer">The pointer to the internal FFmpeg codec structure.</param>
        internal Codec(IntPtr codecPointer)
        {
            // Stores the pointer ot the internal FFmpeg codec structure for later use
            this.CodecPointer = codecPointer;

            // Converts the internal FFmpeg codec and codec context structures to a managed structures and stores them for later use
            this.InternalCodec = Marshal.PtrToStructure<AVCodec>(this.CodecPointer);
        }

        #endregion

        #region Internal Properties

        /// <summary>
        /// Gets a pointer to the internal FFmpeg codec structure.
        /// </summary>
        internal IntPtr CodecPointer { get; private set; }

        /// <summary>
        /// Gets the internal FFmpeg codec converted to a managed structure.
        /// </summary>
        internal AVCodec InternalCodec { get; private set; }

        #endregion
    }
}