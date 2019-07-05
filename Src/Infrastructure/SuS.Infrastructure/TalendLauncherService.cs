using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SuS.Application.Interfaces;
using SuS.Common;
using SuS.Infrastructure.Helpers;

namespace SuS.Infrastructure
{
    public class TalendLauncherService: ITalendLauncherService
    { 
        private string Identifier { get; set; }
        private string BaseUrl { get; set; }
        
        
        public TalendLauncherService(IConfigurationService configurationService)
        {
            Identifier = "talend-service";
            BaseUrl = configurationService.GetUrl(Identifier, false);
        }

        public async Task<string> Run(string scriptFile, string JobWorkingDirectory, string JobArgument,
            Dictionary<string, string> Parameters, string FilePathArgument, string ProjectDirectory,
            IFormFile File)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(720);
                    var multiContent = new MultipartFormDataContent();
                    client.DefaultRequestHeaders
                        .Accept
                        .Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var payload = await File.GetFileArray();
                    multiContent.Add(new ByteArrayContent(payload), "file", File.GetFilename());
                    var query = $"{BaseUrl}/talend/{ProjectDirectory}/UploadAndRun()?" +
                                $"scriptFile={scriptFile}" +
                                $"&fileParameterName={FilePathArgument}" +
                                $"&talendWorkflow={JobWorkingDirectory}"+
                                $"&parameters={JsonConvert.SerializeObject(Parameters)}";

                    var response = await client.PostAsync(query, multiContent);
                    return await response.Content.ReadAsStringAsync();
                }
                
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}