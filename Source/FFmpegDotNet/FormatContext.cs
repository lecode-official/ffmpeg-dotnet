
#region Using Directives

using FFmpegDotNet.Interop.Formats;
using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Collections.Generic;

#endregion

namespace FFmpegDotNet
{
    /// <summary>
    /// Represents the format I/O context.
    /// </summary>
    public class FormatContext
    {
        #region Constructors

        /// <summary>
        /// Initializes a  new <see cref="FormatContext"/> instance.
        /// </summary>
        /// <param name="formatContextPointer">The pointer to the internal FFmpeg format context structure.</param>
        private FormatContext(IntPtr formatContextPointer)
        {
            // Stores the pointer ot the internal FFmpeg format context structure for later use
            this.FormatContextPointer = formatContextPointer;

            // Converts the internal FFmpeg format context structure to a managed structure and stores it for later use
            this.InternalFormatContext = Marshal.PtrToStructure<AVFormatContext>(this.FormatContextPointer);
        }

        #endregion

        #region Internal Static Properties

        /// <summary>
        /// Gets a value that determines whether the LibAVFormat library has already been initialized.
        /// </summary>
        internal static bool IsInitialized { get; private set; }

        #endregion

        #region Internal Properties

        /// <summary>
        /// Gets a pointer to the internal FFmpeg format context structure.
        /// </summary>
        internal IntPtr FormatContextPointer { get; private set; }

        /// <summary>
        /// Gets the internal FFmpeg format context converted to a managed structure.
        /// </summary>
        internal AVFormatContext InternalFormatContext { get; private set; }

        #endregion

        #region Public Properties

        /// <summary>
        /// Contains the streams of the media file.
        /// </summary>
        private List<MediaStream> streams = new List<MediaStream>();

        /// <summary>
        /// Gets the streams of the media file.
        /// </summary>
        public IEnumerable<MediaStream> Streams
        {
            get
            {
                return this.streams;
            }
        }

        #endregion

        #region Internal Static Methods

        /// <summary>
        /// Initializes the LibAVFormat library if it has not been intialized, yet.
        /// </summary>
        internal static async Task InitializeAsync()
        {
            if (!FormatContext.IsInitialized)
            {
                await Task.Run(() => LibAVFormat.av_register_all());
                FormatContext.IsInitialized = true;
            }
        }

        #endregion

        #region Public Static Methods

        /// <summary>
        /// Loads a media file and opens it in a <see cref="FormatContext"/>.
        /// </summary>
        /// <param name="url">The URL from which the media file is to be loaded (may be a local file name).</param>
        /// <exception cref="InvalidOperationException">
        /// If the media file could not be loaded, or its stream inforamtion could not be retrieved, then a <see cref="InvalidOperationException"/>
        /// exception is thrown.
        /// <returns>Returns the format context into which the media file was loaded.</returns>
        public static async Task<FormatContext> LoadFromUrlAsync(string url)
        {
            // Initializes the LibAVFormat if it had not been initialized yet
            await FormatContext.InitializeAsync();

            // Creates a new background task, which creates and initializes the format context
            return await Task.Run(() =>
            {
                // Loads the media file
                IntPtr formatContextPointer = IntPtr.Zero;
                if (LibAVFormat.avformat_open_input(out formatContextPointer, url, IntPtr.Zero, IntPtr.Zero) < 0)
                    throw new InvalidOperationException($"The media file could not be loaded from the URL {url}.");

                // Retrieve stream information of the video
                if (LibAVFormat.avformat_find_stream_info(formatContextPointer, IntPtr.Zero) < 0)
                    throw new InvalidOperationException("An error occurred while retrieving the stream information of the media file.");

                // Creates a new format context
                FormatContext formatContext = new FormatContext(formatContextPointer);

                // Retrieves the streams from the media file
                for (int i = 0; i < formatContext.InternalFormatContext.nb_streams; i++)
                {
                    IntPtr streamPointer = Marshal.PtrToStructure<IntPtr>(IntPtr.Add(formatContext.InternalFormatContext.streams, i * IntPtr.Size));
                    MediaStream mediaStream = new MediaStream(streamPointer);
                    formatContext.streams.Add(mediaStream);
                }

                // Returns the created format context
                return formatContext;
            });
        }

        #endregion
    }
}