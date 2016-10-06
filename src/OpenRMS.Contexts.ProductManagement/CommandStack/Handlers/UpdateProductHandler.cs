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
    /// Handles the command to update a product.
    /// </summary>
    public class UpdateProductHandler : ICommandHandler<UpdateProductCommand>
    {
        private readonly IProductManagementUnitOfWorkFactory _unitOfWorkFactory;

        /// <summary>
        /// Construct.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory that can create units of work.</param>
        public UpdateProductHandler(IProductManagementUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="command">The command.</param>
        public void Execute(UpdateProductCommand command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            using (IProductManagementUnitOfWork unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                EnsureProductNameIsNotAlreadyTaken(command, unitOfWork);

                var result = unitOfWork.ProductRepository.GetForId(command.Id);

                // Ensure product exists to update
                if (!result.HasValue())
                    throw new InvalidOperationException(string.Format(ExceptionMessages.ProductNotFound, command.Id));

                
                result.Entity.ChangeName(command.Name);
                result.Entity.ChangeDescription(command.Description);

                unitOfWork.ProductRepository.Update(result.Entity);
                unitOfWork.Complete();
            }
        }

        private static void EnsureProductNameIsNotAlreadyTaken(UpdateProductCommand command,
            IProductManagementUnitOfWork unitOfWork)
        {
            var repository = unitOfWork.ProductRepository;
            var productWithSameNameResult = repository.GetForName(command.Name);
            var nameIsTaken = productWithSameNameResult.HasValue();

            if (nameIsTaken) throw new InvalidOperationException(string.Format(ExceptionMessages.NameAlreadyTaken, command.Name));
        }
    }
}
