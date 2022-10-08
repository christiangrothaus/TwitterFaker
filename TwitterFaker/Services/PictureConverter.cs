using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace TwitterFaker.Services
{
    public class PictureConverter
    {
        public static string IFormFileToBase64(IFormFile file)
        {
            string result;
            using (MemoryStream ms = new MemoryStream())
            { 
                file.CopyTo(ms);
                var fileBytes = ms.ToArray();
                result = Convert.ToBase64String(fileBytes);
                ms.Close();
            }
            return result;
        }
    }
}
