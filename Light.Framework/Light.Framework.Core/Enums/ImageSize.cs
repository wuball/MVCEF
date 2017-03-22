﻿using System.Drawing;

namespace Light.Framework.Core.Enums
{
    public enum ImageSize
    {
        Full = 0,
        S50X50 = 20,
        S80X80 = 21,
        S150X150 = 22,
        W500 = 23
    }

    public static class ImageSizeExtensions
    {
        public static Size GetSize(this ImageSize size)
        {
            switch (size)
            {
                case ImageSize.S50X50:
                    return new Size(100, 100);
                case ImageSize.S80X80:
                    return new Size(160, 160);
                case ImageSize.S150X150:
                    return new Size(300, 300);
                case ImageSize.W500:
                    return new Size(1000, 0);
                default:
                case ImageSize.Full:
                    return new Size();
            }
        }
    }
}