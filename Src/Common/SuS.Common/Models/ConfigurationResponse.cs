using System.Collections.Generic;

namespace SuS.Common.Models
{
    public class ConfigurationResponse
    {
        public List<Service> Services { get; set; }
        public List<Job> Jobs { get; set; }
        public List<Parameter> Parameter { get; set; }
    }

    public class Service
    {
        public string Name { get; set; }
        public string AdditionalInformation { get; set; }
        public string GatewayEndpoint { get; set; }
    }
    
    public class Parameter
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
    }
    
    public class Job
    {
        public string JobName { get; set; }
        public string ProjectDirectory { get; set; }
        public string JobWorkingDirectory { get; set; }
        public string Description { get; set; }
        public string ScriptFile { get; set; }
        public string FilePathArgument { get; set; }
        public Dictionary<string, string> JobParameter { get; set; }
    }
}