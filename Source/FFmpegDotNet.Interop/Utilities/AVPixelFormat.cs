
namespace FFmpegDotNet.Interop.Utilities
{
    /// <summary>
    /// Represents an enumeration for the different pixel formats. Note, AV_PIX_FMT_RGB32 is handled in an endian-specific manner. An RGBA color is put
    /// together as: (A << 24) | (R << 16) | (G << 8) | B. This is stored as BGRA on little-endian CPU architectures and ARGB on big-endian CPUs. When the
    /// pixel format is palettized RGB32 (AV_PIX_FMT_PAL8), the palettized image data is stored in AVFrame.data[0]. The palette is transported in
    /// AVFrame.data[1], is 1024 bytes long (256 4-byte entries) and is formatted the same as in AV_PIX_FMT_RGB32 described above (i.e., it is also
    /// endian-specific). Note also that the individual RGB32 palette components stored in AVFrame.data[1] should be in the range 0..255. This is important
    /// as many custom PAL8 video codecs that were designed to run on the IBM VGA graphics adapter use 6-bit palette components. For all the 8 bits per
    /// pixel formats, an RGB32 palette is in data[1] like for pal8. This palette is filled in automatically by the function allocating the picture.
    /// </summary>
    public enum AVPixelFormat
    {
        /// <summary>
        /// 
        /// </summary>
        AV_PIX_FMT_NONE = -1,

        /// <summary>
        /// Planar YUV 4:2:0, 12bpp, (1 Cr & Cb sample per 2x2 Y samples).
        /// </summary>
        AV_PIX_FMT_YUV420P,

        /// <summary>
        /// Packed YUV 4:2:2, 16bpp, Y0 Cb Y1 Cr.
        /// </summary>
        AV_PIX_FMT_YUYV422,

        /// <summary>
        /// Packed RGB 8:8:8, 24bpp, RGBRGB.
        /// </summary>
        AV_PIX_FMT_RGB24,

        /// <summary>
        /// Packed RGB 8:8:8, 24bpp, BGRBGR.
        /// </summary>
        AV_PIX_FMT_BGR24,

        /// <summary>
        /// Planar YUV 4:2:2, 16bpp, (1 Cr & Cb sample per 2x1 Y samples).
        /// </summary>
        AV_PIX_FMT_YUV422P,

        /// <summary>
        /// Planar YUV 4:4:4, 24bpp, (1 Cr & Cb sample per 1x1 Y samples).
        /// </summary>
        AV_PIX_FMT_YUV444P,

        /// <summary>
        /// Planar YUV 4:1:0,  9bpp, (1 Cr & Cb sample per 4x4 Y samples).
        /// </summary>
        AV_PIX_FMT_YUV410P,

        /// <summary>
        /// Planar YUV 4:1:1, 12bpp, (1 Cr & Cb sample per 4x1 Y samples).
        /// </summary>
        AV_PIX_FMT_YUV411P,

        /// <summary>
        /// 8bpp grayscale.
        /// </summary>
        AV_PIX_FMT_GRAY8,

        /// <summary>
        /// 1bpp, 0 is white, 1 is black, in each byte pixels are ordered from the msb to the lsb.
        /// </summary>
        AV_PIX_FMT_MONOWHITE,

        /// <summary>
        /// 1bpp, 0 is black, 1 is white, in each byte pixels are ordered from the msb to the lsb
        /// </summary>
        AV_PIX_FMT_MONOBLACK,

        /// <summary>
        /// 8 bits with AV_PIX_FMT_RGB32 palette.
        /// </summary>
        AV_PIX_FMT_PAL8,

        /// <summary>
        /// Planar YUV 4:2:0, 12bpp, full scale (JPEG), deprecated in favor of AV_PIX_FMT_YUV420P and setting color_range.
        /// </summary>
        AV_PIX_FMT_YUVJ420P,

        /// <summary>
        /// Planar YUV 4:2:2, 16bpp, full scale (JPEG), deprecated in favor of AV_PIX_FMT_YUV422P and setting color_range.
        /// </summary>
        AV_PIX_FMT_YUVJ422P,

        /// <summary>
        /// Planar YUV 4:4:4, 24bpp, full scale (JPEG), deprecated in favor of AV_PIX_FMT_YUV444P and setting color_range.
        /// </summary>
        AV_PIX_FMT_YUVJ444P,

        /// <summary>
        /// XVideo Motion Acceleration via common packet passing.
        /// </summary>
        AV_PIX_FMT_XVMC_MPEG2_MC,

        /// <summary>
        /// MPEG2 IDCT.
        /// </summary>
        AV_PIX_FMT_XVMC_MPEG2_IDCT,

        /// <summary>
        /// Packed YUV 4:2:2, 16bpp, Cb Y0 Cr Y1.
        /// </summary>
        AV_PIX_FMT_UYVY422,

        /// <summary>
        /// acked YUV 4:1:1, 12bpp, Cb Y0 Y1 Cr Y2 Y3.
        /// </summary>
        AV_PIX_FMT_UYYVYY411,

        /// <summary>
        /// Packed RGB 3:3:2,  8bpp, (msb)2B 3G 3R(lsb).
        /// </summary>
        AV_PIX_FMT_BGR8,

        /// <summary>
        /// Packed RGB 1:2:1 bitstream,  4bpp, (msb)1B 2G 1R(lsb), a byte contains two pixels, the first pixel in the byte is the one composed by the 4 msb bits.
        /// </summary>
        AV_PIX_FMT_BGR4,

        /// <summary>
        /// Packed RGB 1:2:1,  8bpp, (msb)1B 2G 1R(lsb).
        /// </summary>
        AV_PIX_FMT_BGR4_BYTE,

        /// <summary>
        /// Packed RGB 3:3:2,  8bpp, (msb)2R 3G 3B(lsb).
        /// </summary>
        AV_PIX_FMT_RGB8,

        /// <summary>
        /// Packed RGB 1:2:1 bitstream,  4bpp, (msb)1R 2G 1B(lsb), a byte contains two pixels, the first pixel in the byte is the one composed by the 4 msb bits.
        /// </summary>
        AV_PIX_FMT_RGB4,

        /// <summary>
        /// Packed RGB 1:2:1,  8bpp, (msb)1R 2G 1B(lsb).
        /// </summary>
        AV_PIX_FMT_RGB4_BYTE,

        /// <summary>
        /// Planar YUV 4:2:0, 12bpp, 1 plane for Y and 1 plane for the UV components, which are interleaved (first byte U and the following byte V).
        /// </summary>
        AV_PIX_FMT_NV12,

        /// <summary>
        /// As above, but U and V bytes are swapped.
        /// </summary>
        AV_PIX_FMT_NV21,

        /// <summary>
        /// Packed ARGB 8:8:8:8, 32bpp, ARGBARGB.
        /// </summary>
        AV_PIX_FMT_ARGB,

        /// <summary>
        /// Packed RGBA 8:8:8:8, 32bpp, RGBARGBA.
        /// </summary>
        AV_PIX_FMT_RGBA,

        /// <summary>
        /// Packed ABGR 8:8:8:8, 32bpp, ABGRABGR.
        /// </summary>
        AV_PIX_FMT_ABGR,

        /// <summary>
        /// Packed BGRA 8:8:8:8, 32bpp, BGRABGRA.
        /// </summary>
        AV_PIX_FMT_BGRA,

        /// <summary>
        /// 16bpp, big-endian grayscale.
        /// </summary>
        AV_PIX_FMT_GRAY16BE,

        /// <summary>
        /// 16bpp, little-endian grayscale.
        /// </summary>
        AV_PIX_FMT_GRAY16LE,

        /// <summary>
        /// Planar YUV 4:4:0 (1 Cr & Cb sample per 1x2 Y samples).
        /// </summary> 
        AV_PIX_FMT_YUV440P,

        /// <summary>
        /// Planar YUV 4:4:0 full scale (JPEG), deprecated in favor of AV_PIX_FMT_YUV440P and setting color_range.
        /// </summary>
        AV_PIX_FMT_YUVJ440P,

        /// <summary>
        /// Planar YUV 4:2:0, 20bpp, (1 Cr & Cb sample per 2x2 Y & A samples).
        /// </summary>
        AV_PIX_FMT_YUVA420P,

        /// <summary>
        /// H.264 HW decoding with VDPAU, data[0] contains a vdpau_render_state struct which contains the bitstream of the slices as well as various fields extracted from headers.
        /// </summary>
        AV_PIX_FMT_VDPAU_H264,

        /// <summary>
        /// MPEG-1 HW decoding with VDPAU, data[0] contains a vdpau_render_state struct which contains the bitstream of the slices as well as various fields extracted from headers.
        /// </summary>
        AV_PIX_FMT_VDPAU_MPEG1,

        /// <summary>
        /// MPEG-2 HW decoding with VDPAU, data[0] contains a vdpau_render_state struct which contains the bitstream of the slices as well as various fields extracted from headers.
        /// </summary>
        AV_PIX_FMT_VDPAU_MPEG2,

        /// <summary>
        /// WMV3 HW decoding with VDPAU, data[0] contains a vdpau_render_state struct which contains the bitstream of the slices as well as various fields extracted from headers.
        /// </summary>
        AV_PIX_FMT_VDPAU_WMV3,

        /// <summary>
        /// VC-1 HW decoding with VDPAU, data[0] contains a vdpau_render_state struct which contains the bitstream of the slices as well as various fields extracted from headers.
        /// </summary>
        AV_PIX_FMT_VDPAU_VC1,

        /// <summary>
        /// Packed RGB 16:16:16, 48bpp, 16R, 16G, 16B, the 2-byte value for each R/G/B component is stored as big-endian.
        /// </summary>
        AV_PIX_FMT_RGB48BE,

        /// <summary>
        /// acked RGB 16:16:16, 48bpp, 16R, 16G, 16B, the 2-byte value for each R/G/B component is stored as little-endian.
        /// </summary>
        AV_PIX_FMT_RGB48LE,

        /// <summary>
        /// Packed RGB 5:6:5, 16bpp, (msb)   5R 6G 5B(lsb), big-endian.
        /// </summary>
        AV_PIX_FMT_RGB565BE,

        /// <summary>
        /// Packed RGB 5:6:5, 16bpp, (msb) 5R 6G 5B(lsb), little-endian.
        /// </summary>
        AV_PIX_FMT_RGB565LE,

        /// <summary>
        /// Packed RGB 5:5:5, 16bpp, (msb)1X 5R 5G 5B(lsb), big-endian, X=unused/undefined.
        /// </summary>
        AV_PIX_FMT_RGB555BE,

        /// <summary>
        /// Packed RGB 5:5:5, 16bpp, (msb)1X 5R 5G 5B(lsb), little-endian, X=unused/undefined.
        /// </summary>
        AV_PIX_FMT_RGB555LE,

        /// <summary>
        /// Packed BGR 5:6:5, 16bpp, (msb) 5B 6G 5R(lsb), big-endian.
        /// </summary>
        AV_PIX_FMT_BGR565BE,

        /// <summary>
        /// Packed BGR 5:6:5, 16bpp, (msb) 5B 6G 5R(lsb), little-endian.
        /// </summary>
        AV_PIX_FMT_BGR565LE,

        /// <summary>
        /// Packed BGR 5:5:5, 16bpp, (msb)1X 5B 5G 5R(lsb), big-endian, X=unused/undefined.
        /// </summary>
        AV_PIX_FMT_BGR555BE,

        /// <summary>
        /// Packed BGR 5:5:5, 16bpp, (msb)1X 5B 5G 5R(lsb), little-endian, X=unused/undefined.
        /// </summary>
        AV_PIX_FMT_BGR555LE,

        /// <summary>
        /// HW acceleration through VA API at motion compensation entry-point, Picture.data[3] contains a vaapi_render_state struct which contains macroblocks as well as various fields extracted from headers.
        /// </summary>
        AV_PIX_FMT_VAAPI_MOCO,

        /// <summary>
        /// HW acceleration through VA API at IDCT entry-point, Picture.data[3] contains a vaapi_render_state struct which contains fields extracted from headers.
        /// </summary>
        AV_PIX_FMT_VAAPI_IDCT,

        /// <summary>
        /// HW decoding through VA API, Picture.data[3] contains a VASurfaceID.
        /// </summary>
        AV_PIX_FMT_VAAPI_VLD,

        /// <summary>
        /// HW decoding through VA API, Picture.data[3] contains a VASurfaceID.
        /// </summary>
        AV_PIX_FMT_VAAPI = AV_PIX_FMT_VAAPI_VLD,

        /// <summary>
        /// Planar YUV 4:2:0, 24bpp, (1 Cr & Cb sample per 2x2 Y samples), little-endian.
        /// </summary>
        AV_PIX_FMT_YUV420P16LE,

        /// <summary>
        /// Planar YUV 4:2:0, 24bpp, (1 Cr & Cb sample per 2x2 Y samples), big-endian.
        /// </summary>
        AV_PIX_FMT_YUV420P16BE,

        /// <summary>
        /// Planar YUV 4:2:2, 32bpp, (1 Cr & Cb sample per 2x1 Y samples), little-endian.
        /// </summary>
        AV_PIX_FMT_YUV422P16LE,

        /// <summary>
        /// Planar YUV 4:2:2, 32bpp, (1 Cr & Cb sample per 2x1 Y samples), big-endian.
        /// </summary>
        AV_PIX_FMT_YUV422P16BE,

        /// <summary>
        /// Planar YUV 4:4:4, 48bpp, (1 Cr & Cb sample per 1x1 Y samples), little-endian.
        /// </summary>
        AV_PIX_FMT_YUV444P16LE,

        /// <summary>
        /// Planar YUV 4:4:4, 48bpp, (1 Cr & Cb sample per 1x1 Y samples), big-endian.
        /// </summary>
        AV_PIX_FMT_YUV444P16BE,

        /// <summary>
        /// MPEG-4 HW decoding with VDPAU, data[0] contains a vdpau_render_state struct which contains the bitstream of the slices as well as various fields extracted from headers.
        /// </summary>
        AV_PIX_FMT_VDPAU_MPEG4,

        /// <summary>
        /// HW decoding through DXVA2, Picture.data[3] contains a LPDIRECT3DSURFACE9 pointer.
        /// </summary>
        AV_PIX_FMT_DXVA2_VLD,

        /// <summary>
        /// Packed RGB 4:4:4, 16bpp, (msb)4X 4R 4G 4B(lsb), little-endian, X=unused/undefined.
        /// </summary>
        AV_PIX_FMT_RGB444LE,

        /// <summary>
        /// Packed RGB 4:4:4, 16bpp, (msb)4X 4R 4G 4B(lsb), big-endian, X=unused/undefined.
        /// </summary>
        AV_PIX_FMT_RGB444BE,

        /// <summary>
        /// Packed BGR 4:4:4, 16bpp, (msb)4X 4B 4G 4R(lsb), little-endian, X=unused/undefined.
        /// </summary>
        AV_PIX_FMT_BGR444LE,

        /// <summary>
        /// Packed BGR 4:4:4, 16bpp, (msb)4X 4B 4G 4R(lsb), big-endian, X=unused/undefined.
        /// </summary>
        AV_PIX_FMT_BGR444BE,

        /// <summary>
        /// 8 bits gray, 8 bits alpha.
        /// </summary>
        AV_PIX_FMT_YA8,

        /// <summary>
        /// Alias for AV_PIX_FMT_YA8.
        /// </summary>
        AV_PIX_FMT_Y400A = AV_PIX_FMT_YA8,

        /// <summary>
        /// Alias for AV_PIX_FMT_YA8.
        /// </summary>
        AV_PIX_FMT_GRAY8A = AV_PIX_FMT_YA8,

        /// <summary>
        /// Packed RGB 16:16:16, 48bpp, 16B, 16G, 16R, the 2-byte value for each R/G/B component is stored as big-endian.
        /// </summary>
        AV_PIX_FMT_BGR48BE,

        /// <summary>
        /// Packed RGB 16:16:16, 48bpp, 16B, 16G, 16R, the 2-byte value for each R/G/B component is stored as little-endian.
        /// </summary>
        AV_PIX_FMT_BGR48LE,

        /// <summary>
        /// Planar YUV 4:2:0, 13.5bpp, (1 Cr & Cb sample per 2x2 Y samples), big-endian.
        /// </summary>
        AV_PIX_FMT_YUV420P9BE,

        /// <summary>
        /// Planar YUV 4:2:0, 13.5bpp, (1 Cr & Cb sample per 2x2 Y samples), little-endian.
        /// </summary>
        AV_PIX_FMT_YUV420P9LE,

        /// <summary>
        /// Planar YUV 4:2:0, 15bpp, (1 Cr & Cb sample per 2x2 Y samples), big-endian.
        /// </summary>
        AV_PIX_FMT_YUV420P10BE,

        /// <summary>
        /// Planar YUV 4:2:0, 15bpp, (1 Cr & Cb sample per 2x2 Y samples), little-endian.
        /// </summary>
        AV_PIX_FMT_YUV420P10LE,

        /// <summary>
        /// Planar YUV 4:2:2, 20bpp, (1 Cr & Cb sample per 2x1 Y samples), big-endian.
        /// </summary>
        AV_PIX_FMT_YUV422P10BE,

        /// <summary>
        /// Planar YUV 4:2:2, 20bpp, (1 Cr & Cb sample per 2x1 Y samples), little-endian.
        /// </summary>
        AV_PIX_FMT_YUV422P10LE,

        /// <summary>
        /// Planar YUV 4:4:4, 27bpp, (1 Cr & Cb sample per 1x1 Y samples), big-endian.
        /// </summary>
        AV_PIX_FMT_YUV444P9BE,

        /// <summary>
        /// Planar YUV 4:4:4, 27bpp, (1 Cr & Cb sample per 1x1 Y samples), little-endian.
        /// </summary>
        AV_PIX_FMT_YUV444P9LE,

        /// <summary>
        /// Planar YUV 4:4:4, 30bpp, (1 Cr & Cb sample per 1x1 Y samples), big-endian.
        /// </summary>
        AV_PIX_FMT_YUV444P10BE,

        /// <summary>
        /// Planar YUV 4:4:4, 30bpp, (1 Cr & Cb sample per 1x1 Y samples), little-endian.
        /// </summary>
        AV_PIX_FMT_YUV444P10LE,

        /// <summary>
        /// Planar YUV 4:2:2, 18bpp, (1 Cr & Cb sample per 2x1 Y samples), big-endian.
        /// </summary>
        AV_PIX_FMT_YUV422P9BE,

        /// <summary>
        /// Planar YUV 4:2:2, 18bpp, (1 Cr & Cb sample per 2x1 Y samples), little-endian.
        /// </summary>
        AV_PIX_FMT_YUV422P9LE,

        /// <summary>
        /// Hardware decoding through VDA.
        /// </summary>
        AV_PIX_FMT_VDA_VLD,

        /// <summary>
        /// Planar GBR 4:4:4 24bpp.
        /// </summary>
        AV_PIX_FMT_GBRP,

        /// <summary>
        /// Planar GBR 4:4:4 27bpp, big-endian.
        /// </summary>
        AV_PIX_FMT_GBRP9BE,

        /// <summary>
        /// Planar GBR 4:4:4 27bpp, little-endian.
        /// </summary>
        AV_PIX_FMT_GBRP9LE,

        /// <summary>
        /// Planar GBR 4:4:4 30bpp, big-endian.
        /// </summary>
        AV_PIX_FMT_GBRP10BE,

        /// <summary>
        /// Planar GBR 4:4:4 30bpp, little-endian.
        /// </summary>
        AV_PIX_FMT_GBRP10LE,

        /// <summary>
        /// Planar GBR 4:4:4 48bpp, big-endian.
        /// </summary>
        AV_PIX_FMT_GBRP16BE,

        /// <summary>
        /// Planar GBR 4:4:4 48bpp, little-endian.
        /// </summary>
        AV_PIX_FMT_GBRP16LE,

        /// <summary>
        /// Planar YUV 4:2:2 24bpp, (1 Cr & Cb sample per 2x1 Y & A samples).
        /// </summary>
        AV_PIX_FMT_YUVA422P,

        /// <summary>
        /// Planar YUV 4:4:4 32bpp, (1 Cr & Cb sample per 1x1 Y & A samples).
        /// </summary>
        AV_PIX_FMT_YUVA444P,

        /// <summary>
        /// Planar YUV 4:2:0 22.5bpp, (1 Cr & Cb sample per 2x2 Y & A samples), big-endian.
        /// </summary>
        AV_PIX_FMT_YUVA420P9BE,

        /// <summary>
        /// Planar YUV 4:2:0 22.5bpp, (1 Cr & Cb sample per 2x2 Y & A samples), little-endian.
        /// </summary>
        AV_PIX_FMT_YUVA420P9LE,

        /// <summary>
        /// Planar YUV 4:2:2 27bpp, (1 Cr & Cb sample per 2x1 Y & A samples), big-endian.
        /// </summary>
        AV_PIX_FMT_YUVA422P9BE,

        /// <summary>
        /// Planar YUV 4:2:2 27bpp, (1 Cr & Cb sample per 2x1 Y & A samples), little-endian.
        /// </summary>
        AV_PIX_FMT_YUVA422P9LE,

        /// <summary>
        /// Planar YUV 4:4:4 36bpp, (1 Cr & Cb sample per 1x1 Y & A samples), big-endian.
        /// </summary>
        AV_PIX_FMT_YUVA444P9BE,

        /// <summary>
        /// Planar YUV 4:4:4 36bpp, (1 Cr & Cb sample per 1x1 Y & A samples), little-endian.
        /// </summary>
        AV_PIX_FMT_YUVA444P9LE,

        /// <summary>
        /// Planar YUV 4:2:0 25bpp, (1 Cr & Cb sample per 2x2 Y & A samples, big-endian).
        /// </summary>
        AV_PIX_FMT_YUVA420P10BE,

        /// <summary>
        /// Planar YUV 4:2:0 25bpp, (1 Cr & Cb sample per 2x2 Y & A samples, little-endian).
        /// </summary>
        AV_PIX_FMT_YUVA420P10LE,

        /// <summary>
        /// Planar YUV 4:2:2 30bpp, (1 Cr & Cb sample per 2x1 Y & A samples, big-endian).
        /// </summary>
        AV_PIX_FMT_YUVA422P10BE,

        /// <summary>
        /// Planar YUV 4:2:2 30bpp, (1 Cr & Cb sample per 2x1 Y & A samples, little-endian).
        /// </summary>
        AV_PIX_FMT_YUVA422P10LE,

        /// <summary>
        /// Planar YUV 4:4:4 40bpp, (1 Cr & Cb sample per 1x1 Y & A samples, big-endian).
        /// </summary>
        AV_PIX_FMT_YUVA444P10BE,

        /// <summary>
        /// Planar YUV 4:4:4 40bpp, (1 Cr & Cb sample per 1x1 Y & A samples, little-endian).
        /// </summary>
        AV_PIX_FMT_YUVA444P10LE,

        /// <summary>
        /// Planar YUV 4:2:0 40bpp, (1 Cr & Cb sample per 2x2 Y & A samples, big-endian).
        /// </summary>
        AV_PIX_FMT_YUVA420P16BE,

        /// <summary>
        /// Planar YUV 4:2:0 40bpp, (1 Cr & Cb sample per 2x2 Y & A samples, little-endian).
        /// </summary>
        AV_PIX_FMT_YUVA420P16LE,

        /// <summary>
        /// Planar YUV 4:2:2 48bpp, (1 Cr & Cb sample per 2x1 Y & A samples, big-endian).
        /// </summary>
        AV_PIX_FMT_YUVA422P16BE,

        /// <summary>
        /// Planar YUV 4:2:2 48bpp, (1 Cr & Cb sample per 2x1 Y & A samples, little-endian).
        /// </summary>
        AV_PIX_FMT_YUVA422P16LE,

        /// <summary>
        /// Planar YUV 4:4:4 64bpp, (1 Cr & Cb sample per 1x1 Y & A samples, big-endian).
        /// </summary>
        AV_PIX_FMT_YUVA444P16BE,

        /// <summary>
        /// Planar YUV 4:4:4 64bpp, (1 Cr & Cb sample per 1x1 Y & A samples, little-endian).
        /// </summary>
        AV_PIX_FMT_YUVA444P16LE,

        /// <summary>
        /// HW acceleration through VDPAU, Picture.data[3] contains a VdpVideoSurface.
        /// </summary>
        AV_PIX_FMT_VDPAU,

        /// <summary>
        /// Packed XYZ 4:4:4, 36 bpp, (msb) 12X, 12Y, 12Z (lsb), the 2-byte value for each X/Y/Z is stored as little-endian, the 4 lower bits are set to 0.
        /// </summary>
        AV_PIX_FMT_XYZ12LE,

        /// <summary>
        /// Packed XYZ 4:4:4, 36 bpp, (msb) 12X, 12Y, 12Z (lsb), the 2-byte value for each X/Y/Z is stored as big-endian, the 4 lower bits are set to 0.
        /// </summary>
        AV_PIX_FMT_XYZ12BE,

        /// <summary>
        /// Interleaved chroma YUV 4:2:2, 16bpp, (1 Cr & Cb sample per 2x1 Y samples).
        /// </summary>
        AV_PIX_FMT_NV16,

        /// <summary>
        /// Interleaved chroma YUV 4:2:2, 20bpp, (1 Cr & Cb sample per 2x1 Y samples), little-endian.
        /// </summary>
        AV_PIX_FMT_NV20LE,

        /// <summary>
        /// Interleaved chroma YUV 4:2:2, 20bpp, (1 Cr & Cb sample per 2x1 Y samples), big-endian.
        /// </summary>
        AV_PIX_FMT_NV20BE,

        /// <summary>
        /// Packed RGBA 16:16:16:16, 64bpp, 16R, 16G, 16B, 16A, the 2-byte value for each R/G/B/A component is stored as big-endian.
        /// </summary>
        AV_PIX_FMT_RGBA64BE,

        /// <summary>
        /// Packed RGBA 16:16:16:16, 64bpp, 16R, 16G, 16B, 16A, the 2-byte value for each R/G/B/A component is stored as little-endian.
        /// </summary>
        AV_PIX_FMT_RGBA64LE,

        /// <summary>
        /// Packed RGBA 16:16:16:16, 64bpp, 16B, 16G, 16R, 16A, the 2-byte value for each R/G/B/A component is stored as big-endian.
        /// </summary>
        AV_PIX_FMT_BGRA64BE,

        /// <summary>
        /// Packed RGBA 16:16:16:16, 64bpp, 16B, 16G, 16R, 16A, the 2-byte value for each R/G/B/A component is stored as little-endian.
        /// </summary>
        AV_PIX_FMT_BGRA64LE,

        /// <summary>
        /// Packed YUV 4:2:2, 16bpp, Y0 Cr Y1 Cb.
        /// </summary>
        AV_PIX_FMT_YVYU422,

        /// <summary>
        /// HW acceleration through VDA, data[3] contains a CVPixelBufferRef.
        /// </summary>
        AV_PIX_FMT_VDA,

        /// <summary>
        /// 16 bits gray, 16 bits alpha (big-endian).
        /// </summary>
        AV_PIX_FMT_YA16BE,

        /// <summary>
        /// 16 bits gray, 16 bits alpha (little-endian).
        /// </summary>
        AV_PIX_FMT_YA16LE,

        /// <summary>
        /// Planar GBRA 4:4:4:4 32bpp.
        /// </summary>
        AV_PIX_FMT_GBRAP,

        /// <summary>
        /// Planar GBRA 4:4:4:4 64bpp, big-endian.
        /// </summary>
        AV_PIX_FMT_GBRAP16BE,

        /// <summary>
        /// Planar GBRA 4:4:4:4 64bpp, little-endian.
        /// </summary>
        AV_PIX_FMT_GBRAP16LE,

        /// <summary>
        /// HW acceleration through QSV, data[3] contains a pointer to the mfxFrameSurface1 structure.
        /// </summary>
        AV_PIX_FMT_QSV,

        /// <summary>
        /// HW acceleration though MMAL, data[3] contains a pointer to the MMAL_BUFFER_HEADER_T structure.
        /// </summary>
        AV_PIX_FMT_MMAL,

        /// <summary>
        /// HW decoding through Direct3D11, Picture.data[3] contains a ID3D11VideoDecoderOutputView pointer.
        /// </summary>
        AV_PIX_FMT_D3D11VA_VLD,

        /// <summary>
        /// HW acceleration through CUDA. data[i] contain CUdeviceptr pointers exactly as for system memory frames.
        /// </summary>
        AV_PIX_FMT_CUDA,

        /// <summary>
        /// Packed RGB 8:8:8, 32bpp, XRGBXRGB X=unused/undefined.
        /// </summary>
        AV_PIX_FMT_0RGB=0x123+4,

        /// <summary>
        /// Packed RGB 8:8:8, 32bpp, RGBXRGBX X=unused/undefined.
        /// </summary>
        AV_PIX_FMT_RGB0,

        /// <summary>
        /// Packed BGR 8:8:8, 32bpp, XBGRXBGR X=unused/undefined.
        /// </summary>
        AV_PIX_FMT_0BGR,

        /// <summary>
        /// Packed BGR 8:8:8, 32bpp, BGRXBGRX X=unused/undefined.
        /// </summary>
        AV_PIX_FMT_BGR0,

        /// <summary>
        /// Planar YUV 4:2:0,18bpp, (1 Cr & Cb sample per 2x2 Y samples), big-endian.
        /// </summary>
        AV_PIX_FMT_YUV420P12BE,

        /// <summary>
        /// Planar YUV 4:2:0,18bpp, (1 Cr & Cb sample per 2x2 Y samples), little-endian.
        /// </summary>
        AV_PIX_FMT_YUV420P12LE,

        /// <summary>
        /// Planar YUV 4:2:0,21bpp, (1 Cr & Cb sample per 2x2 Y samples), big-endian.
        /// </summary>
        AV_PIX_FMT_YUV420P14BE,

        /// <summary>
        /// Planar YUV 4:2:0,21bpp, (1 Cr & Cb sample per 2x2 Y samples), little-endian.
        /// </summary>
        AV_PIX_FMT_YUV420P14LE,

        /// <summary>
        /// Planar YUV 4:2:2,24bpp, (1 Cr & Cb sample per 2x1 Y samples), big-endian.
        /// </summary>
        AV_PIX_FMT_YUV422P12BE,

        /// <summary>
        /// Planar YUV 4:2:2,24bpp, (1 Cr & Cb sample per 2x1 Y samples), little-endian.
        /// </summary>
        AV_PIX_FMT_YUV422P12LE,

        /// <summary>
        /// Planar YUV 4:2:2,28bpp, (1 Cr & Cb sample per 2x1 Y samples), big-endian.
        /// </summary> ///< p
        AV_PIX_FMT_YUV422P14BE,

        /// <summary>
        /// Planar YUV 4:2:2,28bpp, (1 Cr & Cb sample per 2x1 Y samples), little-endian.
        /// </summary>
        AV_PIX_FMT_YUV422P14LE,

        /// <summary>
        /// Planar YUV 4:4:4,36bpp, (1 Cr & Cb sample per 1x1 Y samples), big-endian.
        /// </summary>
        AV_PIX_FMT_YUV444P12BE,

        /// <summary>
        /// Planar YUV 4:4:4,36bpp, (1 Cr & Cb sample per 1x1 Y samples), little-endian.
        /// </summary>
        AV_PIX_FMT_YUV444P12LE,

        /// <summary>
        /// Planar YUV 4:4:4,42bpp, (1 Cr & Cb sample per 1x1 Y samples), big-endian.
        /// </summary>
        AV_PIX_FMT_YUV444P14BE,

        /// <summary>
        /// Planar YUV 4:4:4,42bpp, (1 Cr & Cb sample per 1x1 Y samples), little-endian.
        /// </summary>
        AV_PIX_FMT_YUV444P14LE,

        /// <summary>
        /// Planar GBR 4:4:4 36bpp, big-endian.
        /// </summary>
        AV_PIX_FMT_GBRP12BE,

        /// <summary>
        /// Planar GBR 4:4:4 36bpp, little-endian.
        /// </summary>
        AV_PIX_FMT_GBRP12LE,

        /// <summary>
        /// Planar GBR 4:4:4 42bpp, big-endian.
        /// </summary>
        AV_PIX_FMT_GBRP14BE,

        /// <summary>
        /// Planar GBR 4:4:4 42bpp, little-endian.
        /// </summary>
        AV_PIX_FMT_GBRP14LE,

        /// <summary>
        /// Planar YUV 4:1:1, 12bpp, (1 Cr & Cb sample per 4x1 Y samples) full scale (JPEG), deprecated in favor of AV_PIX_FMT_YUV411P and setting color_range.
        /// </summary>
        AV_PIX_FMT_YUVJ411P,

        /// <summary>
        /// Bayer, BGBG..(odd line), GRGR..(even line), 8-bit samples.
        /// </summary>
        AV_PIX_FMT_BAYER_BGGR8,

        /// <summary>
        /// Bayer, RGRG..(odd line), GBGB..(even line), 8-bit samples.
        /// </summary>
        AV_PIX_FMT_BAYER_RGGB8,

        /// <summary>
        /// Bayer, GBGB..(odd line), RGRG..(even line), 8-bit samples.
        /// </summary>
        AV_PIX_FMT_BAYER_GBRG8,

        /// <summary>
        /// Bayer, GRGR..(odd line), BGBG..(even line), 8-bit samples.
        /// </summary>
        AV_PIX_FMT_BAYER_GRBG8,

        /// <summary>
        /// Bayer, BGBG..(odd line), GRGR..(even line), 16-bit samples, little-endian.
        /// </summary>
        AV_PIX_FMT_BAYER_BGGR16LE,

        /// <summary>
        /// Bayer, BGBG..(odd line), GRGR..(even line), 16-bit samples, big-endian.
        /// </summary>
        AV_PIX_FMT_BAYER_BGGR16BE,

        /// <summary>
        /// Bayer, RGRG..(odd line), GBGB..(even line), 16-bit samples, little-endian.
        /// </summary>
        AV_PIX_FMT_BAYER_RGGB16LE,

        /// <summary>
        /// Bayer, RGRG..(odd line), GBGB..(even line), 16-bit samples, big-endian.
        /// </summary>
        AV_PIX_FMT_BAYER_RGGB16BE,

        /// <summary>
        /// Bayer, GBGB..(odd line), RGRG..(even line), 16-bit samples, little-endian.
        /// </summary>
        AV_PIX_FMT_BAYER_GBRG16LE,

        /// <summary>
        /// Bayer, GBGB..(odd line), RGRG..(even line), 16-bit samples, big-endian.
        /// </summary>
        AV_PIX_FMT_BAYER_GBRG16BE,

        /// <summary>
        /// Bayer, GRGR..(odd line), BGBG..(even line), 16-bit samples, little-endian.
        /// </summary>
        AV_PIX_FMT_BAYER_GRBG16LE,

        /// <summary>
        /// Bayer, GRGR..(odd line), BGBG..(even line), 16-bit samples, big-endian.
        /// </summary>
        AV_PIX_FMT_BAYER_GRBG16BE,

        /// <summary>
        /// Planar YUV 4:4:0,20bpp, (1 Cr & Cb sample per 1x2 Y samples), little-endian.
        /// </summary>
        AV_PIX_FMT_YUV440P10LE,

        /// <summary>
        /// Planar YUV 4:4:0,20bpp, (1 Cr & Cb sample per 1x2 Y samples), big-endian.
        /// </summary>
        AV_PIX_FMT_YUV440P10BE,

        /// <summary>
        /// Planar YUV 4:4:0,24bpp, (1 Cr & Cb sample per 1x2 Y samples), little-endian.
        /// </summary>
        AV_PIX_FMT_YUV440P12LE,

        /// <summary>
        /// Planar YUV 4:4:0,24bpp, (1 Cr & Cb sample per 1x2 Y samples), big-endian.
        /// </summary>
        AV_PIX_FMT_YUV440P12BE,

        /// <summary>
        /// Packed AYUV 4:4:4,64bpp (1 Cr & Cb sample per 1x1 Y & A samples), little-endian.
        /// </summary>
        AV_PIX_FMT_AYUV64LE,

        /// <summary>
        /// Packed AYUV 4:4:4,64bpp (1 Cr & Cb sample per 1x1 Y & A samples), big-endian.
        /// </summary>
        AV_PIX_FMT_AYUV64BE,

        /// <summary>
        /// Hardware decoding through Videotoolbox.
        /// </summary>
        AV_PIX_FMT_VIDEOTOOLBOX,

        /// <summary>
        /// Like NV12, with 10bpp per component, data in the high bits, zeros in the low bits, little-endian.
        /// </summary>
        AV_PIX_FMT_P010LE,

        /// <summary>
        /// Like NV12, with 10bpp per component, data in the high bits, zeros in the low bits, big-endian.
        /// </summary>
        AV_PIX_FMT_P010BE,

        /// <summary>
        /// Planar GBR 4:4:4:4 48bpp, big-endian.
        /// </summary>
        AV_PIX_FMT_GBRAP12BE,

        /// <summary>
        /// Planar GBR 4:4:4:4 48bpp, little-endian.
        /// </summary>
        AV_PIX_FMT_GBRAP12LE,

        /// <summary>
        /// Planar GBR 4:4:4:4 40bpp, big-endian.
        /// </summary>
        AV_PIX_FMT_GBRAP10BE,

        /// <summary>
        /// Planar GBR 4:4:4:4 40bpp, little-endian.
        /// </summary>
        AV_PIX_FMT_GBRAP10LE,

        /// <summary>
        /// Number of pixel formats, DO NOT USE THIS if you want to link with shared libav* because the number of formats might differ between versions.
        /// </summary>
        AV_PIX_FMT_NB,
    }
}