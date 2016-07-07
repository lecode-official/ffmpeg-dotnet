
namespace FFmpegDotNet.Interop.Scaling
{
    /// <summary>
    /// Represents values for the flags.
    /// </summary>
    public static class ScalingFlags
    {
        #region Public Constants

        /// <summary>
        /// Fast bilinear scaling is used.
        /// </summary>
        public const int SWS_FAST_BILINEAR = 1;

        /// <summary>
        /// Bilinear scaling is used.
        /// </summary>
        public const int SWS_BILINEAR = 2;
        
        /// <summary>
        /// Bicubic scaling is used.
        /// </summary>
        public const int SWS_BICUBIC = 4;
        
        /// <summary>
        /// X scaling is used.
        /// </summary>
        public const int SWS_X = 8;
        
        /// <summary>
        /// Point scaling is used.
        /// </summary>
        public const int SWS_POINT = 0x10;
        
        /// <summary>
        /// Area scaling is used.
        /// </summary>
        public const int SWS_AREA = 0x20;
        
        /// <summary>
        /// Linear bicubic scaling is used.
        /// </summary>
        public const int SWS_BICUBLIN = 0x40;
        
        /// <summary>
        /// Gaussian scaling is used.
        /// </summary>
        public const int SWS_GAUSS = 0x80;
        
        /// <summary>
        /// Sinc scaling is used.
        /// </summary>
        public const int SWS_SINC = 0x100;
        
        /// <summary>
        /// Lanczos scaling is used.
        /// </summary>
        public const int SWS_LANCZOS = 0x200;
        
        /// <summary>
        /// Spline scaling is used.
        /// </summary>
        public const int SWS_SPLINE = 0x400;

        #endregion
    }
} 