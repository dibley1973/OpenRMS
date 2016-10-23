using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Storage;
using OpenRMS.Contexts.ItemManagement.ApplicationService.CommandStack.Commands;
using OpenRMS.Contexts.ItemManagement.ApplicationService.Models;
using OpenRMS.Contexts.ItemManagement.Domain.Interfaces;
using OpenRMS.Shared.Kernel.Interfaces;
using OpenRMS.Contexts.ItemManagement.ApplicationService.Resources;

namespace OpenRMS.Contexts.ItemManagement.ApplicationService.CommandStack.Handlers
{
    /// <summary>
    /// Handles the command to update a product.
    /// </summary>
    public class UpdateItemHandlerV2 : IActionHandler<UpdateItemModel, IActionResult>
    {
        private readonly IItemManagementUnitOfWorkFactory _unitOfWorkFactory;

        /// <summary>
        /// Construct.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory that can create units of work.</param>
        public UpdateItemHandlerV2(IItemManagementUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="model">The command.</param>
        public IActionResult Execute(UpdateItemModel model, ControllerBase context)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            using (IItemManagementUnitOfWork unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                var result = unitOfWork.ItemRepository.GetForId(model.Id);

                // Ensure product exists to update
                if (!result.HasValue())
                    return context.NotFound();

                var item = result.Single();

                var canChangeName = item.CanChangeName(model.Name);
                var canChangeDescription = item.CanChangeDescription(model.Description);
                var errors = new ModelStateDictionary();
                if (!canChangeName || !canChangeDescription)
                {
                    errors.AddModelError(nameof(model.Name), canChangeName.ErrorMessage);
                    errors.AddModelError(nameof(model.Description), canChangeDescription.ErrorMessage);
                    return context.BadRequest(errors);
                }

                unitOfWork.ItemRepository.Update(item);
                unitOfWork.Complete();

                return context.Ok();
            }
        }

    }
}
