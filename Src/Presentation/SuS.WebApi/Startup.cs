using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NJsonSchema;
using NSwag;
using NSwag.AspNetCore;
using SuS.Persistence;
using SuS.WebApi.Filters;

namespace SuS.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowAnyOrigin()
                    .AllowCredentials();
            }));
            
            services.AddOptions();
            
            // Add framework services.
            services.AddFrameworkServices();

            // Add MediatR
            services.AddMediatoRServices();

            // Customise default API behavour
            services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });

            // Add Auto Mapper Profiles
            services.AddAutoMapperService();

            services.AddSwagger();
            
            
            services.AddMvc(options => options.Filters.Add(typeof(CustomExceptionFilterAttribute)))
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(opt =>
                {
                    opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    opt.SerializerSettings.ContractResolver = new DefaultContractResolver
                        {NamingStrategy = new CamelCaseNamingStrategy()};
                    opt.SerializerSettings.Formatting = Formatting.Indented;
                });
            //.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateCustomerCommandValidator>());
            
            services.GetConfiguration(Configuration, Environment);

            services.AddHealthChecks().AddDbContextCheck<SupplierDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IConfiguration configuration)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            
            app.UseCors("CorsPolicy");

            app.UseSwaggerUi3WithApiExplorer(settings =>
            {
                
                settings.PostProcess = document =>
                {
                    document.Info = new SwaggerInfo
                    {
                        Title = configuration.GetSection("BasicConfiguration").GetSection("Project").Value,
                        Description = configuration.GetSection("BasicConfiguration").GetSection("Epic").Value
                        
                    };
                };
                settings.GeneratorSettings.DefaultPropertyNameHandling =
                    PropertyNameHandling.CamelCase;
            });

            app.UseHealthChecks("/health");
            
            app.UseMvc();
        }
    }
}