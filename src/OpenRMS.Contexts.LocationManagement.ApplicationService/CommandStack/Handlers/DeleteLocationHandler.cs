﻿using System;
using OpenRMS.Contexts.LocationManagement.ApplicationService.CommandStack.Commands;
using OpenRMS.Contexts.LocationManagement.ApplicationService.Resources;
using OpenRMS.Contexts.LocationManagement.Domain.Entities;
using OpenRMS.Contexts.LocationManagement.Domain.Interfaces;
using OpenRMS.Shared.Kernel.Interfaces;

namespace OpenRMS.Contexts.LocationManagement.ApplicationService.CommandStack.Handlers
{
    /// <summary>
    /// Handles the command to delete a product.
    /// </summary>
    public class DeleteLocationHandler : ICommandHandler<DeleteLocationCommand>
    {
        private readonly ILocationManagementUnitOfWorkFactory _unitOfWorkFactory;

        /// <summary>
        /// Construct.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory that can create units of work.</param>
        public DeleteLocationHandler(ILocationManagementUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <exception cref="ArgumentNullException">command</exception>
        /// <exception cref="InvalidOperationException">if command contains an id for an <see cref="Location"/> that does not exist </exception>
        public void Execute(DeleteLocationCommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            using (ILocationManagementUnitOfWork unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                var result = unitOfWork.LocationRepository.GetForId(command.Id);

                var locationDoesNotExistForDeletion = !result.HasValue();
                if (locationDoesNotExistForDeletion)
                    throw new InvalidOperationException(GetProductDoesNotExistForDeletionExceptionMessage(command.Id));

                unitOfWork.LocationRepository.Delete(result.Value);
                unitOfWork.Complete();
            }
        }

        private static string GetProductDoesNotExistForDeletionExceptionMessage(Guid commandId)
        {
            return string.Format(ExceptionMessages.LocationNotFound, commandId);
        }
    }
}