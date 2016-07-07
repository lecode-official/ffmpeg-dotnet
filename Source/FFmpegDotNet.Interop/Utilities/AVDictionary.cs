
#region Using Directives

using System;
using System.Runtime.InteropServices;

#endregion

namespace FFmpegDotNet.Interop.Utilities
{
    /// <summary>
    /// Represents a dictionary of key-value-pairs.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct AVDictionary
    {
        #region Public Fields

        /// <summary>
        /// Contains the number of elements in the dictionary.
        /// </summary>
        public int count;

        /// <summary>
        /// Contains a pointer to the array of elements (of type <see cref="AVDictionaryEntry"/>).
        /// </summary>
        public IntPtr elems;

        #endregion
    }
}