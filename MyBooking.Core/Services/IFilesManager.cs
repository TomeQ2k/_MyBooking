using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MyBooking.Core.Models.Helpers;
using MyBooking.Core.Services.ReadOnly;

namespace MyBooking.Core.Services
{
    public interface IFilesManager : IReadOnlyFilesManager
    {
        Task<FileModel> Upload(IFormFile file, string filePath = null);
        Task<IList<FileModel>> Upload(IEnumerable<IFormFile> files, string filePath = null);

        void Delete(string path);
        void DeleteDirectory(string path, bool isRecursive = true);
        void DeleteByFullPath(string fullPath);
    }
}