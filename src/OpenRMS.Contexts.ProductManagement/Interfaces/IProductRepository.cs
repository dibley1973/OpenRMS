using System;
using OpenRMS.Contexts.ProductManagement.Domain;
using OpenRMS.Shared.Kernel.Interfaces;
using OpenRMS.Shared.Kernel.Amplifiers;

namespace OpenRMS.Contexts.ProductManagement.Interfaces
{
    public interface IProductRepository : IRepository<Product, Guid>
    {
        Maybe<Product, Guid> GetForName(string name);
    }
}