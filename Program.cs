
#region Using Directives

using FFmpeg.Formats;
using System;
using System.Runtime.InteropServices;
using FFmpeg.Codecs;

#endregion

namespace FFmpeg
{
    /// <summary>
    /// Represents the entry-point to the FFmpeg.NET sample application.
    /// </summary>
    public class Program
    {
        #region Public Static Methods
        
        /// <summary>
        /// Is invoked, when the application is started.
        /// </summary>
        /// <param name="args">The command line arguments, that were passed to the application.</param>
        public static void Main(string[] args)
        {
            // Initializes the Codecs and formats
            LibAVFormat.av_register_all();

            // Loads a video
            IntPtr formatContextPointer;
            if (LibAVFormat.avformat_open_input(out formatContextPointer, "/home/david/Downloads/big_buck_bunny_480p_surround-fix.avi", IntPtr.Zero, IntPtr.Zero) < 0)
            {
                Console.WriteLine("An error occurred while opening the video.");
                return;
            }

            // Prints out a success message
            AVFormatContext formatContext = Marshal.PtrToStructure<AVFormatContext>(formatContextPointer);
            Console.WriteLine($"Opened video: {formatContext.filename}");

            // Retrieve stream information of the video
            if (LibAVFormat.avformat_find_stream_info(formatContextPointer, IntPtr.Zero) < 0)
            {
                Console.WriteLine("An error occurred while retrieving the stream information of the video.");
                return;
            }

            // Prints out information about each frame in the video
            Console.WriteLine($"Number streams: {formatContext.nb_streams}");
            for (int i = 0; i < formatContext.nb_streams; i++)
            {
                AVStream stream = Marshal.PtrToStructure<AVStream>(formatContext.streams);
                AVCodecContext codecContext = Marshal.PtrToStructure<AVCodecContext>(stream.codec);
                Console.WriteLine(codecContext.codec_type);
            }

            // Closes the video again
            LibAVFormat.avformat_close_input(formatContextPointer);
            Console.WriteLine("Closed video");
        }
        
        #endregion
    }
}