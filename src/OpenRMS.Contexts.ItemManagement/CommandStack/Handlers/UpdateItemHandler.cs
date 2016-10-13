using System;
using System.Linq;
using OpenRMS.Contexts.ItemManagement.CommandStack.Commands;
using OpenRMS.Contexts.ItemManagement.Interfaces;
using OpenRMS.Contexts.ItemManagement.Resources;
using OpenRMS.Shared.Kernel.Interfaces;

namespace OpenRMS.Contexts.ItemManagement.CommandStack.Handlers
{
    /// <summary>
    /// Handles the command to update a product.
    /// </summary>
    public class UpdateItemHandler : ICommandHandler<UpdateItemCommand>
    {
        private readonly IItemManagementUnitOfWorkFactory _unitOfWorkFactory;

        /// <summary>
        /// Construct.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory that can create units of work.</param>
        public UpdateItemHandler(IItemManagementUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="command">The command.</param>
        public void Execute(UpdateItemCommand command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            using (IItemManagementUnitOfWork unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                var result = unitOfWork.ItemRepository.GetForId(command.Id);

                // Ensure product exists to update
                if (!result.HasValue())
                    throw new InvalidOperationException(string.Format(ExceptionMessages.ProductNotFound, command.Id));

                var item = result.Single();
                
                item.ChangeName(command.Name);
                item.ChangeDescription(command.Description);

                unitOfWork.ItemRepository.Update(item);
                unitOfWork.Complete();
            }
        }

    }
}
