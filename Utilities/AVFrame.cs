
#region Using Directives

using System;
using System.Runtime.InteropServices;

#endregion

namespace FFmpeg.Utilities
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

        #endregion
    }
}