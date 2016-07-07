
#region Using Directives

using System;
using System.Runtime.InteropServices;
using FFmpegDotNet.Interop.Utilities;

#endregion

namespace FFmpegDotNet.Interop.Scaling
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

        /// <summary>
        /// Scales the image slice in srcSlice and put the resulting scaled slice in the image in dst. A slice is a sequence of consecutive rows in an image.
        /// Slices have to be provided in sequential order, either in top-bottom or bottom-top order. If slices are provided in non-sequential order the
        /// behavior of the function is undefined.
        /// </summary>
        /// <param name="c">The scaling context previously created with sws_getContext().</param>
        /// <param name="srcSlice">The array containing the pointers to the planes of the source slice.</param>
        /// <param name="srcStride">The array containing the strides for each plane of the source image.</param>
        /// <param name="srcSliceY">
        /// The position in the source image of the slice to process, that is the number (counted starting from zero) in the image of the first row of the
        /// slice.
        /// </param>
        /// <param name="srcSliceH">The height of the source slice, that is the number of rows in the slice.</param>
        /// <param name="dst">The array containing the pointers to the planes of the destination image.</param>
        /// <param name="dstStride">The array containing the strides for each plane ofthe destination image.</param>
        /// <returns>Returns the height of the output slice.</returns>
        [DllImport(Libraries.SwScale)]
        public static extern IntPtr sws_scale(IntPtr c, IntPtr[] srcSlice, int[] srcStride, int srcSliceY, int srcSliceH, IntPtr[] dst, int[] dstStride);

        //int sws_scale(struct SwsContext *c, const uint8_t *const srcSlice[], const int srcStride[], int srcSliceY, int srcSliceH, uint8_t *const dst[], const int dstStride[]);

        #endregion
    }
}