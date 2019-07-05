using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SuS.Application.Interfaces
{
    public interface ITalendLauncherService
    {
        Task<string> Run(string argument, string JobWorkingDirectory, string JobArgument,
            Dictionary<string, string> Parameters, string FilePathArgument, string ProjectDirectory,
            IFormFile File);
    }
}