
#region Using Directives

using FFmpegDotNet.Interop.Formats;
using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

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
            this.ContextPointer = formatContextPointer;
            this.Context = Marshal.PtrToStructure<AVFormatContext>(this.ContextPointer);
        }

        #endregion

        #region Internal Static Properties

        internal static bool IsInitialized { get; private set; }

        #endregion

        #region Internal Properties

        internal IntPtr ContextPointer { get; private set; }

        internal AVFormatContext Context { get; private set; }

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

                // Creates a new format context and returns it
                return new FormatContext(formatContextPointer);
            });
        }

        #endregion
    }
}