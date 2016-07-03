
#region Using Directives

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
    }
}