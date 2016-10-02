using System;

namespace OpenRMS.Shared.Kernel.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Completes the current atomic transaction
        /// </summary>
        void Complete();
    }
}