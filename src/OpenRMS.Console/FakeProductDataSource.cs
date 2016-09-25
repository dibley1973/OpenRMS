using System;
using System.Collections.Generic;
using System.Linq;
using OpenRMS.Contexts.ProductManagement.QueryStack.Dto;
using OpenRMS.Shared.Kernel.Interfaces;

namespace OpenRMS.Console
{
    internal class FakeProductDataSource : IDataSource<ProductDto>
    {
        private IEnumerable<ProductDto> _products = new List<ProductDto>()
        {
            new ProductDto() { Id = Guid.NewGuid(), Name = "Product 1", Description = "Product 1 Description" },
            new ProductDto() { Id = Guid.NewGuid(), Name = "Product 2", Description = "Product 2 Description" },
            new ProductDto() { Id = Guid.NewGuid(), Name = "Product 3", Description = "Product 3 Description" }
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