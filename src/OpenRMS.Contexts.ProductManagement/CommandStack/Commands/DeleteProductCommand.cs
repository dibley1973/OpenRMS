using OpenRMS.Shared.Kernel.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenRMS.Contexts.ProductManagement.CommandStack.Commands
{
    public class DeleteProductCommand : Command
    {
        public Guid Id { get; set; }
    }
}
