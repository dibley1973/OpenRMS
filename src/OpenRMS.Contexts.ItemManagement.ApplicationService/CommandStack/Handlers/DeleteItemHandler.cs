using System;
using OpenRMS.Contexts.ItemManagement.ApplicationService.CommandStack.Commands;
using OpenRMS.Contexts.ItemManagement.ApplicationService.Resources;
using OpenRMS.Contexts.ItemManagement.Domain.Entities;
using OpenRMS.Contexts.ItemManagement.Domain.Interfaces;
using OpenRMS.Shared.Kernel.Interfaces;

namespace OpenRMS.Contexts.ItemManagement.ApplicationService.CommandStack.Handlers
{
    /// <summary>
    /// Handles the command to delete a product.
    /// </summary>
    public class DeleteItemHandler : ICommandHandler<DeleteItemCommand>
    {
        private readonly IItemManagementUnitOfWorkFactory _unitOfWorkFactory;

        /// <summary>
        /// Construct.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory that can create units of work.</param>
        public DeleteItemHandler(IItemManagementUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <exception cref="ArgumentNullException">command</exception>
        /// <exception cref="InvalidOperationException">if command contains an id for an <see cref="Item"/> that does not exist </exception>
        public void Execute(DeleteItemCommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            using (IItemManagementUnitOfWork unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                var result = unitOfWork.ItemRepository.GetForId(command.Id);

                var itemDoesNotExistForDeletion = !result.HasValue();
                if (itemDoesNotExistForDeletion)
                    throw new InvalidOperationException(GetProductDoesNotExistForDeletionExceptionMessage(command.Id));

                unitOfWork.ItemRepository.Delete(result.Value);
                unitOfWork.Complete();
            }
        }

        private static string GetProductDoesNotExistForDeletionExceptionMessage(Guid commandId)
        {
            return string.Format(ExceptionMessages.ItemNotFound, commandId);
        }
    }
}