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
        private readonly IProductManagementUnitOfWork _unitOfWork;

        public CreateProductHandler(IProductManagementUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Product Execute(CreateProductCommand command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            // Ensure name is unique
            if (_unitOfWork.ProductRepository.GetForName(command.Name).HasValue())
                throw new ArgumentException("command.Name");

            var product = new Product(command.Name, command.Description);

            _unitOfWork.ProductRepository.Create(product);
            _unitOfWork.Complete();

            return product;
        }
    }
}
