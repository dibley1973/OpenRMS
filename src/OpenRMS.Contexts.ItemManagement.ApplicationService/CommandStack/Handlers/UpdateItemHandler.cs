using System;
using System.Collections.Generic;
using System.Linq;
using OpenRMS.Contexts.ItemManagement.ApplicationService.CommandStack.Commands;
using OpenRMS.Contexts.ItemManagement.Domain.Interfaces;
using OpenRMS.Shared.Kernel.Interfaces;
using OpenRMS.Contexts.ItemManagement.ApplicationService.Resources;
using OpenRMS.Contexts.ItemManagement.Domain.Entities;

namespace OpenRMS.Contexts.ItemManagement.ApplicationService.CommandStack.Handlers
{
    /// <summary>
    /// Handles the command to update a product.
    /// </summary>
    public class UpdateItemHandler : ICommandHandlerWithPreconditionCheck<UpdateItemCommand>
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

        
        public PreconditionCheckResult PreconditionChecks(UpdateItemCommand command)
        {
            var preconditionCheckResults = new PreconditionCheckResult();

            if (command == null) throw new ArgumentNullException(nameof(command));

            using(var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                var maybeItem = unitOfWork.ItemRepository.GetForId(command.Id);

                if (maybeItem.Any()==false)
                {
                    preconditionCheckResults.AddFailure(new PreconditionFailure(nameof(command.Id), string.Format("Cannot find Item for id: {0}", command.Id)));
                    return preconditionCheckResults;
                }
                var item = maybeItem.Single();

                var canChangeName = item.CanChangeName(command.Name);
                var canChangeDescription = item.CanChangeDescription(command.Description);

                if(canChangeName==false) preconditionCheckResults.AddFailure(nameof(command.Name), canChangeName.ErrorMessage);
                if (canChangeDescription == false) preconditionCheckResults.AddFailure(nameof(command.Description), canChangeDescription.ErrorMessage);
            }

            return preconditionCheckResults;
        }
        
    }
}
