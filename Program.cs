using System;

namespace System.Media.FFMpeg.Interop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(AVCodec.avcodec_version().ToString());
        }
    }
}
