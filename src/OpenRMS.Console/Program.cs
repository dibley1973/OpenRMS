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

            var productRepository = _serviceProvider.GetService<IProductRepository>();

            System.Console.WriteLine("Count of produts in repository: {0}", productRepository.GetAll().Count());
            var newProduct = new Product("Test Added Product", "The product added in the colsole test");
            productRepository.Create(newProduct);
            System.Console.WriteLine("Count of produts in repository: {0}", productRepository.GetAll().Count());

            /* Add new product to repo */
            var retrievedProductResult = productRepository.GetForId(newProduct.Id);
            var productNotFound = !retrievedProductResult.HasValue();
            if (productNotFound) throw new InvalidOperationException("new product not found in collection");
            
            /* retrieve the new product */
            var retrievedProduct = retrievedProductResult.Entity;
            System.Console.WriteLine(string.Format("RetrievedProduct Id: {0}", retrievedProduct.Id));
            System.Console.WriteLine(string.Format("RetrievedProduct Name: {0}", retrievedProduct.Name));
            System.Console.WriteLine(string.Format("RetrievedProduct Description: {0}", retrievedProduct.Description));

            /* NOT retrieve a product that does not exist */
            var noProductResult = productRepository.GetForId(Guid.Empty);
            var productFound = noProductResult.HasValue();
            if (productFound) throw new InvalidOperationException("a product was found in collection when it should not have had");
            System.Console.WriteLine("Did not find a non-existent product");




            System.Console.Read();
        }

        private static void ConfigureIoC()
        {
            IServiceCollection services = new ServiceCollection();

            //services.AddTransient<IRepository<Product>, FakeProductRepository>();
            //services.AddTransient<IProductRepository, FakeProductRepository>();
            services.AddTransient<IProductRepository, FakeProductRepository>();
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
