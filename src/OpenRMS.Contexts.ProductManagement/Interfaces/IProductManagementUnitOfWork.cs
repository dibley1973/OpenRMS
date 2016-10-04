using OpenRMS.Shared.Kernel.Interfaces;

namespace OpenRMS.Contexts.ProductManagement.Interfaces
{
    public interface IProductManagementUnitOfWork : IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
    }
}
