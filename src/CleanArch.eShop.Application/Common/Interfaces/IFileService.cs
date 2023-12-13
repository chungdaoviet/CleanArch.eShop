using Microsoft.AspNetCore.Http;

namespace CleanArch.eShop.Application.Common.Interfaces
{
    public interface IFileService
    {
        Task<string> FileUpload(string folder, string fileName, IFormFile file, string extensionFile);
        string ThumbImageUpload(string folder, string fileName, IFormFile file, string extensionFile, int width = 100, int height = 100);
        bool RemoveFile(string path, string fileName, string extensionFile);
    }
}
