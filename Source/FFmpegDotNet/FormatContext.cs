
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

        private FormatContext(IntPtr formatContextPointer)
        {
            this.FormatContextPointer = formatContextPointer;
            this.InternalFormatContext = Marshal.PtrToStructure<AVFormatContext>(this.FormatContextPointer);
        }

        #endregion

        #region Internal Static Properties

        internal static bool IsInitialized { get; private set; }

        #endregion

        #region Internal Properties

        internal IntPtr FormatContextPointer { get; private set; }

        internal AVFormatContext InternalFormatContext { get; private set; }

        #endregion

        #region Public Properties

        private List<MediaStream> streams = new List<MediaStream>();

        public IEnumerable<MediaStream> Streams
        {
            get
            {
                return this.streams;
            }
        }

        #endregion

        #region Internal Static Methods

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