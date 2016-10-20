using System;
using System.Linq;
using OpenRMS.Contexts.LocationManagement.ApplicationService.CommandStack.Commands;
using OpenRMS.Contexts.LocationManagement.Domain.Interfaces;
using OpenRMS.Shared.Kernel.Interfaces;
using OpenRMS.Contexts.LocationManagement.ApplicationService.Resources;

namespace OpenRMS.Contexts.LocationManagement.ApplicationService.CommandStack.Handlers
{
    /// <summary>
    /// Handles the command to update a product.
    /// </summary>
    public class UpdateLocationHandler : ICommandHandler<UpdateLocationCommand>
    {
        private readonly ILocationManagementUnitOfWorkFactory _unitOfWorkFactory;

        /// <summary>
        /// Construct.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory that can create units of work.</param>
        public UpdateLocationHandler(ILocationManagementUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="command">The command.</param>
        public void Execute(UpdateLocationCommand command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            using (ILocationManagementUnitOfWork unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                var result = unitOfWork.LocationRepository.GetForId(command.Id);

                // Ensure product exists to update
                if (!result.HasValue())
                    throw new InvalidOperationException(string.Format(ExceptionMessages.LocationNotFound, command.Id));

                var location = result.Single();
                
                location.ChangeName(command.Name);
                location.ChangeDescription(command.Description);

                unitOfWork.LocationRepository.Update(location);
                unitOfWork.Complete();
            }
        }

    }
}
