using OpenRMS.Shared.Kernel.Interfaces;

namespace OpenRMS.Contexts.ProductManagement.Interfaces
{
    /// <summary>
    /// An interface that provides access to a product management unit of work factory.
    /// </summary>
    public interface IProductManagementUnitOfWorkFactory : IUnitOfWorkFactory<IProductManagementUnitOfWork>
    {

    }
}
