using OpenRMS.Shared.Kernel.BaseClasses;

namespace OpenRMS.Contexts.ItemManagement.CommandStack.Commands
{
    /// <summary>
    /// A command that will create a product.
    /// </summary>
    public class CreateItemCommand : Command
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        /// <summary>
        /// Construct.
        /// </summary>
        /// <param name="name">The name of the product that will be created.</param>
        /// <param name="description">The description of the product that will be created.</param>
        public CreateItemCommand(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
