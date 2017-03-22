using System.Drawing.Imaging;
using System.IO;
using System.Web.Mvc;
using Light.Framework.Core.Enums;
using Light.Framework.Core.Imaging;
using Light.Framework.Core.Utilities;
using Light.Framework.Web.Base.Images;

namespace Light.Framework.Web.Base.Controllers
{
    public class ImageController : Controller
    {
        public FilePathResult Index(ImageParameter parameter, string path)
        {
            if (parameter == null)
            {
                return File(Server.MapPath("~/_storage/css/404.png"), "image/png");
            }
            parameter = parameter.GetFixed(new DefaultImageParameterFixer());
            var physicalPath = Server.MapPath(parameter.GetRelativePath());
            var contentType = "image/" + parameter.Format;
            
            lock (string.Intern(physicalPath))
            {
                if (System.IO.File.Exists(physicalPath))
                {
                    Response.AddHeader("ETag", "0");
                    Response.AddHeader("Last-Modified", "Thu, 01 Oct 2015 12:07:58 GMT");
                    Response.AddHeader("Cache-Control", "public");
                    return File(physicalPath, contentType);
                }
                var physicalFolder = Path.GetDirectoryName(physicalPath);
                IoHelper.CreateDirectoryIfNotExists(physicalFolder);
                var originalPath = path;
                if (string.IsNullOrEmpty(originalPath))
                {
                    return null;
                }

                var originalFile = Server.MapPath(originalPath);
                if (!System.IO.File.Exists(originalFile))
                {
                    return null;
                }
                using (var sysImage = System.Drawing.Image.FromFile(originalFile))
                {
                    if (parameter.ImageFormat == ImageFormat.Gif)
                    {
                        sysImage.Save(physicalPath, ImageFormat.Gif);
                    }
                    else
                    {
                        using (var sizedImage = sysImage.ToSize(parameter.Size.GetSize()))
                        {
                            sizedImage.SaveToFileInQuality(physicalPath, parameter.ImageFormat);
                        }
                    }
                }
            }
            return File(physicalPath, contentType);
        }

        public FilePathResult SystemDefault(ImageSize size, string name, string format)
        {
            var path = string.Format("/_storage/defaultimages/{0}/{1}.{2}", size, name, format);
            return File(Server.MapPath(path), "image/" + format);
        }

    }
}
