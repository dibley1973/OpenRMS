using System;
using OpenRMS.Contexts.ItemManagement.ApplicationService.CommandStack.Commands;
using OpenRMS.Contexts.ItemManagement.Domain;
using OpenRMS.Shared.Kernel.Interfaces;
using OpenRMS.Contexts.ItemManagement.Domain.Entities;

namespace OpenRMS.Contexts.ItemManagement.ApplicationService.CommandStack.Services
{
    /// <summary>
    /// A service that allows various product commands to be executed.
    /// </summary>
    public class ItemCommandService : IItemCommandService
    {
        private ICommandHandler<CreateItemCommand, Item> _createItemHandler;
        private ICommandHandler<UpdateItemCommand> _updateItemHandler;
        private ICommandHandler<DeleteItemCommand> _deleteItemHandler;

        /// <summary>
        /// Construct.
        /// </summary>
        /// <param name="createItemHandler">A handler of commands that create products.</param>
        /// <param name="updateItemHandler">A handler of commands that update products.</param>
        /// <param name="deleteItemHandler">A handler of commands that delete products.</param>
        public ItemCommandService(
            ICommandHandler<CreateItemCommand, Item> createItemHandler,
            ICommandHandler<UpdateItemCommand> updateItemHandler,
            ICommandHandler<DeleteItemCommand> deleteItemHandler)
        {
            _createItemHandler = createItemHandler;
            _updateItemHandler = updateItemHandler;
            _deleteItemHandler = deleteItemHandler;
        }

        /// <summary>
        /// Executes a create product command.
        /// </summary>
        /// <param name="command">The command to execute.</param>
        /// <returns>The id of the created product.</returns>
        public Guid CreateItem(CreateItemCommand command)
        {
            var product = _createItemHandler.Execute(command);
            return product.Id;
        }

        /// <summary>
        /// Executes an update product command.
        /// </summary>
        /// <param name="command">The command to execute.</param>
        public void UpdateItem(UpdateItemCommand command)
        {
            _updateItemHandler.Execute(command);
        }

        /// <summary>
        /// Executes a delete product command.
        /// </summary>
        /// <param name="command">The command to execute.</param>
        public void DeleteItem(DeleteItemCommand command)
        {
            _deleteItemHandler.Execute(command);
        }
    }
}
