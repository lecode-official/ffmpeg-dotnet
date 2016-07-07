
namespace FFmpegDotNet.Interop.Utilities
{
    /// <summary>
    /// Represents an enumeration for the different types of pictures.
    /// </summary>
    public enum AVPictureType
    {
        /// <summary>
        /// The picture type is undefined.
        /// </summary>
        AV_PICTURE_TYPE_NONE = 0,

        /// <summary>
        /// The picture type is intra.
        /// </summary>
        AV_PICTURE_TYPE_I,

        /// <summary>
        /// The picture type is predicted.
        /// </summary>
        AV_PICTURE_TYPE_P,

        /// <summary>
        /// The picture type is bi-directionally predicted.
        /// </summary>
        AV_PICTURE_TYPE_B,

        /// <summary>
        /// The picture type is S(GMC)-VOP MPEG-4.
        /// </summary>
        AV_PICTURE_TYPE_S,

        /// <summary>
        /// The picture type is switching intra.
        /// </summary>
        AV_PICTURE_TYPE_SI,

        /// <summary>
        /// The picture type is switching predicted.
        /// </summary>
        AV_PICTURE_TYPE_SP,

        /// <summary>
        /// The picture type is BI.
        /// </summary>    ///< Switching Predicted
        AV_PICTURE_TYPE_BI
    }
}