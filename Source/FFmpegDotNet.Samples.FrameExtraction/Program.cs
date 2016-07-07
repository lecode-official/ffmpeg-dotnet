
#region Using Directives

using FFmpegDotNet.Interop.Formats;
using System;
using System.Runtime.InteropServices;
using FFmpegDotNet.Interop.Codecs;
using FFmpegDotNet.Interop.Utilities;
using FFmpegDotNet.Interop.Scaling;
using System.IO;

#endregion

namespace FFmpegDotNet.Samples.FrameExtraction
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

            // Allocates video frames for the original decoded frame and the frame in RGB (which is then later stored in a file)
            IntPtr framePointer = LibAVUtil.av_frame_alloc();
            IntPtr frameRgbPointer = LibAVUtil.av_frame_alloc();

            // Determines the required buffer size and allocates the buffer for the RGB frame
            int numBytes = LibAVCodec.avpicture_get_size(AVPixelFormat.AV_PIX_FMT_RGB24, videoCodecContext.width, videoCodecContext.height);
            IntPtr buffer = LibAVUtil.av_malloc(new UIntPtr((uint)(numBytes * sizeof(byte))));

            // Assigns appropriate parts of buffer to image planes in frameRgb, note that frameRgb is an AVFrame, but AVFrame is a superset of AVPicture
            LibAVCodec.avpicture_fill(frameRgbPointer, buffer, AVPixelFormat.AV_PIX_FMT_RGB24, videoCodecContext.width, videoCodecContext.height);
            AVFrame frameRgb = Marshal.PtrToStructure<AVFrame>(frameRgbPointer);

            // Cycles over all frames of the video and dumps the frames to file
            Console.WriteLine("Decoding vidoe frames...");
            int frameIndex = 0;
            IntPtr packetPointer = Marshal.AllocHGlobal(Marshal.SizeOf<AVPacket>());
            while (LibAVFormat.av_read_frame(formatContextPointer, packetPointer) >= 0)
            {
                AVPacket packet = Marshal.PtrToStructure<AVPacket>(packetPointer);
                if (packet.stream_index == videoStreamId)
                {
                    // Decodes video frame
                    int frameFinished = 0;
                    LibAVCodec.avcodec_decode_video2(videoStream.codec, framePointer, ref frameFinished, packetPointer);
                    AVFrame frame = Marshal.PtrToStructure<AVFrame>(framePointer);
                    
                    // Checks if the video frame was properly decoded
                    if (frameFinished != 0)
                    {
                        // Converts the image from its native format to RGB
                        IntPtr scaleContextPointer = LibSwScale.sws_getContext(videoCodecContext.width, videoCodecContext.height, videoCodecContext.pix_fmt,
                            videoCodecContext.width, videoCodecContext.height, AVPixelFormat.AV_PIX_FMT_RGB24, ScalingFlags.SWS_BILINEAR, IntPtr.Zero,
                            IntPtr.Zero, IntPtr.Zero);
                        LibSwScale.sws_scale(scaleContextPointer, frame.data, frame.linesize, 0, videoCodecContext.height, frameRgb.data, frameRgb.linesize);
                        frameRgb = Marshal.PtrToStructure<AVFrame>(frameRgbPointer);

                        // Checks if this is one of the first 5 frames, if so then it is stored to disk
                        frameIndex++;
                        if (frameIndex > 24 && frameIndex <= 30)
                        {
                            Console.WriteLine($"Writing frame {frameIndex} to file...");
                            Program.SaveFrame(frameRgb, videoCodecContext.width, videoCodecContext.height, frameIndex);
                        }
                    }
                }
                
                // Frees the packet that was allocated by av_read_frame
                LibAVCodec.av_free_packet(packetPointer);
            }
            Console.WriteLine("Finihsed decoding of the video.");

            // Frees and closes all acquired resources
            LibAVUtil.av_free(buffer);
            LibAVUtil.av_free(frameRgbPointer);
            LibAVUtil.av_free(framePointer);
            LibAVCodec.avcodec_close(videoStream.codec);
            IntPtr formatContextPointerPointer = Marshal.AllocHGlobal(Marshal.SizeOf<IntPtr>());
            Marshal.StructureToPtr(formatContextPointer, formatContextPointerPointer, false);
            LibAVFormat.avformat_close_input(formatContextPointerPointer);
            Marshal.FreeHGlobal(formatContextPointerPointer);
            Console.WriteLine("Freed all acquired resources.");
        }

        /// <summary>
        /// Saves the specified frame to file in the PPM format.
        /// </summary>
        /// <param name="frame">The frame that is to be stored.</param>
        /// <param name="width">The width of the frame.</param>
        /// <param name="height">The height of the frame.</param>
        /// <param name="frameIndex">The index of the frame, which is used to generate a unique file name.</param>
        private static void SaveFrame(AVFrame frame, int width, int height, int frameIndex)
        {
            // Opens a file to which the frame is dumped
            using (FileStream fileStream = new FileStream($"/home/david/Downloads/frame{frameIndex}.ppm", FileMode.Create, FileAccess.Write))
            {
                // Writes the header
                byte[] header = System.Text.Encoding.ASCII.GetBytes($"P6 {width} {height} 255\n");
                fileStream.Write(header, 0, header.Length);

                // Writes the pixel data
                for (int y = 0; y < height; y++)
                {
                    byte[] line = new byte[width * 3];
                    for (int x = 0; x < width * 3; x++)
                        line[x] = Marshal.PtrToStructure<byte>(IntPtr.Add(frame.data[0], (y * frame.linesize[0] + x) * Marshal.SizeOf<byte>()));
                    fileStream.Write(line, 0, line.Length);
                }
            }
        }

        #endregion
    }
}