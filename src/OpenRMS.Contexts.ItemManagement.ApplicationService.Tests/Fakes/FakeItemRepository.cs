using OpenRMS.Contexts.ItemManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using OpenRMS.Contexts.ItemManagement.Domain.Entities;
using OpenRMS.Shared.Kernel.Amplifiers;

namespace OpenRMS.Contexts.ItemManagement.ApplicationService.Tests.Fakes
{
    public class FakeItemRepository : IItemRepository
    {
        public void Create(Item entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Item entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> GetAll()
        {
            throw new NotImplementedException();
        }

        public Maybe<Item> GetForId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Maybe<Item> GetForName(string name)
        {
            throw new NotImplementedException();
        }

        public void Update(Item entity)
        {
            throw new NotImplementedException();
        }
    }
}
