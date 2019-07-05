using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SuS.Infrastructure.Helpers
{
    public static class FormFileExtensions
    {
        public static string GetFilename(this IFormFile file)
        {
            return ContentDispositionHeaderValue.Parse(
                file.ContentDisposition).FileName.Trim('"');
        }

        public static async Task<MemoryStream> GetFileStream(this IFormFile file)
        {
            MemoryStream filestream = new MemoryStream();
            await file.CopyToAsync(filestream);
            return filestream;
        }

        public static async Task<byte[]> GetFileArray(this IFormFile file)
        {
            MemoryStream filestream = new MemoryStream();
            await file.CopyToAsync(filestream);
            return filestream.ToArray();
        }
    }
}