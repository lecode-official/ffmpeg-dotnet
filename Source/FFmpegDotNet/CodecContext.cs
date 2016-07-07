
#region Using

using System;
using System.Runtime.InteropServices;
using FFmpegDotNet.Interop.Codecs;

#endregion

namespace FFmpegDotNet
{
    /// <summary>
    /// /// Represents the codec context, which is a main external API structure. Please use AVOptions (av_opt* / av_set/get*()) to access these fields from user
    /// applications.
    /// </summary>
    public class CodecContext
    {
        #region Constructoars

        /// <summary>
        /// Initializes a new <see cref="CodecContext"/> instance.
        /// </summary>
        /// <param name="codecContextPointer">The pointer to the internal FFmpeg codec context structure.</param>
        internal CodecContext(IntPtr codecContextPointer)
        {
            // Stores the pointer ot the internal FFmpeg codec context structure for later use
            this.CodecContextPointer = codecContextPointer;

            // Converts the internal FFmpeg codec context structure to a managed structure and stores it for later use
            this.InternalCodecContext = Marshal.PtrToStructure<AVCodecContext>(this.CodecContextPointer);
        }

        #endregion

        #region Internal Properties

        /// <summary>
        /// Gets a pointer to the internal FFmpeg codec context structure.
        /// </summary>
        internal IntPtr CodecContextPointer { get; private set; }

        /// <summary>
        /// Gets the internal FFmpeg codec context converted to a managed structure.
        /// </summary>
        internal AVCodecContext InternalCodecContext { get; private set; }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the type of media that is encoded/decoded by this is codec.
        /// </summary>
        /// <returns></returns>
        public MediaType MediaType
        {
            get
            {
                return (MediaType)this.InternalCodecContext.codec_type;
            }
        }

        #endregion
    }
}