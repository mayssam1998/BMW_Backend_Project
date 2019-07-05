using System;
using System.IO;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SuS.Application.Exceptions;
using SuS.Common;
using SuS.Common.Models;
using SuS.Infrastructure;
using SuS.Persistence;

namespace SuS.WebApi
{
    public static class CustomConfigurationProvider
    {
        private static string BaseUrl { get; set; }
        private static string Epic { get; set; }
        private static string Project { get; set; }
        private static string Environment { get; set; }
        //private static string SeparatedStepsPlantsKey { get; set; }
        private static string ConfigurationService { get; set; }
        private static string LocalConfigurationFile { get; set; }
        private static string DatabaseServiceName { get; set; }
        private static ConfigurationResponse ConfigurationResponse = null;

        public static void GetConfiguration(this IServiceCollection services, IConfiguration configuration,
            IHostingEnvironment hostingEnvironment)
        {
            Parameter separatedStepsPlants;

            LoadConfigurationVariables(configuration, hostingEnvironment);

            try
            {
                LoadLocalConfiguration();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                LoadLocalConfiguration();
            }

            var dbService = ConfigurationResponse.Services.FirstOrDefault(x => x.Name.Contains(DatabaseServiceName));

            if (dbService == null)
            {
                throw new NotFoundException(
                    "DB Service: Object is null => can't find the db service -- hint: its name should contain \'DB\'" +
                    ConfigurationResponse, "");
            }
            
            // Add DbContext using SQL Server Provider
            services.AddDbContext<SupplierDbContext>(options => { options.UseNpgsql(dbService.GatewayEndpoint); });

            services.AddSingleton<IConfigurationService, ConfigurationService>();
            var dataService =
                (IConfigurationService) services.BuildServiceProvider().GetService(typeof(IConfigurationService));
            dataService.SetData(ConfigurationResponse.Parameter, ConfigurationResponse.Services, ConfigurationResponse.Jobs,
                BaseUrl);
        }

        private static void LoadConfigurationVariables(IConfiguration configuration,
            IHostingEnvironment hostingEnvironment)
        {
            Environment = hostingEnvironment.EnvironmentName;
            BaseUrl = configuration.GetSection("BasicConfiguration").GetSection("BaseUrl" + Environment).Value;
            Epic = configuration.GetSection("BasicConfiguration").GetSection("Epic").Value;
            Project = configuration.GetSection("BasicConfiguration").GetSection("Project").Value;
            LocalConfigurationFile = configuration.GetSection("BasicConfiguration")
                .GetSection("LocalConfigurationFile").Value;
            ConfigurationService = configuration.GetSection("BasicConfiguration")
                .GetSection("ConfigurationService").Value;
            DatabaseServiceName = configuration.GetSection("BasicConfiguration")
                .GetSection("DatabaseServiceName").Value;
        }

        private static void UpdateLocalConfiguration(string currentConfiguration)
        {
            if (!File.Exists(LocalConfigurationFile))
            {
                File.Create(LocalConfigurationFile);
            }

            if (ConfigurationResponse != null)
            {
                using (var writer = new StreamWriter(LocalConfigurationFile, append: false))
                {
                    writer.WriteLine(JsonConvert.SerializeObject(ConfigurationResponse, Formatting.Indented));
                }
            }
            else
            {
                throw new NotFoundException(
                    "Configuration Service: Object is null => " + ConfigurationResponse, "");
            }
        }

        private static void LoadLocalConfiguration()
        {
            if (!File.Exists(LocalConfigurationFile))
            {
                throw new NotFoundException(
                    "Local Configuration file not found: Object is null => " + ConfigurationResponse, "");
            }
            else
            {
                ConfigurationResponse =
                    JsonConvert.DeserializeObject<ConfigurationResponse>(File.ReadAllText(LocalConfigurationFile));

                if (ConfigurationResponse == null)
                {
                    throw new NotFoundException(
                        "Configuration Service: Object is null -- hint: check if local configuration file is deserializable => " +
                        ConfigurationResponse, "");
                }
            }
        }
    }
}