
namespace FFmpegDotNet.Interop.Utilities
{
    /// <summary>
    /// Represents an enumeration for the chromaticity coordinates of the source primaries.
    /// </summary>
    public enum AVColorPrimaries
    {
        /// <summary>
        /// This is reserved.
        /// </summary>
        AVCOL_PRI_RESERVED0 = 0,

        /// <summary>
        /// Also ITU-R BT1361 / IEC 61966-2-4 / SMPTE RP177 Annex B.
        /// </summary>
        AVCOL_PRI_BT709 = 1,

        /// <summary>
        /// This is unspecified.
        /// </summary>
        AVCOL_PRI_UNSPECIFIED = 2,
        
        /// <summary>
        /// This is reserved.
        /// </summary>
        AVCOL_PRI_RESERVED = 3,
        
        /// <summary>
        /// Also FCC Title 47 Code of Federal Regulations 73.682 (a)(20).
        /// </summary>
        AVCOL_PRI_BT470M = 4,

        /// <summary>
        /// Also ITU-R BT601-6 625 / ITU-R BT1358 625 / ITU-R BT1700 625 PAL & SECAM.
        /// </summary>
        AVCOL_PRI_BT470BG = 5,
        
        /// <summary>
        /// Also ITU-R BT601-6 525 / ITU-R BT1358 525 / ITU-R BT1700 NTSC.
        /// </summary>
        AVCOL_PRI_SMPTE170M = 6,
        
        /// <summary>
        /// Functionally identical to above.
        /// </summary>
        AVCOL_PRI_SMPTE240M = 7,
        
        /// <summary>
        /// Colour filters using Illuminant C.
        /// </summary>
        AVCOL_PRI_FILM = 8,
        
        /// <summary>
        /// ITU-R BT2020.
        /// </summary>
        AVCOL_PRI_BT2020 = 9,
        
        /// <summary>
        /// SMPTE ST 428-1 (CIE 1931 XYZ).
        /// </summary>
        AVCOL_PRI_SMPTEST428_1 = 10,
        
        /// <summary>
        /// Not part of ABI.
        /// </summary>
        AVCOL_PRI_NB
    }
}