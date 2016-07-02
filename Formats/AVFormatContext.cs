
#region Using Directives

using System.Media.FFmpeg.Interop.Codecs;
using System.Runtime.InteropServices;

#endregion

namespace System.Media.FFmpeg.Interop.Formats
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

        #endregion
    }
}