using ann_shop_server.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace ann_shop_server.Utils
{
    public class Thumbnail
    {
        private const string SERVER_IMAGE = "http://hethongann.com";
        public enum Size
        {
            Source,
            Micro,
            Small,
            Normal,
            Large
        }

        public static string getURL(string image, Size size)
        {
            if (String.IsNullOrEmpty(image))
            {
                return String.Format("{0}/Ann/image/placeholder.png", SERVER_IMAGE);
            }

            var directory = String.Empty;
            switch (size)
            {
                case Size.Micro:
                    directory = "/85x113";
                    break;
                case Size.Small:
                    directory = "/159x212";
                    break;
                case Size.Normal:
                    directory = "/240x320";
                    break;
                case Size.Large:
                    directory = "/350x467";
                    break;
                default:
                    directory = String.Empty;
                    break;
            }
            return String.Format("{0}/uploads/images{1}/{2}", SERVER_IMAGE, directory, image);
        }

        public static List<ThumbnailModel> getALL(string image)
        {
            var thumbnails = new List<ThumbnailModel>();
            // 85x113
            thumbnails.Add(new ThumbnailModel() { size = "85x113", url = getURL(image, Size.Micro) });
            // 159x212
            thumbnails.Add(new ThumbnailModel() { size = "159x212", url = getURL(image, Size.Small) });
            // 240x320
            thumbnails.Add(new ThumbnailModel() { size = "240x320", url = getURL(image, Size.Normal) });
            // 350x467
            thumbnails.Add(new ThumbnailModel() { size = "350x467", url = getURL(image, Size.Large) });

            return thumbnails;
        }
    }
}