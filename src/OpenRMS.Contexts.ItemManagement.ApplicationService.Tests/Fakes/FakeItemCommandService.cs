using OpenRMS.Contexts.ItemManagement.ApplicationService.CommandStack.Services;
using System;
using OpenRMS.Contexts.ItemManagement.ApplicationService.CommandStack.Commands;

namespace OpenRMS.Contexts.ItemManagement.ApplicationService.Tests.Fakes
{
    public class FakeItemCommandService : IItemCommandService
    {
        public Guid CreateItem(CreateItemCommand command)
        {
            throw new NotImplementedException();
        }

        public void DeleteItem(DeleteItemCommand command)
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(UpdateItemCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
