
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
            this.CodecContext = new CodecContext(this.InternalStream.codec);
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
        public CodecContext CodecContext { get; private set; }

        #endregion
        
        #region Public Methods
        
        /// <summary>
        /// Gets the codec for this stream.
        /// </summary>
        /// <exception cref="InvalidOperationException">If the codec for this stream is not supported or could not be opened, then an <see cref="InvalidOperationException"/> exception is thrown.</exception>
        /// <returns>Returns the codec for this stream.</returns>
        public Task<Codec> GetCodecAsync()
        {
            // Starts a new backgroud task, which finds and opens the codec for the stream
            return Task.Run(() =>
            { 
                // Finds the decoder for the video stream
                IntPtr codecPointer = LibAVCodec.avcodec_find_decoder(this.CodecContext.InternalCodecContext.codec_id);
                if (codecPointer == IntPtr.Zero)
                    throw new InvalidOperationException("The codec is not supported.");

                // Opens the codec for the video stream
                if (LibAVCodec.avcodec_open2(this.InternalStream.codec, codecPointer, IntPtr.Zero) < 0)
                    throw new InvalidOperationException("The codec {videoCodec.long_name} could not be opened.");

                // Creates the codec and returns it
                return new Codec(codecPointer);
            });
        }
        
        #endregion
    }
}