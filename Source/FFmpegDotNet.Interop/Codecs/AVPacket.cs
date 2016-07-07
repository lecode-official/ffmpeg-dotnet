
#region Using Directives

using System;
using System.Runtime.InteropServices;

#endregion

namespace FFmpegDotNet.Interop.Codecs
{
    /// <summary>
    /// Represents a structure that stores compressed data. It is typically exported by demuxers and then passed as input to decoders, or received as output
    /// from encoders and then passed to muxers. For video, it should typically contain one compressed frame. For audio it may contain several compressed
    /// frames. Encoders are allowed to output empty packets, with no compressed data, containing only side data (e.g. to update some stream parameters at
    /// the end of encoding).
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct AVPacket
    {
        #region Public Properties

        /// <summary>
        /// Contains a reference to the reference-counted buffer where the packet data is stored (of type <see cref="AVBufferRef"/>). May be NULL, then the
        /// packet data is not reference-counted.
        /// </summary>
        public IntPtr buf;

        /// <summary>
        /// Contains a presentation timestamp in AVStream->time_base units; the time at which the decompressed packet will be presented to the user. Can be
        /// AV_NOPTS_VALUE if it is not stored in the file. <see cref="pts"/> MUST be larger or equal to dts as presentation cannot happen before
        /// decompression, unless one wants to view hex dumps. Some formats misuse the terms dts and pts/cts to mean something different. Such timestamps
        /// must be converted to true pts/dts before they are stored in <see cref="AVPacket"/>.
        /// </summary>
    	public long pts;

        /// <summary>
        /// Contains the decompression timestamp in AVStream->time_base units; the time at which the packet is decompressed. Can be AV_NOPTS_VALUE if it is
        /// not stored in the file.
        /// </summary>
        public long dts;

        /// <summary>
        /// Contains a pointer to a byte array that contains the data.
        /// </summary>
        public IntPtr data;

        /// <summary>
        /// Contains the size of the data.
        /// </summary>
        public int size;

        /// <summary>
        /// Contains the stream index.
        /// </summary>
        public int stream_index;

        /// <summary>
        /// Contains a combination of AV_PKT_FLAG values.
        /// </summary>
        public int flags;

        /// <summary>
        /// Contains additional packet data (of type <see cref="AVPacketSideData"/>) that can be provided by the container. Packet can contain several types
        /// of side information.
        /// </summary>
        public IntPtr side_data;

        /// <summary>
        /// Contains the number of side data elements.
        /// </summary>
        public int side_data_elems;

        /// <summary>
        /// Contains the duration of this packet in AVStream->time_base units, 0 if unknown. Equals next_pts - this_pts in presentation order.
        /// </summary>
    	public long duration;

        /// <summary>
        /// Contains the current byte position in the stream, -1 if unknown.
        /// </summary>
    	public long pos;

        /// <summary>
        /// Contains the same value as the duration field, but as <see cref="long"/>. This was required for Matroska subtitles, whose duration values could
        /// overflow when the duration field was still an int.
        /// </summary>
        public long convergence_duration;

        #endregion
    }
}