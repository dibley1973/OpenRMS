using OpenRMS.Contexts.ItemManagement.ApplicationService.CommandStack.Services;
using System;
using OpenRMS.Contexts.ItemManagement.ApplicationService.CommandStack.Commands;
using OpenRMS.Contexts.ItemManagement.Domain.Interfaces;

namespace OpenRMS.Contexts.ItemManagement.ApplicationService.Tests.Fakes
{
    public class FakeItemCommandService : IItemCommandService
    {
        private readonly IItemRepository _repository;

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
