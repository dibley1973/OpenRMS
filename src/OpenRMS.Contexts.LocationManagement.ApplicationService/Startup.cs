using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OpenRMS.Contexts.LocationManagement.Infrastructure.PostgreSql;
using Microsoft.EntityFrameworkCore;
using OpenRMS.Contexts.LocationManagement.Domain.Interfaces;
using OpenRMS.Shared.Kernel.Interfaces;
using OpenRMS.Contexts.LocationManagement.ApplicationService.CommandStack.Commands;
using OpenRMS.Contexts.LocationManagement.Domain.Entities;
using OpenRMS.Contexts.LocationManagement.ApplicationService.CommandStack.Handlers;

namespace OpenRMS.Contexts.LocationManagement.ApplicationService
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            // Add data services
            services.AddDbContext<PostgreSqlLocationManagementContext>(options =>
                options.UseNpgsql("User ID=postgres;Password=password;Host=openrms-db;Port=5432;Database=openrms;Pooling=true;")
            );

            // Add dependency bindings
            ConfigureDependencies(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            // Ensure database has been created
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                serviceScope.ServiceProvider.GetService<PostgreSqlLocationManagementContext>().Database.Migrate();
            }

            app.UseMvc();
        }

        /// <summary>
        /// Configure dependencies.
        /// </summary>
        /// <param name="services">A collection of services to add dependencies to.</param>
        private void ConfigureDependencies(IServiceCollection services)
        {
            // Repository/infrastructure
            services.AddTransient<ILocationRepository, PostgreSqlLocationRepository>();
            services.AddTransient<ILocationManagementUnitOfWork, PostgreSqlLocationManagementUnitOfWork>();
            services.AddTransient<ILocationManagementUnitOfWorkFactory, PostgreSqlLocationManagementUnitOfWorkFactory>();
            services.AddTransient<PostgreSqlLocationManagementContext, PostgreSqlLocationManagementContext>();

            // Commands
            services.AddTransient<ICommandHandler<CreateLocationCommand, Location>, CreateLocationHandler>();
            services.AddTransient<ICommandHandler<UpdateLocationCommand>, UpdateLocationHandler>();
            services.AddTransient<ICommandHandler<DeleteLocationCommand>, DeleteLocationHandler>();
        }
    }
}
