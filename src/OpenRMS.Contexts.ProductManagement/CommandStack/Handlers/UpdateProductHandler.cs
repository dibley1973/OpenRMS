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
    public class UpdateProductHandler : ICommandHandler<UpdateProductCommand, Product>
    {
        private readonly IProductManagementUnitOfWork _unitOfWork;

        public UpdateProductHandler(IProductManagementUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Product Execute(UpdateProductCommand command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            var result = _unitOfWork.ProductRepository.GetForId(command.Id);            

            // Ensure product exists to update
            if (!result.HasValue())
                throw new InvalidOperationException("Product does not exist.");

            result.Entity.SetValues(command.Name, command.Description);

            _unitOfWork.ProductRepository.Update(result.Entity);
            _unitOfWork.Complete();

            return result.Entity;
        }
    }
}
