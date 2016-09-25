using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using OpenRMS.Shared.Kernel.Interfaces;
using OpenRMS.Contexts.ProductManagement.Domain;
using OpenRMS.Contexts.ProductManagement.QueryStack.Dto;
using OpenRMS.Contexts.ProductManagement.CommandStack.Commands;
using OpenRMS.Contexts.ProductManagement.QueryStack.Queries;
using OpenRMS.Contexts.ProductManagement.CommandStack.Handlers;
using OpenRMS.Contexts.ProductManagement.QueryStack.Handlers;
using OpenRMS.Contexts.ProductManagement.CommandStack.Services;
using OpenRMS.Contexts.ProductManagement.QueryStack.Services;

namespace OpenRMS.Console
{
    public class Program
    {
        private static IServiceProvider _serviceProvider;

        public static void Main(string[] args)
        {
            ConfigureIoC();

            IProductQueryService productQueries = _serviceProvider.GetService<IProductQueryService>();

            foreach (var product in productQueries.GetAll())
            {
                System.Console.WriteLine(string.Format("Product Id: {0}", product.Id));
                System.Console.WriteLine(string.Format("Name: {0}", product.Name));
                System.Console.WriteLine(string.Format("Description: {0}", product.Description));
                System.Console.WriteLine();
            }

            System.Console.Read();
        }

        private static void ConfigureIoC()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddTransient<IRepository<Product>, FakeProductRepository>();
            services.AddTransient<IDataSource<ProductDto>, FakeProductDataSource>();

            services.AddTransient<IProductCommandService, ProductCommandService>();
            services.AddTransient<ICommandHandler<CreateProductCommand, Product>, CreateProductHandler>();
            services.AddTransient<ICommandHandler<UpdateProductCommand, Product>, UpdateProductHandler>();
            services.AddTransient<ICommandHandler<DeleteProductCommand, Product>, DeleteProductHandler>();

            services.AddTransient<IProductQueryService, ProductQueryService>();
            services.AddTransient<IQueryHandler<GetAllProductsQuery, IEnumerable<ProductDto>>, GetAllProductsHandler>();
            services.AddTransient<IQueryHandler<GetProductForIdQuery, ProductDto>, GetProductForIdHandler>();
            services.AddTransient<IQueryHandler<SearchProductsQuery, IEnumerable<ProductDto>>, SearchProductsHandler>();

            _serviceProvider = services.BuildServiceProvider();
        }
    }
}
