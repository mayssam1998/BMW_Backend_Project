using System;
using System.Collections.Generic;
using System.Linq;
using SuS.Common;
using SuS.Common.Models;

namespace SuS.Infrastructure
{
    public class ConfigurationService : IConfigurationService
    {
        private static Talend _talend { get; set; }
        private static string _baseUrl { get; set; }
        private static List<Service> _services { get; set; }
        private static List<Parameter> _parameters { get; set; }
        
        public void SetData(List<Parameter> parameters, List<Service> services, List<Job> jobs, string baseUrl)
        {
            _baseUrl = baseUrl;
            _services = services;
            _talend = new Talend();
            jobs.ForEach(x=>_talend.Jobs.Add(x.JobName, new Job()
            {
                JobName = x.JobName,
                ProjectDirectory = x.ProjectDirectory,
                JobWorkingDirectory =x.JobWorkingDirectory,
                Description = x.Description,
                ScriptFile =x.ScriptFile,
                FilePathArgument = x.FilePathArgument,
                JobParameter = x.JobParameter.ToDictionary(y=>y.Key, z=> z.Value !=null? z.Value.ToString(): "")
            }));
            
        }

        public Talend GetTalend() => _talend;

        public string GetUrl(string serviceName, Boolean fullUrl)
        {
            var service = _services.SingleOrDefault(x =>
                x.Name.Equals(serviceName, StringComparison.InvariantCultureIgnoreCase));
            if (service != null)
            {
                return fullUrl ? $"{service.GatewayEndpoint}" : _baseUrl + $"{service.GatewayEndpoint}";
            }

            return "";
        }

        public string GetParameter(string parameterName)
        {
            var parameter = _parameters.SingleOrDefault(x =>
                x.Key.Equals(parameterName, StringComparison.InvariantCultureIgnoreCase));
            return parameter != null ? parameter.Value : "";
        }
    }
}