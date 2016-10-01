using OpenRMS.Contexts.ProductManagement.Domain;
using OpenRMS.Shared.Kernel.Interfaces;

namespace OpenRMS.Contexts.ProductManagement.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Product GetForName(string name);
    }
}