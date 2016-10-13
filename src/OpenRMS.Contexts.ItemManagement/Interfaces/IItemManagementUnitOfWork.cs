using OpenRMS.Shared.Kernel.Interfaces;

namespace OpenRMS.Contexts.ItemManagement.Interfaces
{
    /// <summary>
    /// An interface that provides access to a product management unit of work.
    /// </summary>
    public interface IItemManagementUnitOfWork : IUnitOfWork
    {
        IItemRepository ItemRepository { get; }
    }
}
