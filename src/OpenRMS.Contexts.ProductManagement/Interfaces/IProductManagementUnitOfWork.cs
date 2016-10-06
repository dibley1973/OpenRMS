using OpenRMS.Shared.Kernel.Interfaces;

namespace OpenRMS.Contexts.ProductManagement.Interfaces
{
    /// <summary>
    /// An interface that provides access to a product management unit of work.
    /// </summary>
    public interface IProductManagementUnitOfWork : IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
    }
}
