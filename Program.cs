
#region Using Directives

using FFmpeg.Formats;
using System;
using System.Runtime.InteropServices;
using FFmpeg.Codecs;
using FFmpeg.Utilities;

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
            AVFormatContext formatContext = Marshal.PtrToStructure<AVFormatContext>(formatContextPointer);
            Console.WriteLine($"Opened video file {formatContext.filename}.");

            // Retrieve stream information of the video
            if (LibAVFormat.avformat_find_stream_info(formatContextPointer, IntPtr.Zero) < 0)
            {
                Console.WriteLine("An error occurred while retrieving the stream information of the video.");
                return;
            }

            // Finds the first video stream in the video
            Console.WriteLine($"Found {formatContext.nb_streams} stream(s) in the video file.");
            int videoStreamId = -1;
            for (int i = 0; i < formatContext.nb_streams; i++)
            {
                AVStream stream = Marshal.PtrToStructure<AVStream>(Marshal.PtrToStructure<IntPtr>(IntPtr.Add(formatContext.streams, i * IntPtr.Size)));
                AVCodecContext codecContext = Marshal.PtrToStructure<AVCodecContext>(stream.codec);
                if (codecContext.codec_type == AVMediaType.AVMEDIA_TYPE_VIDEO)
                {
                    videoStreamId = i;
                    break;
                }
            }
            if (videoStreamId == -1)
            {
                Console.WriteLine("No video stream found.");
                return;
            }
            AVStream videoStream = Marshal.PtrToStructure<AVStream>(Marshal.PtrToStructure<IntPtr>(IntPtr.Add(formatContext.streams, videoStreamId * IntPtr.Size)));
            AVCodecContext videoCodecContext = Marshal.PtrToStructure<AVCodecContext>(videoStream.codec);

            // Finds the decoder for the video stream
            IntPtr codecPointer = LibAVCodec.avcodec_find_decoder(videoCodecContext.codec_id);
            if (codecPointer == IntPtr.Zero) {
                Console.WriteLine("The video codec is not supported.");
                return;
            }
            AVCodec videoCodec = Marshal.PtrToStructure<AVCodec>(codecPointer);
            Console.WriteLine($"Using the {videoCodec.long_name} codec to decdoe the video stream.");

            // Opens the codec for the video stream
            if (LibAVCodec.avcodec_open2(videoStream.codec, codecPointer, IntPtr.Zero) < 0)
            {
                Console.WriteLine("The codec {videoCodec.long_name} could not be opened.");
                return;
            }
            Console.WriteLine("Successfully loaded codec.");

            // Closes the video again
            LibAVFormat.avformat_close_input(formatContextPointer);
            Console.WriteLine("Closed video");
        }
        
        #endregion
    }
}