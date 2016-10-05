using System;

namespace OpenRMS.Shared.Kernel.Interfaces
{
    /// <summary>
    /// An interface that provides access to a unit of work factory.
    /// </summary>
    /// <typeparam name="TUnitOfWork">The type of unit of work that the factory can create.</typeparam>
    public interface IUnitOfWorkFactory<TUnitOfWork> where TUnitOfWork : IUnitOfWork
    {
        TUnitOfWork CreateUnitOfWork();
    }
}