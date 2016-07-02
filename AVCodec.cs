
#region Using Directives

using System.Runtime.InteropServices;

#endregion

namespace System.Media.FFmpeg.Interop
{
	/// <summary>
	/// Represents a simple PInvoke wrapper aroung the libavcodec library of the FFmpeg project.
	/// </summary>
    public class AVCodec
    {
        #region Public Methods
        
        /// <summary>
        /// Retrieves the version of the libavcodec library.
        /// </summary>
        /// <returns>Returns the version of the libavcodec library.</returns>
        [DllImport(Libraries.AVCodec)]
        public static extern uint avcodec_version();
        
        #endregion 
    }
}
