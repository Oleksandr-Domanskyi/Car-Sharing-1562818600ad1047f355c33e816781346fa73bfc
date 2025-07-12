using CarSharingDomain.DomainModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharingApplication.Handler.ImageHandler
{
    public static class ImageHandler
    {
        public static byte[] GetBytesFromIFormFile(IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }
        public static List<Image> MapImages(List<IFormFile> images)
        {
            // Map IFormFile instances to Image instances
            return images.Select(image => new Image
            {
                Name = image.FileName,
                FileType = image.ContentType,
                DataFile = GetBytesFromIFormFile(image)
            }).ToList();
        }
        public static GlobalProfileImage MapGlobalImages(IFormFile images)
        {
            // Map IFormFile instances to Image instances
            return new GlobalProfileImage
            {
                Name = images.FileName,
                FileType = images.ContentType,
                DataFile = GetBytesFromIFormFile(images)
            };
        }

    }
}
