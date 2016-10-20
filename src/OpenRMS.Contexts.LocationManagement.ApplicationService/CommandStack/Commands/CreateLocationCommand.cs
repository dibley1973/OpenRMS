using OpenRMS.Contexts.LocationManagement.Domain.Entities;
using OpenRMS.Shared.Kernel.BaseClasses;

namespace OpenRMS.Contexts.LocationManagement.ApplicationService.CommandStack.Commands
{
    /// <summary>
    /// A command that will create a product.
    /// </summary>
    public class CreateLocationCommand : Command
    {
        public BusinessCode Code { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        /// <summary>
        /// Construct.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name">The name of the product that will be created.</param>
        /// <param name="description">The description of the product that will be created.</param>
        public CreateLocationCommand(BusinessCode code, string name, string description)
        {
            Code = code;
            Name = name;
            Description = description;
        }
    }
}
