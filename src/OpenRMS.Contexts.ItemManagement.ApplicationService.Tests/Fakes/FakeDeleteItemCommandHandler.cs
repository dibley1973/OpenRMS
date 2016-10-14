using OpenRMS.Contexts.ItemManagement.ApplicationService.CommandStack.Commands;
using OpenRMS.Contexts.ItemManagement.Domain.Interfaces;
using OpenRMS.Contexts.ItemManagement.Domain.Entities;
using OpenRMS.Shared.Kernel.Interfaces;
using System;

namespace OpenRMS.Contexts.ItemManagement.ApplicationService.Tests.Fakes
{
    public class FakeDeleteItemCommandHandler : ICommandHandler<DeleteItemCommand>
    {
        public void Execute(DeleteItemCommand command)
        {
            // Nothing to do...
        }
    }
}
