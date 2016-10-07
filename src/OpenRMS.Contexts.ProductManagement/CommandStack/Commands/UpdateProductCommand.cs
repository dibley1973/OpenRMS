using OpenRMS.Shared.Kernel.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenRMS.Contexts.ProductManagement.CommandStack.Commands
{
    /// <summary>
    /// A command that will update a product.
    /// </summary>
    public class UpdateProductCommand : Command
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        /// <summary>
        /// Construct.
        /// </summary>
        /// <param name="id">The id of the product that will be updated.</param>
        /// <param name="name">The name of the product that will be updated.</param>
        /// <param name="description">The description of the product that will be updated.</param>
        public UpdateProductCommand(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
