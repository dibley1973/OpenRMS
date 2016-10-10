using System;
using OpenRMS.Contexts.ProductManagement.Domain;
using OpenRMS.Shared.Kernel.Interfaces;
using OpenRMS.Shared.Kernel.Amplifiers;

namespace OpenRMS.Contexts.ProductManagement.Interfaces
{
    /// <summary>
    /// An interface that provides access to a repository of products.
    /// </summary>
    public interface IProductRepository : IRepository<Product, Guid>
    {
        Maybe<Product> GetForName(string name);
    }
}