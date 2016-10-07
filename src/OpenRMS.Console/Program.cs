using System;
using System.Linq;
using System.Collections.Generic;

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
using OpenRMS.Contexts.ProductManagement.Interfaces;
using Microsoft.EntityFrameworkCore.Infrastructure;
using OpenRMS.Contexts.ProductManagement.Infrastructure.PostgreSql;
using Microsoft.EntityFrameworkCore;

namespace OpenRMS.Console
{
    public class Program
    {
        private static IServiceCollection _services = new ServiceCollection();

        public static void Main(string[] args)
        {
            ConfigureIoC();
            ConfigureDatabase();

            var serviceProvider = _services.BuildServiceProvider();

            // Manky code to ensure the database has been created.
            serviceProvider.GetService<PostgreSqlProductManagementContext>().Database.EnsureCreated();

            var productRepository = serviceProvider.GetService<IProductRepository>();
            var productCommands = serviceProvider.GetService<IProductCommandService>();

            // Delete products if they exist
            System.Console.WriteLine("Deleting existing products.");
            System.Console.WriteLine("Count of products already in repository: {0}", productRepository.GetAll().Count());
            foreach (Product product in productRepository.GetAll())
            {
                System.Console.WriteLine(string.Format("Deleting Product Id: {0}", product.Id));
                productCommands.DeleteProduct(new DeleteProductCommand(product.Id));
            }
            System.Console.WriteLine();

            // Create some products
            System.Console.WriteLine("Creating some new products");

            var createProductOne = new CreateProductCommand("Product One", "Product one description.");
            var createProductTwo = new CreateProductCommand("Product Two", "Product two description.");
            var createProductThree = new CreateProductCommand("Product Three", "Product three description.");

            var productOneId = productCommands.CreateProduct(createProductOne);
            System.Console.WriteLine(string.Format("Created Product Id: {0}", productOneId));

            var productTwoId = productCommands.CreateProduct(createProductTwo);
            System.Console.WriteLine(string.Format("Created Product Id: {0}", productTwoId));

            var productThreeId = productCommands.CreateProduct(createProductThree);
            System.Console.WriteLine(string.Format("Created Product Id: {0}", productThreeId));
            System.Console.WriteLine();

            // Output some info on the products
            OutputProductInfo(productRepository);

            // Updating products
            System.Console.WriteLine("Updating products");

            var updateProductOne = new UpdateProductCommand(productOneId, "Updated Product One", "Updated product one description.");
            var updateProductTwo = new UpdateProductCommand(productTwoId, "Updated Product Two", "Updated product two description.");
            var updateProductThree = new UpdateProductCommand(productThreeId, "Updated Product Three", "Updated product three description.");

            productCommands.UpdateProduct(updateProductOne);
            System.Console.WriteLine(string.Format("Updated Product Id: {0}", productOneId));

            productCommands.UpdateProduct(updateProductTwo);
            System.Console.WriteLine(string.Format("Updated Product Id: {0}", productTwoId));

            productCommands.UpdateProduct(updateProductThree);
            System.Console.WriteLine(string.Format("Updated Product Id: {0}", productThreeId));
            System.Console.WriteLine();

            System.Console.Read();
        }

        private static void OutputProductInfo(IProductRepository productRepository)
        {
            System.Console.WriteLine("Fetching information on products.");
            System.Console.WriteLine();
            System.Console.WriteLine("Count of products in repository: {0}", productRepository.GetAll().Count());
            System.Console.WriteLine();

            foreach (Product product in productRepository.GetAll())
            {
                System.Console.WriteLine(string.Format("Product Id: {0}", product.Id));
                System.Console.WriteLine(string.Format("Name: {0}", product.Name));
                System.Console.WriteLine(string.Format("Description: {0}", product.Description));
                System.Console.WriteLine();
            }
        }

        private static void ConfigureDatabase()
        {
            _services.AddDbContext<PostgreSqlProductManagementContext>(options =>
                options.UseNpgsql("User ID=openrms;Password=password;Host=openrms-db;Port=5432;Database=openrms;Pooling=true;")
            );
        }

        private static void ConfigureIoC()
        {
            //_services.AddTransient<IProductRepository, FakeProductRepository>();
            _services.AddTransient<IDataSource<ProductDto>, FakeProductDataSource>();

            _services.AddTransient<IProductRepository, PostgreSqlProductRepository>();
            _services.AddTransient<IProductManagementUnitOfWork, PostgreSqlProductManagementUnitOfWork>();
            _services.AddTransient<IProductManagementUnitOfWorkFactory, PostgreSqlProductManagementUnitOfWorkFactory>();
            _services.AddTransient<PostgreSqlProductManagementContext, PostgreSqlProductManagementContext>();

            _services.AddTransient<IProductCommandService, ProductCommandService>();
            _services.AddTransient<ICommandHandler<CreateProductCommand, Product>, CreateProductHandler>();
            _services.AddTransient<ICommandHandler<UpdateProductCommand>, UpdateProductHandler>();
            _services.AddTransient<ICommandHandler<DeleteProductCommand>, DeleteProductHandler>();

            _services.AddTransient<IProductQueryService, ProductQueryService>();
            _services.AddTransient<IQueryHandler<GetAllProductsQuery, IEnumerable<ProductDto>>, GetAllProductsHandler>();
            _services.AddTransient<IQueryHandler<GetProductForIdQuery, ProductDto>, GetProductForIdHandler>();
            _services.AddTransient<IQueryHandler<SearchProductsQuery, IEnumerable<ProductDto>>, SearchProductsHandler>();
        }
    }
}
