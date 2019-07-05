using System;
using System.Collections.Generic;
using SuS.Common.Models;

namespace SuS.Common
{
    public interface IConfigurationService
    {
        Talend GetTalend();
        void SetData(List<Parameter> parameters, List<Service> services, List<Job> jobs, string baseUrl);
        string GetUrl(string serviceName, Boolean fullUrl);
        string GetParameter(string parameterName);
    }
}