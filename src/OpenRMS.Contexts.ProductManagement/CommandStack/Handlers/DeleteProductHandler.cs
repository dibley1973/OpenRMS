using OpenRMS.Contexts.ProductManagement.CommandStack.Commands;
using OpenRMS.Contexts.ProductManagement.Domain;
using OpenRMS.Contexts.ProductManagement.Interfaces;
using OpenRMS.Contexts.ProductManagement.QueryStack.Dto;
using OpenRMS.Contexts.ProductManagement.QueryStack.Services;
using OpenRMS.Shared.Kernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenRMS.Contexts.ProductManagement.CommandStack.Handlers
{
    public class DeleteProductHandler : ICommandHandler<DeleteProductCommand, Product>
    {
        private readonly IProductManagementUnitOfWork _unitOfWork;

        public DeleteProductHandler(IProductManagementUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Product Execute(DeleteProductCommand command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            var result = _unitOfWork.ProductRepository.GetForId(command.Id);

            // Ensure product exists to delete
            if (!result.HasValue())
                throw new InvalidOperationException("Product does not exist.");
            
            _unitOfWork.ProductRepository.Delete(result.Entity);
            _unitOfWork.Complete();

            return result.Entity;
        }
    }
}
