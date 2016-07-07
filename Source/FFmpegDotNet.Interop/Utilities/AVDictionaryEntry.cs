
#region Using Directives

using System.Runtime.InteropServices;

#endregion

namespace FFmpegDotNet.Interop.Utilities
{
    /// <summary>
    /// Represents a key-value-pair that can be stored in a <see cref="AVDictionary"/>.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct AVDictionaryEntry
    {
        #region Public Fields

        /// <summary>
        /// Contains the key of the key-value-pair.
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string key;

        /// <summary>
        /// Contains the value of the key-value-pair.
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string @value;

        #endregion
    }
}