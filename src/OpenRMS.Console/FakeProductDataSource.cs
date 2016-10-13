using System;
using System.Collections.Generic;
using System.Linq;
using OpenRMS.Contexts.ItemManagement.QueryStack.Dto;
using OpenRMS.Shared.Kernel.Interfaces;

namespace OpenRMS.Console
{
    internal class FakeProductDataSource : IDataSource<ProductDto>
    {
        private IEnumerable<ProductDto> _products = new List<ProductDto>()
        {
            new ProductDto() { Id = Guid.NewGuid(), Name = "Item 1", Description = "Item 1 Description" },
            new ProductDto() { Id = Guid.NewGuid(), Name = "Item 2", Description = "Item 2 Description" },
            new ProductDto() { Id = Guid.NewGuid(), Name = "Item 3", Description = "Item 3 Description" }
        };

        public IEnumerable<ProductDto> GetAll()
        {
            return _products;
        }

        public ProductDto GetForId(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ProductDto> Query()
        {
            throw new NotImplementedException();
        }
    }
}