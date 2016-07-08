 
 namespace FFmpegDotNet.Interop
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
         public const string AVCodec = "libavcodec"; 

         /// <summary>
         /// Contains the name of the libavformat library. The libavformat library provides a generic framework for multiplexing and demultiplexing (muxing
         /// and demuxing) audio, video and subtitle streams. It encompasses multiple muxers and demuxers for multimedia container formats.
         /// </summary>
         public const string AVFormat = "libavformat"; 

         /// <summary>
         /// Contains the name of the libavutil library. The libavutil library is a utility library to aid portable multimedia programming. It contains
         /// safe portable string functions, random number generators, data structures, additional mathematics functions, cryptography and multimedia
         /// related functionality (like enumerations for pixel and sample formats). It is not a library for code needed by both libavcodec and libavformat.
         /// </summary>
         public const string AVUtil = "libavutil";

         /// <summary>
         /// Contains the name of the libswscale library. The libswscale library performs highly optimized image scaling and colorspace and pixel format
         /// conversion operations. 
         /// </summary>
         public const string SwScale = "libswscale";

         #endregion
     }
 }