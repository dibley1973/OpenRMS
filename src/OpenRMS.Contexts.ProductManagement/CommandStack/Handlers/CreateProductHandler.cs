using OpenRMS.Contexts.ProductManagement.CommandStack.Commands;
using OpenRMS.Contexts.ProductManagement.Domain;
using OpenRMS.Contexts.ProductManagement.QueryStack.Dto;
using OpenRMS.Contexts.ProductManagement.QueryStack.Services;
using OpenRMS.Shared.Kernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenRMS.Contexts.ProductManagement.Interfaces;

namespace OpenRMS.Contexts.ProductManagement.CommandStack.Handlers
{
    public class CreateProductHandler : ICommandHandler<CreateProductCommand, Product>
    {
        private readonly IProductRepository _repository;

        public CreateProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public Product Execute(CreateProductCommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            // Ensure name is unique
            //if (_repository.Query().Any(p => p.Name == command.Name))
            //    throw new ArgumentException("command.Name");

            if (_repository.GetForName(command.Name) != null) throw new ArgumentException("command.Name");

            var product = new Product(command.Name, command.Description);

            _repository.Create(product);
            //_repository.Save();
            //_unitOfWork.Save();

            return product;
        }
    }
}
