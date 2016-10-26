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
        public IActionResult Execute(UpdateItemModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            using (var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                var maybeItem = unitOfWork.ItemRepository.GetForId(model.Id);
                if (maybeItem.HasValue()==false) return new NotFoundResult();

                var item = maybeItem.Single();

                var canChangeName = item.CanChangeName(model.Name);
                var canChangeDescription = item.CanChangeDescription(model.Description);

                if (canChangeName && canChangeDescription)
                {
                    item.ChangeName(model.Name);
                    item.ChangeDescription(model.Description);

                    unitOfWork.Complete();
                    return new OkResult();
                }

                var errors = new ModelStateDictionary();
                if (!canChangeName) errors.AddModelError(nameof(model.Name), canChangeName.ErrorMessage);
                if (!canChangeDescription) errors.AddModelError(nameof(model.Description), canChangeDescription.ErrorMessage);
                return new BadRequestObjectResult(errors);
            }
        }

    }
}
