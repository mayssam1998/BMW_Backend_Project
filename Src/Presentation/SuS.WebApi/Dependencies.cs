using System.Reflection;
using AutoMapper;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;
using SuS.Application.BranchManager.Command.AddUpdateBranch;
using SuS.Application.BranchManager.Query.GetBranch;
using SuS.Application.BranchManager.Query.GetBranch.GetBranchesByCountry;
using SuS.Application.BranchManager.Query.GetBranchAutocomplete;
using SuS.Application.BranchManager.Query.GetBranchBySupplier;
using SuS.Application.Infrastructure;
using SuS.Application.Interfaces;
using SuS.Application.SupplierManager.Command.AddOrUpdateSupplier;
using SuS.Application.SupplierManager.Query.GetSupplier;
using SuS.Application.Template.Queries.GetTemplate;
using SuS.Common;
using SuS.Infrastructure;

namespace SuS.WebApi
{
    internal static class Dependencies
    {
        internal static void AddMediatoRServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            
            services.AddMediatR(typeof(GetSupplierQueryHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetTemplateListQueryHandler).GetTypeInfo().Assembly);     
            services.AddMediatR(typeof(GetBranchQueryHandler).GetTypeInfo().Assembly);     
            services.AddMediatR(typeof(GetBranchAutocompleteQueryHandler).GetTypeInfo().Assembly);     
            services.AddMediatR(typeof(AddOrUpdateSupplierCommandHandler).GetTypeInfo().Assembly);     
            services.AddMediatR(typeof(GetBranchBySupplierQueryHandler).GetTypeInfo().Assembly);     
            services.AddMediatR(typeof(GetBranchesByCountryQueryHandler).GetTypeInfo().Assembly);     
            

            services.AddMediatR(typeof(AddUpdateBranchCommandHandler).GetTypeInfo().Assembly);     

            
        }

        internal static void AddFrameworkServices(this IServiceCollection services)
        {
            services.AddTransient<INotificationService, NotificationService>();
            services.AddTransient<IDateTime, MachineDateTime>();
            services.AddTransient<IFileSystemService, FileSystemService>();
            services.AddTransient<IRabbitMqSender, RabbitMqSender>();
            services.AddTransient<IConfigurationService, ConfigurationService>();

        }

        internal static void AddAutoMapperService(this IServiceCollection services)
        {
            services.AddAutoMapper(x =>
            {
                x.AddProfile(new TemplateListViewMapper());
                x.AddProfile(new GetSupplierMapper());
                x.AddProfile(new GetBranchQueryMapper());
            });
        }
    }
}