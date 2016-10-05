using OpenRMS.Contexts.ProductManagement.CommandStack.Commands;
using OpenRMS.Contexts.ProductManagement.Domain;
using OpenRMS.Contexts.ProductManagement.Interfaces;
using OpenRMS.Contexts.ProductManagement.QueryStack.Dto;
using OpenRMS.Contexts.ProductManagement.QueryStack.Services;
using OpenRMS.Contexts.ProductManagement.Resources;
using OpenRMS.Shared.Kernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenRMS.Contexts.ProductManagement.CommandStack.Handlers
{
    /// <summary>
    /// Handles the command to delete a product.
    /// </summary>
    public class DeleteProductHandler : ICommandHandler<DeleteProductCommand>
    {
        private readonly IProductManagementUnitOfWorkFactory _unitOfWorkFactory;

        /// <summary>
        /// Construct.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory that can create units of work.</param>
        public DeleteProductHandler(IProductManagementUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="command">The command.</param>
        public void Execute(DeleteProductCommand command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            using (IProductManagementUnitOfWork unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                var result = unitOfWork.ProductRepository.GetForId(command.Id);

                // Ensure product exists to delete
                if (!result.HasValue())
                    throw new InvalidOperationException(string.Format(ExceptionMessages.ProductNotFound, command.Id));

                unitOfWork.ProductRepository.Delete(result.Entity);
                unitOfWork.Complete();
            }
        }
    }
}
