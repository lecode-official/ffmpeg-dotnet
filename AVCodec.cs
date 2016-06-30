
#region Using Directives

using System;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Security;

#endregion

namespace System.Media.FFMpeg.Interop
{
	/// <summary>
	/// Represents a simple PInvoke wrapper aroung the libavcodec library of the FFMpeg project.
	/// </summary>
    public class AVCodec
    {
        #region Public Methods
        
        [DllImport("libavcodec.so")]
        public static extern uint avcodec_version();
        
        #endregion 
    }
}
