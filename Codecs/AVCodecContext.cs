
#region Using Directives

using System;
using System.Runtime.InteropServices;
using FFmpeg.Utilities;

#endregion

namespace FFmpeg.Codecs
{
    /// <summary>
    /// Represents the codec context, which is a main external API structure. Please use AVOptions (av_opt* / av_set/get*()) to access these fields from user
    /// applications.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct AVCodecContext
    {
        #region Public Fields

        /// <summary>
        /// Contains the information on the structure for av_log. This is set by avcodec_alloc_context3.
        /// </summary>
        public IntPtr av_class;

        /// <summary>
        /// Contains the log level offset.
        /// </summary>
        public int log_level_offset;

        /// <summary>
        /// Contains the media type of the codec.
        /// </summary>
    	public AVMediaType codec_type;

        /// <summary>
        /// Contains a pointer to the codec (of type <see cref="AVCodec"/>).
        /// </summary>
        public IntPtr codec;
        
        /// <summary>
        /// Contains teh name of the codec.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string codec_name;
    
        /// <summary>
        /// Contains the ID of the codec.
        /// </summary>
        public AVCodecID codec_id;

        /// <summary>
        /// Contains the fourcc (LSB first, so "ABCD" -> ('D' << 24) + ('C' << 16) + ('B' << 8) + 'A'). This is used to work around some encoder bugs. A
        /// demuxer should set this to what is stored in the field used to identify the codec. If there are multiple such fields in a container then the
        /// demuxer should choose the one which maximizes the information about the used codec. If the codec tag field in a container is larger than 32
        /// bits then the demuxer should remap the longer ID to 32 bits with a table or other structure. Alternatively a new extra_codec_tag + size could
        /// be added but for this a clear advantage must be demonstrated first. When encoding this is set by the suer, if not then the default based on
        /// codec_id will be used. When decoding this is set by the user and will be converted to uppercase by libavcodec during init.
        /// </summary>
        public uint codec_tag;

        /// <summary>
        /// Contains the stream codec tag.
        /// </summary>
        public uint stream_codec_tag;

        /// <summary>
        /// Contains format private data.
        /// </summary>
        public IntPtr priv_data;

        /// <summary>
        /// Contains private context used for intrenal data. Unlike priv_data, this is not codec-specific. It is used in general libavcodec functions.
        /// </summary>
        public IntPtr @internal;

        /// <summary>
        /// Contains private data of the user and can be used to carry application specific stuff.
        /// </summary>
        public IntPtr opaque;

        /// <summary>
        /// Contains the average bitrate. When encoding this is set by the user and remains unused for constant quantizer encoding. For decoding this is set
        /// by the user but may be overwritten by libavcodec if this info is available in the stream.
        /// </summary>
        public long bit_rate;

        /// <summary>
        /// Contains the number of bits the bitstream is allowed to diverge from the reference. the reference can be CBR (for CBR pass1) or VBR (for pass2).
        /// When encoding this is set by the user and remains unused for constant quatizer encoding. This is unused when decoding.
        /// </summary>
        public int bit_rate_tolerance;

        /// <summary>
        /// Contains global quality for codecs which cannot change it per frame. This should be proportional to MPEG-1/2/4 qscale. When encoding this is set
        /// by the user. This is unused when decoding.
        /// </summary>
        public int global_quality;

        /// <summary>
        /// Contains the compression level. When encoding this is set yb teh user. This is unused when decoding.
        /// </summary>
        public int compression_level;

        /// <summary>
        /// Contains AV_CODEC_FLAG_* flags. When encoding as well as decoding this is set by the user.
        /// </summary>
        public int flags;

        /// <summary>
        /// Contains AV_CODEC_FLAG2_* flags. When encoding as well as decoding this is set by the user.
        /// </summary>
        public int flags2;

        /// <summary>
        /// Contains extra data. Some codecs need/can use extradata like Huffman tables: MJPEG: Huffman tables, rv10: additional flags, MPEG-4: global
        /// headers (they can be in the bitstream or here). The allocated memory should be AV_INPUT_BUFFER_PADDING_SIZE bytes larger than extradata_size to
        /// avoid problems if it is read with the bitstream reader. The bytewise contents of extradata must not depend on the architecture or CPU endianness.
        /// When encoding this is set/allocated/freed by libavcodec. When decodnig this is set/allocated/freed by the user.
        /// </summary>
        public IntPtr extradata;

        /// <summary>
        /// Contains the size of the extra data.
        /// </summary>
        public int extradata_size;

        #endregion
    }
}