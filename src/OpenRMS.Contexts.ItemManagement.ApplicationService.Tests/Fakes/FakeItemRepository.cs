using OpenRMS.Contexts.ItemManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using OpenRMS.Contexts.ItemManagement.Domain.Entities;
using OpenRMS.Shared.Kernel.Amplifiers;
using System.Linq;

namespace OpenRMS.Contexts.ItemManagement.ApplicationService.Tests.Fakes
{
    public class FakeItemRepository : IItemRepository
    {
        private readonly FakeItems _items;

        public FakeItemRepository()
        {
            _items = new FakeItems();
        }

        public void Create(Item entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Item entity)
        {
            if (_items.Any(item => item == entity))
            {
                _items.Remove(entity);
            }
            else
            {
                throw new ArgumentException("entity does not exist in collection");
            }
        }

        public IEnumerable<Item> GetAll()
        {
            return _items;
        }

        public Maybe<Item> GetForId(Guid id)
        {
            return new Maybe<Item>(_items.SingleOrDefault(item => item.Id == id));
        }

        public Maybe<Item> GetForName(string name)
        {
            return new Maybe<Item>(_items.SingleOrDefault(item => item.Name == name));

        }

        public void Update(Item entity)
        {
            if (_items.Any(item => item == entity))
            {
                var item = _items.Single(i => i.Id == entity.Id);
                item.ChangeDescription(entity.Description);
                item.ChangeName(entity.Name);
            }
            else
            {
                throw new ArgumentException("entity does not exist in collection");
            }
        }
    }
}
