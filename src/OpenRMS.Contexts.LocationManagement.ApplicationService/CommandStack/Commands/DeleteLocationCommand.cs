using System;
using OpenRMS.Shared.Kernel.BaseClasses;

namespace OpenRMS.Contexts.LocationManagement.ApplicationService.CommandStack.Commands
{
    /// <summary>
    /// A command that will delete a product.
    /// </summary>
    public class DeleteLocationCommand : Command
    {
        public Guid Id { get; private set; }

        /// <summary>
        /// Construct.
        /// </summary>
        /// <param name="id">The id of the product that will be deleted.</param>
        public DeleteLocationCommand(Guid id)
        {
            Id = id;
        }
    }
}
