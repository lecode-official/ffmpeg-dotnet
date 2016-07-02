 
 namespace System.Media.FFmpeg.Interop
 {
     /// <summary>
     /// Represents a list of the FFmpeg libraries names.
     /// </summary>
     public static class Libraries
     {
         #region Public Static Fields

         /// <summary>
         /// Contains the name of the libavcodec library. The libavcodec library provides a generic encoding/decoding framework and contains multiple
         /// decoders and encoders for audio, video and subtitle streams, and several bitstream filters.
         /// </summary>
         public const string AVCodec = "libavcodec.so.57"; 

         /// <summary>
         /// Contains the name of the libavformat library. The libavformat library provides a generic framework for multiplexing and demultiplexing (muxing
         /// and demuxing) audio, video and subtitle streams. It encompasses multiple muxers and demuxers for multimedia container formats.
         /// </summary>
         public const string AVFormat = "libavformat.so.57"; 

         #endregion
     }
 }