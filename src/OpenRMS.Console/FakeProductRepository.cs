using System;
using System.Collections.Generic;
using System.Linq;
using OpenRMS.Contexts.ProductManagement.Domain;
using OpenRMS.Contexts.ProductManagement.Interfaces;
using OpenRMS.Shared.Kernel.Amplifiers;
using OpenRMS.Shared.Kernel.Interfaces;

namespace OpenRMS.Console
{
    internal class FakeProductRepository : IProductRepository /*,  IRepository<Product>*/
    {
        public void Create(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public Maybe<Product, Guid> GetForId(Guid id)
        {
            throw new NotImplementedException();
        }

        //public Product GetForId(Guid id)
        //{
        //    throw new NotImplementedException();
        //}

        public Maybe<Product, Guid> GetForName(string name)
        {
            throw new NotImplementedException();
        }

        //public IQueryable<Product> Query()
        //{
        //    throw new NotImplementedException();
        //}

        //public void Save()
        //{
        //    throw new NotImplementedException();
        //}

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}