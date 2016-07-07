
namespace FFmpegDotNet.Interop.Utilities
{
    /// <summary>
    /// Represents an enumeration for the different YUV colorspace types.
    /// </summary>
    public enum AVColorSpace
    {
        /// <summary>
        /// Order of coefficients is actually GBR, also IEC 61966-2-1 (sRGB)
        /// </summary>
        AVCOL_SPC_RGB = 0,

        /// <summary>
        /// Also ITU-R BT1361 / IEC 61966-2-4 xvYCC709 / SMPTE RP177 Annex B.
        /// </summary>
        AVCOL_SPC_BT709 = 1,
        
        /// <summary>
        /// This is unspecified.
        /// </summary>
        AVCOL_SPC_UNSPECIFIED = 2,
        
        /// <summary>
        /// This is reserved.
        /// </summary>
        AVCOL_SPC_RESERVED = 3,
        
        /// <summary>
        /// FCC Title 47 Code of Federal Regulations 73.682 (a)(20).
        /// </summary>
        AVCOL_SPC_FCC = 4,
        
        /// <summary>
        /// Also ITU-R BT601-6 625 / ITU-R BT1358 625 / ITU-R BT1700 625 PAL & SECAM / IEC 61966-2-4 xvYCC601.
        /// </summary>
        AVCOL_SPC_BT470BG = 5,
        
        /// <summary>
        /// Also ITU-R BT601-6 525 / ITU-R BT1358 525 / ITU-R BT1700 NTSC
        /// </summary>
        AVCOL_SPC_SMPTE170M = 6,
        
        /// <summary>
        /// Functionally identical to above.
        /// </summary>
        AVCOL_SPC_SMPTE240M = 7,
        
        /// <summary>
        /// Used by Dirac / VC-2 and H.264 FRext, see ITU-T SG16.
        /// </summary>
        AVCOL_SPC_YCOCG = 8,
        
        /// <summary>
        /// ITU-R BT2020 non-constant luminance system.
        /// </summary>
        AVCOL_SPC_BT2020_NCL = 9,
        
        /// <summary>
        /// ITU-R BT2020 constant luminance system.
        /// </summary>
        AVCOL_SPC_BT2020_CL = 10,
        
        /// <summary>
        /// Not part of ABI.
        /// </summary>
        AVCOL_SPC_NB
    }
}