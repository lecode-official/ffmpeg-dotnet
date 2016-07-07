
#region Using

using FFmpegDotNet.Interop.Formats;
using System;
using System.Runtime.InteropServices;

#endregion

namespace FFmpegDotNet
{
    public class MediaStream
    {
        #region Constructors

        internal MediaStream(IntPtr streamPointer)
        {
            this.StreamPointer = streamPointer;
            this.InternalStream = Marshal.PtrToStructure<AVStream>(this.StreamPointer);
        }

        #endregion

        #region Internal Properties

        internal IntPtr StreamPointer { get; private set; }

        internal AVStream InternalStream { get; private set; }

        #endregion
    }
}