
#region Using Directives

using System;
using System.Runtime.InteropServices;
using FFmpeg.Utilities;

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

        /// <summary>
        /// Closes a given AVCodecContext and free all the data associated with it (but not the <see cref="AVCodecContext"/> itself). Calling this function
        /// on an <see cref="AVCodecContext"/> that hasn't been opened will free the codec-specific data allocated in avcodec_alloc_context3() with a
        /// non-<c>null</c> codec. Subsequent calls will do nothing. Note, that you should not use this function. Use avcodec_free_context() to destroy a
        /// codec context (either open or closed). Opening and closing a codec context multiple times is not supported anymore - use multiple codec contexts
        /// instead.
        /// </summary>
        /// <param name="avctx">The pointer to the <see cref="AVCodecContext"/> that is to be closed.</param>
        /// <returns>Returns 0 if succesful and a negative value otherwise.</returns>
        [DllImport(Libraries.AVCodec)]
        public static extern int avcodec_close(IntPtr avctx);

        /// <summary>
        /// Gets the size of a picture given its resolution and pixel format.
        /// </summary>
        /// <param name="pix_fmt">The pixel format of the picture.</param>
        /// <param name="width">The width of the picture.</param>
        /// <param name="height">the height of the picture.</param>
        /// <returns>Returns the size of the picture in bytes.</returns>
        [DllImport(Libraries.AVCodec)]
        public static extern int avpicture_get_size(AVPixelFormat pix_fmt, int width, int height);

        /// <summary>
        /// Fills the picture.
        /// </summary>
        /// <param name="picture">The picture.</param>
        /// <param name="ptr">A pointer to the buffer.</param>
        /// <param name="pix_fmt">The pixel format.</param>
        /// <param name="width">The width of the picture.</param>
        /// <param name="height">the height of the picture.</param>
        /// <returns></returns>
        [DllImport(Libraries.AVCodec)]
        public static extern int avpicture_fill(IntPtr picture, IntPtr ptr, AVPixelFormat pix_fmt, int width, int height);

        /// <summary>
        /// Fress a packet.
        /// </summary>
        /// <param name="pkt">A pointer to the <see cref="AVPacket"/> that is to be freed.</param>
        [DllImport(Libraries.AVCodec)]
        public static extern void av_free_packet(IntPtr pkt);

        /// <summary>
        /// Decodes the video frame of size avpkt->size from avpkt->data into picture. Some decoders may support multiple frames in a single AVPacket, such
        /// decoders would then just decode the first frame. Note, codecs which have the AV_CODEC_CAP_DELAY capability set have a delay between input and
        /// output, these need to be fed with avpkt->data=NULL, avpkt->size=0 at the end to return the remaining frames.
        /// </summary>
        /// <param name="avctx">A pointer to the <see cref="AVCodecContext"/>.</param>
        /// <param name="picture">
        /// The <see cref="AVFrame"/> in which the decoded video frame will be stored. Use av_frame_alloc() to get an AVFrame. The codec will allocate memory
        /// for the actual bitmap by calling the AVCodecContext.get_buffer2() callback. When AVCodecContext.refcounted_frames is set to 1, the frame is
        /// reference counted and the returned reference belongs to the caller. The caller must release the frame using av_frame_unref() when the frame is
        /// no longer needed. The caller may safely write to the frame if av_frame_is_writable() returns 1. When AVCodecContext.refcounted_frames is set to
        /// 0, the returned reference belongs to the decoder and is valid only until the next call to this function or until closing or flushing the decoder.
        /// The caller may not write to it.
        /// </param>
        /// <param name="got_picture_ptr">Zero if no frame could be decompressed, otherwise, it is nonzero.</param>
        /// <param name="avpkt">
        /// The input AVPacket containing the input buffer. You can create such packet with av_init_packet() and by then setting data and size, some decoders
        /// might in addition need other fields like flags & AV_PKT_FLAG_KEY. All decoders are designed to use the least fields possible.
        /// </param>
        /// <returns>Returns the number of byets used or zero if no frame could be decompressed. On error a negative value is returned.</returns>
        [DllImport(Libraries.AVCodec)]
        public static extern int avcodec_decode_video2(IntPtr avctx, IntPtr picture, ref int got_picture_ptr, IntPtr avpkt);

        #endregion 
    }
}
