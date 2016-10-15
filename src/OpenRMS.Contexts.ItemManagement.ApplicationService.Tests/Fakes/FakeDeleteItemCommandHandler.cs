using OpenRMS.Contexts.ItemManagement.ApplicationService.CommandStack.Commands;
using OpenRMS.Shared.Kernel.Interfaces;

namespace OpenRMS.Contexts.ItemManagement.ApplicationService.Tests.Fakes
{
    public class FakeDeleteItemCommandHandler : ICommandHandler<DeleteItemCommand>
    {
        public bool ExecuteCalled { get; private set; } 
        public DeleteItemCommand CommandSupplied { get; private set; }

        public void Execute(DeleteItemCommand command)
        {
            ExecuteCalled = true;
            CommandSupplied = command;
        }
    }
}
