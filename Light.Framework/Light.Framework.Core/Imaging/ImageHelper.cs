using System;
using System.Drawing.Imaging;
using Light.Framework.Core.Enums;

namespace Light.Framework.Core.Imaging
{
    public class ImageHelper
    {

        public static string GenerateKey(ImageType type, Guid id, ImageFormat format)
        {
            var yearMonth = DateTime.Now.ToString("yyyyMM");
            return string.Format("t{0}t{3}-{1:n}{2}", (int)type, id, format.GetExtension(), yearMonth);
        }

        /// <summary>
        /// returns "/img/{size}/default-{name}.{format}", "img/{size}/t{imageType}t{yearMonth}-{id}.{format}"
        /// </summary>
        /// <param name="key">
        /// t20t201410-6C294E0437664E3FA99C0CBAA4E8CCD1.png
        /// default-websitelogo.png
        /// </param>
        /// <param name="size"></param>
        /// <returns>
        /// e.g. /img/full/t20t201410-6C294E0437664E3FA99C0CBAA4E8CCD1.png
        /// e.g. /img/s80x80/t20t201410-6C294E0437664E3FA99C0CBAA4E8CCD1.png
        /// e.g. /img/s80x80/default-websitelogo.png
        /// </returns>
        public static string BuildSrc(string key, ImageSize size)
        {
            if (string.IsNullOrEmpty(key))
            {
                return "/_storage/css/404.png";
            }
            if (key.IndexOf("/", StringComparison.OrdinalIgnoreCase) == -1)
            {
                return $"/img/{size}/{key}";
            }
            return key;
        }
    }
}