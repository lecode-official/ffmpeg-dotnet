
#region Using Directives

using FFmpegDotNet.Interop.Codecs;
using System;
using System.Runtime.InteropServices;

#endregion

namespace FFmpegDotNet.Interop.Formats
{
    /// <summary>
    /// Represents the format I/O context.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct AVFormatContext
    {
        #region Public Fields

        /// <summary>
        /// Contains a class for logging and <see cref="avoptions"/>. Set by avformat_alloc_context(). Exports (de)muxer private options if they exist.
        /// </summary>
        public IntPtr av_class;

        /// <summary>
        /// Contains the input container format (as a pointer to an <see cref="AVInputFormat"/> struct). Demuxing only, set by avformat_open_input().
        /// </summary>
        public IntPtr iformat;

        /// <summary>
        /// Contains the output container format (as a pointer to an <see cref="AVOutputFormat"/> struct). Muxing only, must be set by the caller before
        /// avformat_write_header().
        /// </summary>
        public IntPtr oformat;

        /// <summary>
        /// Contains format private data. This is an <see cref="AVOptions"/>-enabled struct if and only if <c>iformat.priv_class</c>/<c>oformat.priv_class</c>
        /// is not <c>null</c>. When muxing it is set by avformat_write_header() and when demuxing it is set by avformat_open_intput().
        /// </summary>
        public IntPtr priv_data;

        /// <summary>
        /// Contains the I/O context (as a pointer to an <see cref="AVIOContext"/> struct). When demuxing it must either be set by the user before
        /// avformat_open_input() (then the user must close it manually) or set by avformat_open_input(). When muxing it must bei set by the user before
        /// avformat_write_header(). The caller must take care of closing/freeing the IO context. Do NOT set this field if AVFMT_NOFILE flag is set in
        /// <c>iformat.flags</c>/<c>oformat.flags</c>. In such a case, the (de)muxer will handle I/O in some other way and this field will be
        /// <c>null</c>.
        /// </summary>
        public IntPtr pb;

        /// <summary>
        /// Contains flags signalling stream properties. A combination of AVFMTCTX_*. Set by libavformat.
        /// </summary>
        public int ctx_flags;

        /// <summary>
        /// Contains the number of elements in <c>AVFormatContext.streams</c>. Set by avformat_new_stream(), must not be modified by any other code.
        /// </summary>
        public uint nb_streams;

        /// <summary>
        /// Contains a pointer to an array of pointers of all streams in the file. New streams are created with avformat_new_stream(). When demuxing the
        /// streams are created by libavformat in avformat_open_input(). If AVFMTCTX_NOHEADER is set in ctx_flags, then new streams may also appear in
        /// av_read_frame(). When muxing the streams are created by the user before avformat_write_header(). Freed by libavformat in avformat_free_context().
        /// </summary>
        public IntPtr streams;

        /// <summary>
        /// Contains the input or output file name. When demuxing the file name is set by avformat_open_input(). When muxing the file name may be set byt the
        /// caller before avformat_write_header().
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
        public string filename;

        /// <summary>
        /// Contains the position of the first frame of the component, in AV_TIME_BASE fractional seconds. NEVER set this value directly: It is deduced from
        /// the AVStream values. The start time is for demuxing only and is set by libavformat.
        /// </summary>
        public long start_time;

        /// <summary>
        /// Contains the duration of the stream, in AV_TIME_BASE fractional seconds. Only set this value if you know none of the individual stream durations
        /// and also do not set any of them. This is deduced from the AVStream values if not set. The duration is for demuxing only and is set by libavformat.
        /// </summary>
        public long duration;

        /// <summary>
        /// Contains the total stream bitrate in bit/s, 0 if not available. Never set it directly if the file_size and the duration are known as FFmpeg can
        /// compute it automatically.
        /// </summary>
        public long bit_rate;

        /// <summary>
        /// Contains the size of the packets.
        /// </summary>
        public uint packet_size;

        /// <summary>
        /// Contains the maximum delay.
        /// </summary>
        public int max_delay;

        /// <summary>
        /// Contains the flags modifying the (de)muxer behaviour. A combination of AVFMT_FLAG_*. Set by the user before
        /// avformat_open_input()/avformat_write_header().
        /// </summary>
        public int flags;

        /// <summary>
        /// Contains the maximum size of the data read from input for determining the input container format. The probe size is for demuxing only and is set
        /// by the caller before avformat_open_input().
        /// </summary>
        public long probesize;

        /// <summary>
        /// Contains the maximum duration (in AV_TIME_BASE units) of the data read from input in avformat_find_stream_info(). The maximum analyze duration
        /// is for demuxing only and is set by the caller before avformat_find_stream_info(). Can be set to 0 to let avformat choose using a heuristic.
        /// </summary>
        public long max_analyze_duration;

        /// <summary>
        /// Contains the key.
        /// </summary>
        public IntPtr key;

        /// <summary>
        /// Contains the length of the key.
        /// </summary>
        public int keylen;

        /// <summary>
        /// Contains the number of programs.
        /// </summary>
        public uint nb_programs;

        /// <summary>
        /// Contains a pointer to an array of pointers to the programs.
        /// </summary>
        public IntPtr programs;

        /// <summary>
        /// Contains forced video codec ID. For demuxing this is set by the user.
        /// </summary>
        public AVCodecID video_codec_id;

        /// <summary>
        /// Contains forced audio codec ID. For demuxing this is set by the user.
        /// </summary>
        public AVCodecID audio_codec_id;

        /// <summary>
        /// Contains forced subtitle codec ID. For demuxing this is set by the user.
        /// </summary>
        public AVCodecID subtitle_codec_id;

        /// <summary>
        /// Contains the maximum amount of memory in bytes to use for the index of each stream. If the index exceeds this size, entries will be discarded as
        /// needed to maintain a smaller size. This can lead to slower or less accurate seeking (depends on demuxer). Demuxers for which a full in-memory index
        /// is mandatory will ignore this. When muxing this is unused and when demuxnig this is set by the user.
        /// </summary>
        public uint max_index_size;

        /// <summary>
        /// Contains the maximum amount of memory in bytes to use for buffering frames obtained from realtime capture devices.
        /// </summary>
        public uint max_picture_buffer;

        /// <summary>
        /// Contains the number of chapters in AVChapter array. When muxing, chapters are normally written in the file header, so nb_chapters should normally be
        /// initialized before write_header is called. Some muxers (e.g. mov and mkv) can also write chapters in the trailer.  To write chapters in the trailer,
        /// nb_chapters must be zero when write_header is called and non-zero when write_trailer is called. When muxing this is set by the user and when demuxing
        /// this is set by libavformat.
        /// </summary>
        public uint nb_chapters;

        /// <summary>
        /// Contains a pointer to an array of pointers of <see cref="AVChapter"/> chapters.
        /// </summary>
        public IntPtr chapters;

        /// <summary>
        /// Contains the metadata that applies to the whole file. When demuxing this is set by libavformat in avformat_open_input(). When muxing this may be set
        /// by the caller before avformat_write_header(). Freed by libavformat in avformat_free_context().
        /// </summary>
        public IntPtr metadata;

        /// <summary>
        /// Contains the start time of the stream in real world time, in microseconds since the Unix epoch (00:00 1st January 1970). That is, pts=0 in the stream
        /// was captured at this real world time. When muxing this is set by the caller before avformat_write_header(). If set to either 0 or AV_NOPTS_VALUE, then
        /// the current wall-time will be used. When demuxing this is set by libavformat. AV_NOPTS_VALUE if unknown. Note that the value may become known after
        /// some number of frames have been received.
        /// </summary>
        public long start_time_realtime;

        /// <summary>
        /// Contains the number of frames used for determining the framerate in avformat_find_stream_info(). This is for demuxing only and is set by the caller
        /// before avformat_find_stream_info().
        /// </summary>
        public int fps_probe_size;

        /// <summary>
        /// Conatins a value that determines how many errors are being detected. Higher values will detect more errors but may misdetect some more or less valid
        /// parts as errors. This is for demuxing only and is set by the caller before avformat_open_input().
        /// </summary>
        public int error_recognition;

        /// <summary>
        /// Contains the custom interrupt callbacks for the I/O layer. When demuxing this is set by the usre before avformat_open_input(). When muxing this is
        /// set by the user before avformat_write_header() (mainly useful for AVFMT_NOFILE formats). The callback should also be passed to avio_open2() if it's
        /// used to open the file.
        /// </summary>
        public AVIOInterruptCB interrupt_callback;

        /// <summary>
        /// Contains the flags for enabling debugging.
        /// </summary>
        public int debug;

        /// <summary>
        /// Conatins the maximum buffering duration for interleaving. To ensure all the streams are interleaved correctly, av_interleaved_write_frame() will
        /// wait until it has at least one packet for each stream before actually writing any packets to the output file. When some streams are "sparse" (i.e.
        /// there are large gaps between successive packets), this can result in excessive buffering. This field specifies the maximum difference between the
        /// timestamps of the first and the last packet in the muxing queue, above which libavformat will output a packet regardless of whether it has queued
        /// a packet for all the streams. This is for muxing only and is set by the caller before avformat_write_header().
        /// </summary>
        public long max_interleave_delta;

        /// <summary>
        /// Contains a value that allows non-standard and experimental extension.
        /// </summary>
        public int strict_std_compliance;

        /// <summary>
        /// Contains flags for the user to detect events happening on the file. Flags must be cleared by the user once the event has been handled.
        /// </summary>
        public int event_flags;

        /// <summary>
        /// Contains the maximum number of packets to read while waiting for the first timestamp. This is for decoding only.
        /// </summary>
        public int max_ts_probe;

        /// <summary>
        /// Contains a value that determines wheter negative timestamps are avoided during muxing. Any value of the AVFMT_AVOID_NEG_TS_* constants. Note, this
        /// only works when using av_interleaved_write_frame. (interleave_packet_per_dts is in use). This is only used for muxing and set by the user.
        /// </summary>
        public int avoid_negative_ts;

        /// <summary>
        /// Contains the transport stream ID. This will be moved into demuxer private options. Thus no API/ABI compatibility.
        /// </summary>
        public int ts_id;

        /// <summary>
        /// Contains the audio preload in microseconds. Note, not all formats support this and unpredictable things may happen if it is used when not supported.
        /// When encoding this is set by the user via <see cref="AVOptions"/> (no direct access). When decoding this is not used.
        /// </summary>
        public int audio_preload;

        /// <summary>
        /// Contains the maximum chunk time in microseconds. Note, not all formats support this and unpredictable things may happen if it is used when not
        /// supported. When encoding this is set by the user via <see cref="AVOptions"/> (no direct access). When decoding this is not used.
        /// </summary>
        public int max_chunk_duration;

        /// <summary>
        /// Contains the maximum chunk size in bytes. Note, not all formats support this and unpredictable things may happen if it is used when not supported.
        /// When encoding this is set by the user via <see cref="AVOptions"/> (no direct access). When decoding this is not used.
        /// </summary>
        public int max_chunk_size;

        /// <summary>
        /// Contains a value that forces the use of wallclock timestamps as pts/dts of packets. This has undefined results in the presence of B frames. When
        /// encoding this is unused. When decoding this is set by the user via <see cref="AVOptions"/> (no direct access).
        /// </summary>
        public int use_wallclock_as_timestamps;

        /// <summary>
        /// Contains the avio flags, used to force AVIO_FLAG_DIRECT. When encoding this is unused. When decoding this  is set by the user via
        /// <see cref="AVOptions"/> (no direct access).
        /// </summary>
        public int avio_flags;

        /// <summary>
        /// The duration field can be estimated through various ways, and this field can be used to know how the duration was estimated. When encoding this
        /// is unused. When decoding this can be erad by the user via AVOptions (no direct access).
        /// </summary>
        public AVDurationEstimationMethod duration_estimation_method;

        /// <summary>
        /// Contains the number of bytes that are skipped initially when opening a stream. When encoding this is not used. When decoding this is set by the
        /// user via AVOptions (no direct access).
        /// </summary>
        public long skip_initial_bytes;

        /// <summary>
        /// Contains a value for correcting single timestamp overflows. When enocding this is not used. When decoding this is set by the user via AVOptions
        /// (no direct access).
        /// </summary>
        public uint correct_ts_overflow;

        /// <summary>
        /// Contains a value to force seeking to any (also non key) frames. This is not used when encoding. When decoding this is set by the user via
        /// AVOptions (no direct access).
        /// </summary>
        public int seek2any;

        /// <summary>
        /// Contains a value for flushing the I/O context after each packet. When encodnig this is set by the user via AVOptions (no direct access). This is
        /// not used when decoding.
        /// </summary>
        public int flush_packets;

        /// <summary>
        /// Contains the format probing score. The maximal score is AVPROBE_SCORE_MAX, its set when the demuxer probes the format. When encoding it is
        /// unused. When decoding it is set by avformat and can be read by the user via av_format_get_probe_score() (no direct access).
        /// </summary>
        public int probe_score;

        /// <summary>
        /// Contains the number of bytes to read maximally to identify format. When encoding it is not used. When decoding it is set by user through AVOPtions
        /// (no direct access).
        /// </summary>
        public int format_probesize;

        /// <summary>
        /// Contains a comma-separated list of allowed decoders. If <c>null</c> the nall are allowed. This is not used when encoding. When decoding this is
        /// set by the user through AVOptions (no direct access).
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string codec_whitelist;

        /// <summary>
        /// Contains a comma-separated list of allowed demuxers. If <c>null</c> then all are allowed. This is not used when encoding. When decoding this is
        /// set by the user through AVOptions (no direct access).
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string format_whitelist;

        /// <summary>
        /// Contains an opaque field for libavformat internal usage. Must not be accessed in any way by callers.
        /// </summary>
        public IntPtr @internal;

        /// <summary>
        /// Contains an IO repositioned flag. This is set by avformat when the underlaying IO context read pointer is repositioned, for example when doing
        /// byte based seeking. Demuxers can use the flag to detect such changes.
        /// </summary>
        public int io_repositioned;

        /// <summary>
        /// Contains the forced video codec (as a pointer to a <see cref="AVCodec"/> structure). This allows forcing a specific decoder, even when there are
        /// multiple with the same codec ID. When demuxing this is set by the user via av_format_set_video_codec (no direct access).
        /// </summary>
        public IntPtr video_codec;

        /// <summary>
        /// Contains the forced audio codec (as a pointer to a <see cref="AVCodec"/> structure). This allows forcing a specific decoder, even when there are
        /// multiple with the same codec ID. When demuxing this is set by the user via av_format_set_audio_codec (no direct access).
        /// </summary>
        public IntPtr audio_codec;

        /// <summary>
        /// Contains the forced subtitle codec (as a pointer to a <see cref="AVCodec"/> structure). This allows forcing a specific decoder, even when there
        /// are multiple with the same codec ID. When demuxing this is set by the user via av_format_set_subtitle_codec (no direct access).
        /// </summary>
        public IntPtr subtitle_codec;

        /// <summary>
        /// Contains the forced data codec (as a pointer to a <see cref="AVCodec"/> structure). This allows forcing a specific decoder, even when there are
        /// multiple with the same codec ID. When demuxing this is set by the user via av_format_set_data_codec (no direct access).
        /// </summary>
        public IntPtr data_codec;

        /// <summary>
        /// Contains the number of bytes to be written as padding in a metadata header. This is unused when demuxing. When muxing this is set by the user via
        /// av_format_set_metadata_header_padding.
        /// </summary>
        public int metadata_header_padding;

        /// <summary>
        /// Contains user data. This is place for some private data of the user.
        /// </summary>
        public IntPtr opaque;

        /// <summary>
        /// Contains the callback used by devices to communicate with application.
        /// </summary>
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public AVFormatControlMessage control_message_cb;

        /// <summary>
        /// Contains the output timestamp offset, in microseconds. For muxing this is set by user via AVOptions (no direct access).
        /// </summary>
        public long output_ts_offset;

        /// <summary>
        /// Contains the dump format separator. Can be ", " or "\n      " or anything else. Code outside libavformat should access this field using AVOptions
        /// (no direct access). For muxing as well as demuxing this is set by the user.
        /// </summary>
        public UIntPtr dump_separator;

        /// <summary>
        /// Contains the forced data codec ID. For demuxing thsi is set by the user.
        /// </summary>
        public AVCodecID data_codec_id;

        /// <summary>
        /// Contains a callback, which is called to open further IO contexts when needed for demuxing. This can be set by the user application to perform
        /// security checks on the URLs before opening them. The function should behave like avio_open2(), AVFormatContext is provided as contextual
        /// information and to reach AVFormatContext.opaque. If <c>null</c> then some simple checks are used together with avio_open2(). Must not be accessed
        /// directly from outside avformat. For demuxing this is ste by the user. This is deprecated, use io_open and io_close instead.
        /// </summary>
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public OpenCallback open_cb;

        /// <summary>
        /// Contains a comma-separated list of allowed protocols. This is not used while encoding. When decoding this is set by the user through AVOptions (no
        /// direct access)
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string protocol_whitelist;

        /// <summary>
        /// Contains a callback for opening new IO streams. Whenever a muxer or a demuxer needs to open an IO stream (typically from avformat_open_input()
        /// for demuxers, but for certain formats can happen at other times as well), it will call this callback to obtain an IO context. Note, certain muxers
        /// and demuxers do nesting, i.e. they open one or more additional internal format contexts. Thus the AVFormatContext pointer passed to this callback
        /// may be different from the one facing the caller. It will, however, have the same 'opaque' field.
        /// </summary>
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public IOOpenCallback io_open;

        /// <summary>
        /// Contains a callback for closing the streams opened with AVFormatContext.io_open().
        /// </summary>
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public IOCloseCallback io_close;

        /// <summary>
        /// Contains a comma-separated list of disallowed protocols. This is not used while encoding. When decoding this is set by the user through AVOptions
        /// (no direct access).
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string protocol_blacklist;

        #endregion

        #region Public Delegates

        /// <summary>
        /// Represetns a delegate for a callback used by devices to communicate with the applicaiton.
        /// </summary>
        /// <param name="s">The <see cref="AVFormatContext"/>.</param>
        /// <param name="type">The type of the message.</param>
        /// <param name="data">The data that is send.</param>
        /// <param name="data_size">The size of the data that is send.</param>
        /// <returns></returns>
        public delegate int AVFormatControlMessage(IntPtr s, int type, IntPtr data, UIntPtr data_size);

        /// <summary>
        /// Represents a delegate for a callback when further IO streams are opened, needed by for demuxing.
        /// </summary>
        /// <param name="s">The <see cref="AVFormatContext"/>.</param>
        /// <param name="p">On success the The <see cref="AVIOContext"/>.</param>
        /// <param name="url">The URL that is being opened.</param>
        /// <param name="flags">A combination of AVIO_FLAG_.</param>
        /// <param name="int_cb">The callback for closing blocking IO functions.</param>
        /// <param name="options">A dictionary of additional options, with the same semantics as in avio_open2().</param>
        /// <returns>Returns 0 when everything went alright and a negative number otherwise.</returns>
        public delegate int OpenCallback(IntPtr s, [Out] out IntPtr p, [MarshalAs(UnmanagedType.LPStr)] string url, int flags, IntPtr int_cb, IntPtr options);

        /// <summary>
        /// Represents a delegate for a callback when further IO streams are opened.
        /// </summary>
        /// <param name="s">The <see cref="AVFormatContext"/>.</param>
        /// <param name="pb">On success, the newly opened IO context should be returned here.</param>
        /// <param name="url">The URL that is being opened.</param>
        /// <param name="flags">A combination of AVIO_FLAG_.</param>
        /// <param name="options">A dictionary of additional options, with the same semantics as in avio_open2().</param>
        /// <returns>Returns 0 when everything went alright and a negative number otherwise.</returns>
        public delegate int IOOpenCallback(IntPtr s, [Out] out IntPtr pb, [MarshalAs(UnmanagedType.LPStr)] string url, int flags, IntPtr options);

        /// <summary>
        /// Represents a delegate for a callback when IO streams are closed.
        /// </summary>
        /// <param name="s">The <see cref="AVFormatContext"/>.</param>
        /// <param name="pb">The open IO context, that is to be closed.</param>
        public delegate void IOCloseCallback(IntPtr s, IntPtr pb);

        #endregion
    }
}