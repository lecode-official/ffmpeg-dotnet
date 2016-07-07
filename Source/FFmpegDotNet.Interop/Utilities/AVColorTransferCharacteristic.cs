
namespace FFmpegDotNet.Interop.Utilities
{
    /// <summary>
    /// Represents an enumeration Color Transfer Characteristic.
    /// </summary>
    public enum AVColorTransferCharacteristic
    {
        /// <summary>
        /// This is reserved.
        /// </summary>
        AVCOL_TRC_RESERVED0 = 0,

        /// <summary>
        /// Also ITU-R BT1361.
        /// </summary>
        AVCOL_TRC_BT709 = 1,

        /// <summary>
        /// This is unspecified.
        /// </summary>
        AVCOL_TRC_UNSPECIFIED = 2,

        /// <summary>
        /// This is reserved.
        /// </summary>
        AVCOL_TRC_RESERVED = 3,

        /// <summary>
        /// Also ITU-R BT470M / ITU-R BT1700 625 PAL & SECAM.
        /// </summary>
        AVCOL_TRC_GAMMA22 = 4,

        /// <summary>
        /// Also ITU-R BT470BG.
        /// </summary>
        AVCOL_TRC_GAMMA28 = 5,

        /// <summary>
        /// Also ITU-R BT601-6 525 or 625 / ITU-R BT1358 525 or 625 / ITU-R BT1700 NTSC.
        /// </summary>
        AVCOL_TRC_SMPTE170M = 6,

        /// <summary>
        /// SMPTE240M.
        /// </summary>
        AVCOL_TRC_SMPTE240M = 7,

        /// <summary>
        /// Linear transfer characteristics.
        /// </summary>
        AVCOL_TRC_LINEAR = 8,

        /// <summary>
        /// Logarithmic transfer characteristic (100:1 range).
        /// </summary>
        AVCOL_TRC_LOG = 9,

        /// <summary>
        /// Logarithmic transfer characteristic (100 * Sqrt(10) : 1 range).
        /// </summary>
        AVCOL_TRC_LOG_SQRT = 10,

        /// <summary>
        /// IEC 61966-2-4.
        /// </summary>
        AVCOL_TRC_IEC61966_2_4 = 11,

        /// <summary>
        /// ITU-R BT1361 Extended Colour Gamut.
        /// </summary>
        AVCOL_TRC_BT1361_ECG = 12,

        /// <summary>
        /// IEC 61966-2-1 (sRGB or sYCC).
        /// </summary>
        AVCOL_TRC_IEC61966_2_1 = 13,

        /// <summary>
        /// ITU-R BT2020 for 10-bit system.
        /// </summary>
        AVCOL_TRC_BT2020_10 = 14,

        /// <summary>
        /// ITU-R BT2020 for 12-bit system.
        /// </summary>
        AVCOL_TRC_BT2020_12 = 15,

        /// <summary>
        /// SMPTE ST 2084 for 10-, 12-, 14- and 16-bit systems.
        /// </summary>
        AVCOL_TRC_SMPTEST2084 = 16,

        /// <summary>
        /// SMPTE ST 428-1.
        /// </summary>
        AVCOL_TRC_SMPTEST428_1 = 17,

        /// <summary>
        /// ARIB STD-B67, known as "Hybrid log-gamma".
        /// </summary>
        AVCOL_TRC_ARIB_STD_B67 = 18,

        /// <summary>
        /// Not part of ABI.
        /// </summary>
        AVCOL_TRC_NB 
    }
}