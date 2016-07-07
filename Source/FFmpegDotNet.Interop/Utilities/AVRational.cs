
#region Using Directives

using System.Runtime.InteropServices;

#endregion

namespace FFmpegDotNet.Interop.Utilities
{
    /// <summary>
    /// Represents a rational numnber: numerator/denominator.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct AVRational
    {
        #region Public Fields

        /// <summary>
        /// Contains the numerator of the rational number.
        /// </summary>
        public int num;

        /// <summary>
        /// Contains the denominator of the rational number.
        /// </summary>
        public int den;

        #endregion
    }
}