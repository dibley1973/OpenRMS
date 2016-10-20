using OpenRMS.Shared.Kernel.Interfaces;

namespace OpenRMS.Contexts.LocationManagement.Domain.Interfaces
{
    /// <summary>
    /// An interface that provides access to a product management unit of work.
    /// </summary>
    public interface ILocationManagementUnitOfWork : IUnitOfWork
    {
        ILocationRepository LocationRepository { get; }
    }
}
