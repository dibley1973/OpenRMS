using OpenRMS.Shared.Kernel.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenRMS.Contexts.ProductManagement.CommandStack.Commands
{
    /// <summary>
    /// A command that will create a product.
    /// </summary>
    public class CreateProductCommand : Command
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        /// <summary>
        /// Construct.
        /// </summary>
        /// <param name="name">The name of the product that will be created.</param>
        /// <param name="description">The description of the product that will be created.</param>
        public CreateProductCommand(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
