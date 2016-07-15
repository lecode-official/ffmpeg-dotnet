
#region Using Directives

using FFmpegDotNet.Interop.Utilities;
using System;
using System.Runtime.InteropServices;

#endregion

namespace FFmpegDotNet.Interop.Codecs
{
    /// <summary>
    /// Represents a codec.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct AVCodec
    {
        #region Public Fields

        /// <summary>
        /// Contains the name of the coded implementation. The name is globally unique among encoders and among decoders (but an encoder and a decoder can
        /// share the same name). This is the primary way to find a codec from the user perspective.
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
    	public string name;

        /// <summary>
        /// Contains a descriptive name for the codec, meant to be more human readable than name.
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string long_name;

        /// <summary>
        /// Contains the media type.
        /// </summary>
        public AVMediaType type;

        /// <summary>
        /// Contains the ID of the codec.
        /// </summary>
        public AVCodecID id;
    
        /// <summary>
        /// Contains the capabilities of the codec.
        /// </summary>
        public int capabilities;

        /// <summary>
        /// Contains an array of supported framerates (of type <see cref="AVRational"/>), or <c>null</c> if any, the array is terminated by {0,0}.
        /// </summary>
        public IntPtr supported_framerates;

        /// <summary>
        /// Contains an array of supported pixel formats (of type <see cref="AVPixelFormat"/>), or <c>null</c> if unknown, array is terminated by -1.
        /// </summary>
        public IntPtr pix_fmts;

        /// <summary>
        /// Contains an array of supported audio samplerates (of type <see cref="int"/>), or <c>null</c> if unknown, array is terminated by 0.
        /// </summary>
        public IntPtr supported_samplerates;

        /// <summary>
        /// Contains an array of supported sample formats (of type <see cref="AVSampleFormat"/>, or <c>null</c> if unknown, array is terminated by -1.
        /// </summary>
        public IntPtr sample_fmts;

        /// <summary>
        /// Contains an array of support channel layouts (of type <see cref="long"/>), or <c>null</c> if unknown. array is terminated by 0.
        /// </summary>
        public IntPtr channel_layouts;

        /// <summary>
        /// Contains the maximum value for lowres supported by the decoder, no direct access, use av_codec_get_max_lowres().
        /// </summary>
        public byte max_lowres;

        /// <summary>
        /// Contains the <see cref="AVClass"/> for the private context.
        /// </summary>
        public IntPtr priv_class;

        /// <summary>
        /// Contains an array of recognized profiles (of type <see cref="AVProfile"/>), or <c>null</c> if unknown, array is terminated by
        /// {FF_PROFILE_UNKNOWN}.
        /// </summary>
        public IntPtr profiles;

        #endregion
    }
}