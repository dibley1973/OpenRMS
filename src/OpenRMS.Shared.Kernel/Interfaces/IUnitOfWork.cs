using System;

namespace OpenRMS.Shared.Kernel.Interfaces
{
    /// <summary>
    /// An interface that provides access to a unit of work.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Completes the current atomic transaction
        /// </summary>
        void Complete();
    }
}