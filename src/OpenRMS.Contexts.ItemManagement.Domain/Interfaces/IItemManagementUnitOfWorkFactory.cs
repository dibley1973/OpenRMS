using OpenRMS.Shared.Kernel.Interfaces;

namespace OpenRMS.Contexts.ItemManagement.Domain.Interfaces
{
    /// <summary>
    /// An interface that provides access to a product management unit of work factory.
    /// </summary>
    public interface IItemManagementUnitOfWorkFactory : IUnitOfWorkFactory<IItemManagementUnitOfWork>
    {

    }
}
