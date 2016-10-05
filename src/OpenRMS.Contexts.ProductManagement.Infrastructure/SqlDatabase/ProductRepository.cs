using System;
using System.Collections.Generic;
using System.Linq;

using OpenRMS.Contexts.ProductManagement.Domain;
using OpenRMS.Contexts.ProductManagement.Interfaces;
using OpenRMS.Shared.Kernel.Amplifiers;

namespace OpenRMS.Contexts.ProductManagement.Infrastructure.SqlDatabase
{
    public class ProductRepository : IProductRepository
    {
        private ProductManagementContext _context;

        public ProductRepository(ProductManagementContext context)
        {
            if(context == null) throw new ArgumentNullException(nameof(context));

            _context = context;
        }

        public IEnumerable<Product> GetAll()
        {
            //return _context.DbSet<Product>.ToList();
            throw new NotImplementedException();
        }

        public Maybe<Product, Guid> GetForId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Create(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public Maybe<Product, Guid> GetForName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
