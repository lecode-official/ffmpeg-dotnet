
#region Using Directives

using System;
using System.Runtime.InteropServices;

#endregion

namespace FFmpeg.Codecs
{
	/// <summary>
	/// Represents a simple PInvoke wrapper aroung the libavcodec library of the FFmpeg project.
	/// </summary>
    public class LibAVCodec
    {
        #region Public Methods
        
        /// <summary>
        /// Retrieves the version of the libavcodec library.
        /// </summary>
        /// <returns>Returns the version of the libavcodec library.</returns>
        [DllImport(Libraries.AVCodec)]
        public static extern uint avcodec_version();

        /**
        * Find a registered decoder with a matching codec ID.
        *
        * @param id AVCodecID of the requested decoder
        * @return A decoder if one was found, NULL otherwise.
        */

        /// <summary>
        /// Finds a registered decoder with a matching codec ID.
        /// </summary>
        /// <param name="id">The ID of the requested decoder.</param>
        /// <returns>Returns a pointer to the decoder (of the type <see cref="AVCodec"/>) and <c>IntPtr.Zero</c> otherwise.</returns>
        [DllImport(Libraries.AVCodec)]
        public static extern IntPtr avcodec_find_decoder(AVCodecID id);

        /// <summary>
        /// Initialize the <see cref="AVCodecContext"/> to use the given <see cref="AVCodec"/>. Prior to using this function the context has to be allocated
        /// with avcodec_alloc_context3(). The functions avcodec_find_decoder_by_name(), avcodec_find_encoder_by_name(), avcodec_find_decoder() and
        /// avcodec_find_encoder() provide an easy way for retrieving a codec. Warning, this function is not thread safe. Note, Always call this function
        /// before using decoding routines (such as avcodec_receive_frame()).
        /// </summary>
        /// <param name="avctx">A pointer to the <see cref="AVCodecContext"/> context to initialize.</param>
        /// <param name="codec">
        /// A pointer to the codec to open this context for. If a non-<c>null</c> codec has been previously passed to avcodec_alloc_context3() or for this
        /// context, then this parameter MUST be either <c>IntPtr.Zero</c> or equal to the previously passed codec.
        /// </param>
        /// <param name="options">
        /// A dictionary filled with AVCodecContext and codec-private options. On return this object will be filled with options thatwere not found.
        /// </param>
        /// <returns>Returns 0 when successful and a negative value on error.</returns>
        [DllImport(Libraries.AVCodec)]
        public static extern int avcodec_open2(IntPtr avctx, IntPtr codec, IntPtr options);

        #endregion 
    }
}
