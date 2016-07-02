
#region Using Directives

using System.Media.FFmpeg.Interop.Formats;
using System.Runtime.InteropServices;

#endregion

namespace System.Media.FFmpeg.Interop
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
            AVFormat.av_register_all();

            // Loads a video
            IntPtr formatContextPointer;
            if (AVFormat.avformat_open_input(out formatContextPointer, "/home/david/Downloads/big_buck_bunny_1080p_stereo.ogg", IntPtr.Zero, IntPtr.Zero) != 0)
            {
                Console.WriteLine("An error occurred while opening the video.");
            }
            else
            {
                AVFormatContext formatContext = Marshal.PtrToStructure<AVFormatContext>(formatContextPointer);
                Console.WriteLine($"Opened video: {formatContext.filename}");

                // Closes the video again
                AVFormat.avformat_close_input(formatContextPointer);
                Console.WriteLine("Closed video");
            }

            // Waits for the user to press a key, before the application is exited
            Console.Write("Press any key to exit...");
            Console.ReadKey();
        }
        
        #endregion
    }
}