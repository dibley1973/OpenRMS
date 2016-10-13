using System;
using System.Collections.Generic;
using System.Linq;
using OpenRMS.Contexts.ItemManagement.Domain;
using OpenRMS.Contexts.ItemManagement.Interfaces;
using OpenRMS.Shared.Kernel.Amplifiers;
using OpenRMS.Shared.Kernel.Interfaces;

namespace OpenRMS.Console
{
    internal class FakeItemRepository : IItemRepository /*,  IRepository<Item>*/
    {
        private List<Item> _products = new List<Item>()
        {
            new Item( id: Guid.NewGuid(), code: "1", name: "Item 1", description: "Item 1 Description" ),
            new Item( id:Guid.NewGuid(), code: "2", name: "Item 2", description: "Item 2 Description" ),
            new Item( id:Guid.NewGuid(), code: "3", name: "Item 3", description: "Item 3 Description" )
        };

        public void Create(Item entity)
        {
            _products.Add(entity);
        }

        public void Delete(Item entity)
        {
            var hasEntity = _products.Any(product => product == entity);
            if (!hasEntity)
            {
                throw new InvalidOperationException("product not found to delete");
            }
            _products.Remove(entity);
        }

        public IEnumerable<Item> GetAll()
        {
            return _products;
        }

        public Maybe<Item> GetForId(Guid id)
        {
            var product = _products.SingleOrDefault(p => p.Id == id);

            if (product == null) return new Maybe<Item>();

            return new Maybe<Item>(product);
        }

        public Maybe<Item> GetForName(string name)
        {
            var product = _products.SingleOrDefault(p => p.Name == name);

            if (product == null) return new Maybe<Item>();

            return new Maybe<Item>(product);
        }

        public void Update(Item entity)
        {
            var product = _products.SingleOrDefault(p => p.Id == entity.Id);

            if (product == null) throw new InvalidOperationException("product not found in collection");

            product.ChangeName(entity.Name);
            product.ChangeDescription(entity.Description);

        }
    }
}