using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SuS.Common;
using SuS.Infrastructure.Helpers;

namespace SuS.Infrastructure
{
    public class FileSystemService : IFileSystemService
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IDateTime _machineDateTime;

        public FileSystemService(IHostingEnvironment hostingEnvironment, IDateTime machineDateTime)
        {
            _hostingEnvironment = hostingEnvironment;
            _machineDateTime = machineDateTime;
        }

        public string CreateDirectory(string path, string directorName, string filename)
        {
            var directoryPath = Path.Combine(path, directorName);

            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            return Path.Combine(directoryPath, filename);
        }

        public async Task<string> SaveFile(IFormFile file)
        {
            try
            {
                var time = _machineDateTime.Now.ToString("yyyyMMdd_HHmm");
                if (file == null) return null;
                var path = CreateDirectory(_hostingEnvironment.WebRootPath, "Backup_" + time, file.GetFilename());
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                    stream.Position = 0;
                }

                return path;

            }
            catch (Exception)
            {
                return null;
                // ignored
            }
        }
    }
}