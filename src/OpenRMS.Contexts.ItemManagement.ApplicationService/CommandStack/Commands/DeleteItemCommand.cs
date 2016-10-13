using System;
using OpenRMS.Shared.Kernel.BaseClasses;

namespace OpenRMS.Contexts.ItemManagement.ApplicationService.CommandStack.Commands
{
    /// <summary>
    /// A command that will delete a product.
    /// </summary>
    public class DeleteItemCommand : Command
    {
        public Guid Id { get; private set; }

        /// <summary>
        /// Construct.
        /// </summary>
        /// <param name="id">The id of the product that will be deleted.</param>
        public DeleteItemCommand(Guid id)
        {
            Id = id;
        }
    }
}
