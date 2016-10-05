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
using OpenRMS.Contexts.ProductManagement.Resources;

namespace OpenRMS.Contexts.ProductManagement.CommandStack.Handlers
{
    /// <summary>
    /// Handles the command to create a product.
    /// </summary>
    public class CreateProductHandler : ICommandHandler<CreateProductCommand, Product>
    {
        private readonly IProductManagementUnitOfWorkFactory _unitOfWorkFactory;

        /// <summary>
        /// Construct.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory that can create units of work.</param>
        public CreateProductHandler(IProductManagementUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>The product created by the command.</returns>
        public Product Execute(CreateProductCommand command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            using (IProductManagementUnitOfWork unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                // Ensure name is unique
                if (unitOfWork.ProductRepository.GetForName(command.Name).HasValue())
                    throw new InvalidOperationException(string.Format(ExceptionMessages.NameAlreadyTaken, command.Name));

                var product = new Product(command.Name, command.Description);

                unitOfWork.ProductRepository.Create(product);
                unitOfWork.Complete();
                
                return product;
            }
        }
    }
}
