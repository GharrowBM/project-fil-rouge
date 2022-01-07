using System;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace FilRouge.API.Services
{
    public class UploadService
    {
        private void MakeDir(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
        
        public string Upload(IFormFile file)
        {
            string fileName = Guid.NewGuid().ToString() + "-" + file.FileName;
            string path = Path.Combine(Environment.CurrentDirectory, "avatar", fileName);
            MakeDir(Path.Combine(Environment.CurrentDirectory, "avatar"));
            Stream stream = System.IO.File.Create(path);
            file.CopyTo(stream);
            stream.Close();
            return "avatar/" + fileName;
        }
    }
}