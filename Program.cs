
#region Using Directives

using System;

#endregion

namespace System.Media.FFMpeg.Interop
{
    /// <summary>
    /// Represents the entry-point to the FFMpeg.NET sample application.
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
            // Prints out the version of libavcoded that is installed on the system.
            Console.WriteLine(AVCodec.avcodec_version().ToString());
        }
        
        #endregion
    }
}
