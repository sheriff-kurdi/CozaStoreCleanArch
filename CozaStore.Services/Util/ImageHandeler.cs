using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CozaStore.Services.Util
{
    public  class ImageHandeler
    {


        public static string UploadImage(IFormFile photoBinary, string webRootPath)
        {
            //add image folders
            string uploadsFolder = Path.Combine(webRootPath, "Uploads");

            //add image one
            string uniqFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(photoBinary.FileName);
            string filePath = Path.Combine(uploadsFolder, uniqFileName);
            FileStream fs = new FileStream(filePath, FileMode.Create);
            photoBinary.CopyTo(fs);
            fs.Dispose();

            return uniqFileName;

        }

        public static bool DeleteImage(string imageName, string webRootPath)
        {

            string uploadsFolder = Path.Combine(webRootPath, "Uploads");


            try
            {
                // Check if file exists with its full path
                if (File.Exists(Path.Combine(uploadsFolder, imageName)))
                {
                    // If file found, delete it    
                    File.Delete(Path.Combine(uploadsFolder, imageName));

                    Console.WriteLine("File deleted.");
                }
                return true;
            }
            catch (IOException ioExp)
            {
                Console.WriteLine(ioExp.Message);
                return false;
            }
        }
    }
}
