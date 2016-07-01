
#region Using Directives

using System.Runtime.InteropServices;

#endregion

namespace System.Media.FFMpeg.Interop
{
	/// <summary>
	/// Represents a simple PInvoke wrapper aroung the libavformat library of the FFMpeg project.
	/// </summary>
    public class AVFormat
    {
        #region Public Methods
        
        /// <summary>
        /// Initializes libavformat and registers all the muxers, demuxers and protocols.
        /// </summary>
        [DllImport("libavformat.so")]
        public static extern void av_register_all();

        #endregion
    }
}