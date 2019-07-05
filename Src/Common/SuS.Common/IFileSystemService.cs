using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SuS.Common
{
    public interface IFileSystemService
    {
        string CreateDirectory(string path, string directorName, string filename);

        Task<string> SaveFile(IFormFile file);
    }
}