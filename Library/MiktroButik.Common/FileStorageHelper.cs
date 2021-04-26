using Microsoft.AspNetCore.Http;
using Miktobutik.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace MikroButik.Common
{
    public class FileStorageHelper
    {
        public static ResponseModel<string> UploadFile(IFormFile file)
        {
            if (file.Length == 0)
            {
                return new ResponseModel<string>() { Message = "Dosya yok" };
            }
            var destFileName = CreateFullPath(file);

            string sourceFileName = Path.Combine(Environment.CurrentDirectory, "wwwroot", "ProductImages", destFileName.GetValueOrDefault("PathToSavedOnServer"));

            using (var stream = new FileStream(sourceFileName, FileMode.OpenOrCreate))
            {
                file.CopyTo(stream);
            }

            // File.Move(sourceFileName, destFileName.GetValueOrDefault("PathToSavedOnServer"));
            return new ResponseModel<string>() { Success = true, result = destFileName.GetValueOrDefault("DbRoute") };
        }

        public static ResponseModel DeleteFile(string path)
        {
            try
            {
                File.Delete(Path.Combine(Environment.CurrentDirectory, path));
            }
            catch (System.Exception exception)
            {

                return new ResponseModel() { Success = false, Message = exception.Message };
            }
            return new ResponseModel() { Success = true, Message = "Dosya Silindi",result = Path.Combine(Environment.CurrentDirectory, path) };
        }

        public static ResponseModel<string> UpdateFile(IFormFile file, string currentImageFile)
        {
            if (file.Length == 0)
            {
                return new ResponseModel<string>() { Success = false, Message = "Lütfen dosya ekleyin" };
            }

            var destFileName = CreateFullPath(file);

            using (var stream = new FileStream(destFileName.GetValueOrDefault("PathToSavedOnServer"), FileMode.Create))
            {
                file.CopyTo(stream);
            }

            File.Delete(currentImageFile);

            return new ResponseModel<string>() { Success = true, result = destFileName.GetValueOrDefault("DbRoute") };
        }

        private static Dictionary<string, string> CreateFullPath(IFormFile file)
        {
            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileExtension = fileInfo.Extension;
            string photoRootDirectory = Path.Combine(Environment.CurrentDirectory, "wwwroot", "ProductImages");
            string fileName = Guid.NewGuid().ToString() + fileExtension;

            string dbRoute = Path.Combine("ProductImages", fileName);
            string pathToSavedOnServer = Path.Combine(photoRootDirectory, fileName);

            Dictionary<string, string> result = new Dictionary<string, string>();
            result.Add("DbRoute", dbRoute);
            result.Add("PathToSavedOnServer", pathToSavedOnServer);

            return result;

        }
    }
}
