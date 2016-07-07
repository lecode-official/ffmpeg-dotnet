
#region Using Directives

using System;
using System.Runtime.InteropServices;

#endregion

namespace FFmpegDotNet.Interop.Utilities
{
    /// <summary>
    /// Represents a structure describes decoded (raw) audio or video data. AVFrame must be allocated using av_frame_alloc(). Note that this only allocates
    /// the AVFrame itself, the buffers for the data must be managed through other means (see below). <see cref="AVFrame"/> must be freed
    /// with av_frame_free(). AVFrame is typically allocated once and then reused multiple times to hold different data (e.g. a single AVFrame to hold frames
    /// received from a decoder). In such a case, av_frame_unref() will free any references held by the frame and reset it to its original clean state before
    /// it is reused again. Fields can be accessed through AVOptions, the name string used, matches the C structure field name for fields accessable through
    /// <see cref="AVOptions"/>. The <see cref="AVClass"/> for <see cref="AVFrame"/> can be obtained from avcodec_get_frame_class()
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct AVFrame
    {
        #region Public Fields

        /// <summary>
        /// Contains a pointer to the picture/channel planes. This might be different from the first allocated byte Some decoders access areas outside 0,0 -
        /// width,height, please see avcodec_align_dimensions2(). Some filters and swscale can read up to 16 bytes beyond the planes, if these filters are to
        /// be used, then 16 extra bytes must be allocated. Note, except for hwaccel formats, pointers not needed by the format MUST be set to
        /// <c>IntPtr.Zero</c>.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public IntPtr[] data;

        /// <summary>
        /// Contains the size in bytes of each picture line for video and the size in bytes of each plane for audio. For audio, only linesize[0] may be set.
        /// For planar audio, each channel plane must be the same size. For video the linesizes should be multiples of the CPUs alignment preference, this is
        /// 16 or 32 for modern desktop CPUs. Some code requires such alignment other code can be slower without correct alignment, for yet other it makes no
        /// difference. Nothe, the tinesize may be larger than the size of usable data - there may be extra padding present for performance reasons.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public int[] linesize;

        /// <summary>
        /// Contains to the data planes/channels. For video, this should simply point to data[]. For planar audio, each channel has a separate data pointer, and
        /// linesize[0] contains the size of each channel buffer. For packed audio, there is just one data pointer, and linesize[0] contains the total size of
        /// the buffer for all channels. Note, both data and extended_data should always be set in a valid frame, but for planar audio with more channels that
        /// can fit in data, extended_data must be used in order to access all channels.
        /// </summary>
        public IntPtr extended_data;

        /// <summary>
        /// Contains the width of the video frame.
        /// </summary>
        public int width;

        /// <summary>
        /// Contains the height of the video frame.
        /// </summary>
        public int height;

        /// <summary>
        /// Contains the number of audio samples (per channel) described by this frame.
        /// </summary>
        public int nb_samples;

        /// <summary>
        /// Contains the format of the frame, -1 if unknown or unset. Values correspond to enum AVPixelFormat for video frames, enum AVSampleFormat for audio).
        /// </summary>
        public int format;

        /// <summary>
        /// Contains a value that determines whether this is a keyframe, 1 -> keyframe, 0 -> not.
        /// </summary>
        public int key_frame;

        /// <summary>
        /// Contains the picture type of the frame.
        /// </summary>
        public AVPictureType pict_type;

        /// <summary>
        /// Contains the sample aspect ratio for the video frame, 0/1 if unknown/unspecified.
        /// </summary>
        public AVRational sample_aspect_ratio;

        /// <summary>
        /// Contains the presentation timestamp in time_base units (time when frame should be shown to user).
        /// </summary>
        public long pts;

        /// <summary>
        /// Contains the PTS copied from the <see cref="AVPacket"/> that was decoded to produce this frame.
        /// </summary>
        public long pkt_pts;

        /// <summary>
        /// Contains the DTS copied from the <see cref="AVPacket"/> that triggered returning this frame (if frame threading isn't used). This is also the
        /// presentation time of this AVFrame calculated from only AVPacket.dts values without pts values.
        /// </summary>
        public long pkt_dts;

        /// <summary>
        /// Contains the picture number in bitstream order.
        /// </summary>
        public int coded_picture_number;

        /// <summary>
        /// Contains the picture number in display order.
        /// </summary>
        public int display_picture_number;

        /// <summary>
        /// Contains the quality between 1 (good) and FF_LAMBDA_MAX (bad).
        /// </summary>
        public int quality;

        /// <summary>
        /// Contains a pointer for some private data of the user.
        /// </summary>
        public IntPtr opaque;

        /// <summary>
        /// Contains an error array.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public long[] error;

        /// <summary>
        /// Contains a value that, when decoding, signals how much the picture must be delayed: extra_delay = repeat_pict / (2 * fps).
        /// </summary>
        public int repeat_pict;

        /// <summary>
        /// Contains the content of the picture is interlaced.
        /// </summary>
        public int interlaced_frame;

        /// <summary>
        /// Contains if the content is interlaced, is top field displayed first.
        /// </summary>
        public int top_field_first;

        /// <summary>
        /// Contains a value that tells user applications that the palette has changed from previous frame.
        /// </summary>
        public int palette_has_changed;

        /// <summary>
        /// Contains the reordered opaque 64 bits (generally an integer or a double precision float PTS but can be anything). The user sets
        /// AVCodecContext.reordered_opaque to represent the input at that time, the decoder reorders values as needed and sets AVFrame.reordered_opaque
        /// to exactly one of the values provided by the user through AVCodecContext.reordered_opaque.
        /// </summary>
        public long reordered_opaque;

        /// <summary>
        /// Contains teh sample rate of the audio data.
        /// </summary>
        public int sample_rate;

        /// <summary>
        /// Contains the channel layout of the audio data.
        /// </summary>
        public long channel_layout;

        /// <summary>
        /// Contains the <see creaf="AVBuffer"/> references backing the data for this frame. If all elements of this array are NULL, then this frame is not
        /// reference counted. This array must be filled contiguously -- if buf[i] is non-NULL then buf[j] must also be non-NULL for all j < i. There may be
        /// at most one AVBuffer per data plane, so for video this array always contains all the references. For planar audio with more than
        /// AV_NUM_DATA_POINTERS channels, there may be more buffers than can fit in this array. Then the extra AVBufferRef pointers are stored in the
        /// extended_buf array.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public IntPtr[] buf;

        /// <summary>
        /// Contains an array, that, for planar audio which requires more than AV_NUM_DATA_POINTERS AVBufferRef pointers, will hold all the references which
        /// cannot fit into AVFrame.buf. Note, that this is different from AVFrame.extended_data, which always contains all the pointers. This array only
        /// contains the extra pointers, which cannot fit into AVFrame.buf. This array is always allocated using av_malloc() by whoever constructs the frame.
        /// It is freed in av_frame_unref().
        /// </summary>
        public IntPtr extended_buf;

        /// <summary>
        /// Contains the number of elements in extended_buf.
        /// </summary>
        public int nb_extended_buf;

        /// <summary>
        /// Contains side data.
        /// </summary>
        public IntPtr side_data;

        /// <summary>
        /// Contains the number of elements in the side data.
        /// </summary>
        public int nb_side_data;

        /// <summary>
        /// Contains frame flags, a combination of @ref lavu_frame_flags.
        /// </summary>
        public int flags;

        /// <summary>
        /// Contains the MPEG vs JPEG YUV color range. It must be accessed using av_frame_get_color_range() and av_frame_set_color_range(). When encoding
        /// this is set by the user. When decoding this is set by libavcodec.
        /// </summary>
        public AVColorRange color_range;

        /// <summary>
        /// Contains the color primaries.
        /// </summary>
        public AVColorPrimaries color_primaries;

        /// <summary>
        /// Contains the color transfer characteristic.
        /// </summary>
        public AVColorTransferCharacteristic color_trc;

        /// <summary>
        /// Contains the YUV colorspace type. It must be accessed using av_frame_get_colorspace() and av_frame_set_colorspace(). When encoding this is set
        /// by the user. When decoding this is set by libavcodec.
        /// </summary>
        public AVColorSpace colorspace;

        /// <summary>
        /// Contains the chroma location.
        /// </summary>
        public AVChromaLocation chroma_location;

        /// <summary>
        /// Contains the frame timestamp estimated using various heuristics, in stream time base. Code outside libavutil should access this field using:
        /// av_frame_get_best_effort_timestamp(frame). When encoding this is unused. When decoding this is set by the libavcodec and can be read by the user.
        /// </summary>
        public long best_effort_timestamp;

        /// <summary>
        /// Contains the reordered pos from the last AVPacket that has been input into the decoder. Code outside libavutil should access this field using:
        /// av_frame_get_pkt_pos(frame). When encoding this is unused. When decoding this can be read by the user.
        /// </summary>
        public long pkt_pos;

        /// <summary>
        /// Contains the duration of the corresponding packet, expressed in AVStream->time_base units, 0 if unknown. Code outside libavutil should access
        /// this field using: av_frame_get_pkt_duration(frame). When encoding this is unused. When decoding this can be read by the user.
        /// </summary>
        public long pkt_duration;

        /// <summary>
        /// Contains a pointer to metadata. Code outside libavutil should access this field using: av_frame_get_metadata(frame). When encoding this is set
        /// by the user. When decoding this is set by libavcodec.
        /// </summary>
        public IntPtr metadata;

        /// <summary>
        /// Contains the decode error flags of the frame, set to a combination of FF_DECODE_ERROR_xxx flags if the decoder produced a frame, but there were
        /// errors during the decoding. Code outside libavutil should access this field using: av_frame_get_decode_error_flags(frame). When encoding this is
        /// unused. When decoding, this is set by libavcodec and can be read by the user.
        /// </summary>
        public int decode_error_flags;

        /// <summary>
        /// Contains the number of audio channels, only used for audio. Code outside libavutil should access this field using: av_frame_get_channels(frame).
        /// When encoding this is unused. When decoding this can be read by the user.
        /// </summary>
        public int channels;

        /// <summary>
        /// Contains the size of the corresponding packet containing the compressed frame. It must be accessed using av_frame_get_pkt_size() and
        /// av_frame_set_pkt_size(). It is set to a negative value if unknown. When encoding this is unused. When decoding this is set by libavcodec and can
        /// be read by the user.
        /// </summary>
        public int pkt_size;

        /// <summary>
        /// Contains the QP table. Not to be accessed directly from outside libavutil.
        /// </summary>
        public IntPtr qscale_table;

        /// <summary>
        /// Contains the QP store stride. Not to be accessed directly from outside libavutil.
        /// </summary>
        public int qstride;

        /// <summary>
        /// Contains the QP type. Not to be accessed directly from outside libavutil.
        /// </summary>
        public int qscale_type;

        /// <summary>
        /// Contains the QP table buffer. Not to be accessed directly from outside libavutil.
        /// </summary>
        public IntPtr qp_table_buf;

        /// <summary>
        /// Contains a reference to the AVHWFramesContext describing the frame, for hwaccel-format frames.
        /// </summary>
        public IntPtr hw_frames_ctx;

        #endregion
    }
}