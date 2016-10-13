using System;
using OpenRMS.Contexts.ItemManagement.ApplicationService.CommandStack.Commands;

namespace OpenRMS.Contexts.ItemManagement.ApplicationService.CommandStack.Services
{
    /// <summary>
    /// An interface that provides access to a service of product commands.
    /// </summary>
    public interface IItemCommandService
    {
        Guid CreateItem(CreateItemCommand command);
        void UpdateItem(UpdateItemCommand command);
        void DeleteItem(DeleteItemCommand command);
    }
}
