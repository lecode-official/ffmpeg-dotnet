
#region Using Directives

using System;
using System.Runtime.InteropServices;

#endregion

namespace FFmpegDotNet.Interop.Formats
{
    /// <summary>
    /// Represents a callback for checking whether to abort blocking functions. AVERROR_EXIT is returned in this case by the interrupted function. During blocking
    /// operations, callback is called with opaque as parameter. If the callback returns 1, the blocking operation will be aborted. 
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct AVIOInterruptCB
    {
        #region Public Fields

        /// <summary>
        /// Contains the callback function for checking whether to abort blocking functions.
        /// </summary>
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public InterruptCallback callback;

        /// <summary>
        /// Contains the parameter, that is passed to the callback as a parameter.
        /// </summary>
    	public IntPtr opaque;

        #endregion

        #region Public Delegates

        /// <summary>
        /// Represents a delegate for the interrupt callback function.
        /// </summary>
        /// <param name="opaque">The parameter that is passed to the callback during blokcing operations.</param>
        /// <returns>Returns 1 when the blocking operation should be aborted and any other integer value otherwise.</returns>
        public delegate int InterruptCallback(IntPtr opaque);

        #endregion
    }
}