using System;
using OpenRMS.Contexts.ItemManagement.ApplicationService.CommandStack.Commands;
using OpenRMS.Contexts.ItemManagement.Domain.Entities;
using OpenRMS.Contexts.ItemManagement.Domain.Interfaces;
using OpenRMS.Shared.Kernel.Interfaces;

namespace OpenRMS.Contexts.ItemManagement.ApplicationService.CommandStack.Handlers
{
    /// <summary>
    /// Handles the command to create a product.
    /// </summary>
    public class CreateItemHandler : ICommandHandler<CreateItemCommand, Item>
    {
        private readonly IItemManagementUnitOfWorkFactory _unitOfWorkFactory;

        /// <summary>
        /// Construct.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory that can create units of work.</param>
        public CreateItemHandler(IItemManagementUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>The product created by the command.</returns>
        public Item Execute(CreateItemCommand command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            using (IItemManagementUnitOfWork unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                var product = new Item(command.Name, command.Description);

                unitOfWork.ItemRepository.Create(product);
                unitOfWork.Complete();
                
                return product;
            }
        }
    }
}
