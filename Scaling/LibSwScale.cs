
#region Using Directives

using System;
using System.Runtime.InteropServices;
using FFmpeg.Utilities;

#endregion

namespace FFmpeg.Scaling
{
    /// <summary>
    /// Represents a simple PInvoke wrapper aroung the libswscale library of the FFmpeg project.
    /// </summary>
    public static class LibSwScale
    {
        #region Public Static Methods

        /// <summary>
        /// Allocates and return an SwsContext. You need it to perform scaling/conversion operations using sws_scale(). Note that this function is to be
        /// removed after a saner alternative is written.
        /// </summary>
        /// <param name="srcW">The width of the source image.</param>
        /// <param name="srcH">The height of the source image.</param>
        /// <param name="srcFormat">The source image format</param>
        /// <param name="dstW">The width of the destination image.</param>
        /// <param name="dstH">The height of the destination image.</param>
        /// <param name="dstFormat">The destination image format.</param>
        /// <param name="flags">Specify which algorithm and options to use for rescaling.</param>
        /// <param name="srcFilter">The source filter.</param>
        /// <param name="dstFilter">The destination filter.</param>
        /// <param name="param">
        /// Extra parameters to tune the used scaler. For SWS_BICUBIC param[0] and [1] tune the shape of the basis function, param[0] tunes f(1) and param[1]
        /// f´(1). For SWS_GAUSS param[0] tunes the exponent and thus cutoff frequency. For SWS_LANCZOS param[0] tunes the width of the window function.
        /// </param>
        /// <returns>Returns a pointer to an allocated context, or <c>IntPtr.Zero</c> in case of error.</returns>
        [DllImport(Libraries.SwScale)]
        public static extern IntPtr sws_getContext(int srcW, int srcH, AVPixelFormat srcFormat, int dstW, int dstH, AVPixelFormat dstFormat, int flags, IntPtr srcFilter, IntPtr dstFilter, IntPtr param);

        #endregion
    }
}