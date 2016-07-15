
#region Using Directives

using FFmpegDotNet.Interop.Utilities;
using System;
using System.Runtime.InteropServices;

#endregion

namespace FFmpegDotNet.Interop.Codecs
{
    /// <summary>
    /// Represents a struct that describes the properties of a single codec described by an AVCodecID, see avcodec_descriptor_get().
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct AVCodecDescriptor
    {
        #region Public Fields

        /// <summary>
        /// Contains the ID of the codec described by this codec descriptor.
        /// </summary>
        public AVCodecID id;

        /// <summary>
        /// Contains the media type supported by the codec described by this codec descriptor.
        /// </summary>
        public AVMediaType type;

        /// <summary>
        /// Contains the name of the codec described by this descriptor. It is non-empty and unique for each codec descriptor. It should contain
        /// alphanumeric characters and '_' only.
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string name;

        /// <summary>
        /// Contains a more descriptive name for this codec. May be <c>null</c>.
        /// </summary>
        public string long_name;

        /// <summary>
        /// Contains the codec properties, a combination of AV_CODEC_PROP_* flags.
        /// </summary>
        public int props;

        /// <summary>
        /// Contains a pointer to the first element of a string array of MIME type(s) associated with the codec. May be <c>null</c>, if not, a
        /// <c>null</c>-terminated array of MIME types. The first item is always non-<c>null</c> and is the preferred MIME type.
        /// </summary>
        public IntPtr mime_types;

        /// <summary>
        /// Contains a pointer to the first element of an array of <see cref="AVProfile"/> structs. If non-NULL, an array of profiles recognized for
        /// this codec. Terminated with FF_PROFILE_UNKNOWN.
        /// </summary>
        public IntPtr profiles;

        #endregion
    }
}