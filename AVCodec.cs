
#region Using Directives

using System.Runtime.InteropServices;

#endregion

namespace System.Media.FFMpeg.Interop
{
	/// <summary>
	/// Represents a simple PInvoke wrapper aroung the libavcodec library of the FFMpeg project.
	/// </summary>
    public class AVCodec
    {
        #region Public Methods
        
        /// <summary>
        /// Retrieves the version of the libavcodec library.
        /// </summary>
        /// <returns>Returns the version of the libavcodec library.</returns>
        [DllImport("libavcodec.so")]
        public static extern uint avcodec_version();
        
        #endregion 
    }
}
