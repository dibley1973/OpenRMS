using OpenRMS.Contexts.ProductManagement.Interfaces;
using OpenRMS.Shared.Kernel.Interfaces;

namespace OpenRMS.Contexts.ProductManagement.Infrastructure
{
    public interface IProductManagementUnitOfWork : IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
    }
}
