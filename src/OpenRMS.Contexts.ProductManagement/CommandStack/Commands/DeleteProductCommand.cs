using OpenRMS.Shared.Kernel.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenRMS.Contexts.ProductManagement.CommandStack.Commands
{
    /// <summary>
    /// A command that will delete a product.
    /// </summary>
    public class DeleteProductCommand : Command
    {
        public Guid Id { get; private set; }

        /// <summary>
        /// Construct.
        /// </summary>
        /// <param name="id">The id of the product that will be deleted.</param>
        public DeleteProductCommand(Guid id)
        {
            Id = id;
        }
    }
}
