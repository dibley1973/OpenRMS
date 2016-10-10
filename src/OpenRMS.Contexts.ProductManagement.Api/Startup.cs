using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OpenRMS.Contexts.ProductManagement.Interfaces;
using OpenRMS.Shared.Kernel.Interfaces;
using OpenRMS.Contexts.ProductManagement.CommandStack.Services;
using OpenRMS.Contexts.ProductManagement.QueryStack.Services;
using OpenRMS.Contexts.ProductManagement.CommandStack.Handlers;
using OpenRMS.Contexts.ProductManagement.CommandStack.Commands;
using OpenRMS.Contexts.ProductManagement.Domain;
using OpenRMS.Contexts.ProductManagement.QueryStack.Queries;
using OpenRMS.Contexts.ProductManagement.QueryStack.Dto;
using OpenRMS.Contexts.ProductManagement.QueryStack.Handlers;
using OpenRMS.Contexts.ProductManagement.Infrastructure.PostgreSql;
using Microsoft.EntityFrameworkCore;

namespace OpenRMS.Contexts.ProductManagement.Api
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
            services.AddDbContext<PostgreSqlProductManagementContext>(options =>
                options.UseNpgsql("User ID=openrms;Password=password;Host=openrms-db;Port=5432;Database=openrms;Pooling=true;")
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
                serviceScope.ServiceProvider.GetService<PostgreSqlProductManagementContext>().Database.EnsureCreated();
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
            services.AddTransient<IProductRepository, PostgreSqlProductRepository>();
            services.AddTransient<IProductManagementUnitOfWork, PostgreSqlProductManagementUnitOfWork>();
            services.AddTransient<IProductManagementUnitOfWorkFactory, PostgreSqlProductManagementUnitOfWorkFactory>();
            services.AddTransient<PostgreSqlProductManagementContext, PostgreSqlProductManagementContext>();

            // Commands
            services.AddTransient<IProductCommandService, ProductCommandService>();
            services.AddTransient<ICommandHandler<CreateProductCommand, Product>, CreateProductHandler>();
            services.AddTransient<ICommandHandler<UpdateProductCommand>, UpdateProductHandler>();
            services.AddTransient<ICommandHandler<DeleteProductCommand>, DeleteProductHandler>();

            // Queries
            services.AddTransient<IProductQueryService, ProductQueryService>();
            services.AddTransient<IQueryHandler<GetAllProductsQuery, IEnumerable<ProductDto>>, GetAllProductsHandler>();
            services.AddTransient<IQueryHandler<GetProductForIdQuery, ProductDto>, GetProductForIdHandler>();
            services.AddTransient<IQueryHandler<SearchProductsQuery, IEnumerable<ProductDto>>, SearchProductsHandler>();
        }
    }
}
