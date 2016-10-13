using System;
using System.Linq;
using System.Collections.Generic;

using Microsoft.Extensions.DependencyInjection;
using OpenRMS.Shared.Kernel.Interfaces;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using OpenRMS.Contexts.ItemManagement.CommandStack.Commands;
using OpenRMS.Contexts.ItemManagement.CommandStack.Handlers;
using OpenRMS.Contexts.ItemManagement.CommandStack.Services;
using OpenRMS.Contexts.ItemManagement.Domain;
using OpenRMS.Contexts.ItemManagement.Infrastructure.PostgreSql;
using OpenRMS.Contexts.ItemManagement.Interfaces;
using OpenRMS.Contexts.ItemManagement.QueryStack.Dto;
using OpenRMS.Contexts.ItemManagement.QueryStack.Handlers;
using OpenRMS.Contexts.ItemManagement.QueryStack.Queries;
using OpenRMS.Contexts.ItemManagement.QueryStack.Services;

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
            serviceProvider.GetService<PostgreSqlItemManagementContext>().Database.EnsureCreated();

            var productRepository = serviceProvider.GetService<IItemRepository>();
            var productCommands = serviceProvider.GetService<IItemCommandService>();

            // Delete products if they exist
            System.Console.WriteLine("Deleting existing products.");
            System.Console.WriteLine("Count of products already in repository: {0}", productRepository.GetAll().Count());
            foreach (Item product in productRepository.GetAll())
            {
                System.Console.WriteLine(string.Format("Deleting Item Id: {0}", product.Id));
                productCommands.DeleteItem(new DeleteItemCommand(product.Id));
            }
            System.Console.WriteLine();

            // Create some products
            System.Console.WriteLine("Creating some new products");

            var createProductOne = new CreateItemCommand("Item One", "Item one description.");
            var createProductTwo = new CreateItemCommand("Item Two", "Item two description.");
            var createProductThree = new CreateItemCommand("Item Three", "Item three description.");

            var productOneId = productCommands.CreateItem(createProductOne);
            System.Console.WriteLine(string.Format("Created Item Id: {0}", productOneId));

            var productTwoId = productCommands.CreateItem(createProductTwo);
            System.Console.WriteLine(string.Format("Created Item Id: {0}", productTwoId));

            var productThreeId = productCommands.CreateItem(createProductThree);
            System.Console.WriteLine(string.Format("Created Item Id: {0}", productThreeId));
            System.Console.WriteLine();

            // Output some info on the products
            OutputProductInfo(productRepository);

            // Updating products
            System.Console.WriteLine("Updating products");

            var updateProductOne = new UpdateItemCommand(productOneId, "Updated Item One", "Updated product one description.");
            var updateProductTwo = new UpdateItemCommand(productTwoId, "Updated Item Two", "Updated product two description.");
            var updateProductThree = new UpdateItemCommand(productThreeId, "Updated Item Three", "Updated product three description.");

            productCommands.UpdateItem(updateProductOne);
            System.Console.WriteLine(string.Format("Updated Item Id: {0}", productOneId));

            productCommands.UpdateItem(updateProductTwo);
            System.Console.WriteLine(string.Format("Updated Item Id: {0}", productTwoId));

            productCommands.UpdateItem(updateProductThree);
            System.Console.WriteLine(string.Format("Updated Item Id: {0}", productThreeId));
            System.Console.WriteLine();

            System.Console.Read();
        }

        private static void OutputProductInfo(IItemRepository itemRepository)
        {
            System.Console.WriteLine("Fetching information on products.");
            System.Console.WriteLine();
            System.Console.WriteLine("Count of products in repository: {0}", itemRepository.GetAll().Count());
            System.Console.WriteLine();

            foreach (Item product in itemRepository.GetAll())
            {
                System.Console.WriteLine(string.Format("Item Id: {0}", product.Id));
                System.Console.WriteLine(string.Format("Name: {0}", product.Name));
                System.Console.WriteLine(string.Format("Description: {0}", product.Description));
                System.Console.WriteLine();
            }
        }

        private static void ConfigureDatabase()
        {
            _services.AddDbContext<PostgreSqlItemManagementContext>(options =>
                options.UseNpgsql("User ID=openrms;Password=password;Host=openrms-db;Port=5432;Database=openrms;Pooling=true;")
            );
        }

        private static void ConfigureIoC()
        {
            //_services.AddTransient<IItemRepository, FakeItemRepository>();
            _services.AddTransient<IDataSource<ProductDto>, FakeProductDataSource>();

            _services.AddTransient<IItemRepository, ItemRepository>();
            _services.AddTransient<IItemManagementUnitOfWork, PostgreSqlItemManagementUnitOfWork>();
            _services.AddTransient<IItemManagementUnitOfWorkFactory, PostgreSqlItemManagementUnitOfWorkFactory>();
            _services.AddTransient<PostgreSqlItemManagementContext, PostgreSqlItemManagementContext>();

            _services.AddTransient<IItemCommandService, ItemCommandService>();
            _services.AddTransient<ICommandHandler<CreateItemCommand, Item>, CreateItemHandler>();
            _services.AddTransient<ICommandHandler<UpdateItemCommand>, UpdateItemHandler>();
            _services.AddTransient<ICommandHandler<DeleteItemCommand>, DeleteItemHandler>();

            _services.AddTransient<IProductQueryService, ProductQueryService>();
            _services.AddTransient<IQueryHandler<GetAllProductsQuery, IEnumerable<ProductDto>>, GetAllProductsHandler>();
            _services.AddTransient<IQueryHandler<GetProductForIdQuery, ProductDto>, GetProductForIdHandler>();
            _services.AddTransient<IQueryHandler<SearchProductsQuery, IEnumerable<ProductDto>>, SearchProductsHandler>();
        }
    }
}
