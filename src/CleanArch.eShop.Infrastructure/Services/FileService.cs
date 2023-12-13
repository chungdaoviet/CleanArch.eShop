using CleanArch.eShop.Application.Common.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace CleanArch.eShop.Infrastructure.Services
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly string root;
        private readonly string folderUploads = "/uploads/";

        public FileService(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
            root = _hostEnvironment.WebRootPath + folderUploads;
        }

        public async Task<string> FileUpload(string folder, string fileName, IFormFile file, string extensionFile)
        {
            var baseAddress = root;
            if (string.IsNullOrEmpty(folder))
                baseAddress += $"{folder}/";
            string path = Path.Combine(baseAddress, fileName);
            CreatePath(baseAddress);

            using (var fileStream = new FileStream($"{path}{extensionFile}", FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return $"{folderUploads}{fileName}{extensionFile}";
        }

        public bool RemoveFile(string path, string fileName, string extensionFile)
        {
            string _path = Path.Combine(path, $"{fileName}{extensionFile}");

            if(File.Exists(_path))
            {
                File.Delete(_path);
            }

            return true;
        }

        public string ThumbImageUpload(string folder, string fileName, IFormFile file, string extensionFile, int width = 100, int height = 100)
        {
            var baseAddress = root;
            if (string.IsNullOrEmpty(folder))
                baseAddress += $"{folder}/";
            string path = Path.Combine(baseAddress, $"{fileName}{extensionFile}");
            CreatePath(baseAddress);

            using(Image image = Image.Load(file.OpenReadStream()))
            {
                image.Mutate(x => x.Resize(width, height));
                image.Save(path);
            }

            return $"{folderUploads}{fileName}{extensionFile}";
        }

        private static void CreatePath(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}
