using System;
using OpenRMS.Contexts.LocationManagement.ApplicationService.CommandStack.Commands;
using OpenRMS.Contexts.LocationManagement.Domain.Entities;
using OpenRMS.Contexts.LocationManagement.Domain.Interfaces;
using OpenRMS.Shared.Kernel.Interfaces;

namespace OpenRMS.Contexts.LocationManagement.ApplicationService.CommandStack.Handlers
{
    /// <summary>
    /// Handles the command to create a product.
    /// </summary>
    public class CreateLocationHandler : ICommandHandler<CreateLocationCommand, Location>
    {
        private readonly ILocationManagementUnitOfWorkFactory _unitOfWorkFactory;

        /// <summary>
        /// Construct.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory that can create units of work.</param>
        public CreateLocationHandler(ILocationManagementUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>The product created by the command.</returns>
        public Location Execute(CreateLocationCommand command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            using (ILocationManagementUnitOfWork unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                var location = new Location(command.Code, command.Name);
                location.ChangeDescription(command.Description);

                unitOfWork.LocationRepository.Create(location);
                unitOfWork.Complete();
                
                return location;
            }
        }
    }
}
