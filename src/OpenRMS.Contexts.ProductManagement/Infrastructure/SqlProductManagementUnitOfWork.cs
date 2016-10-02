using System;
using OpenRMS.Contexts.ProductManagement.Interfaces;
using OpenRMS.Shared.Kernel.Interfaces;

namespace OpenRMS.Contexts.ProductManagement.Infrastructure
{
    /// <summary>
    /// This UnitOfWork is specific for the current bounded context only, ProductManagement.
    /// </summary>
    public class SqlProductManagementUnitOfWork : IProductManagementUnitOfWork
    {
        private readonly SqlProductManagmentContext _context;
        private bool _disposed;

        public SqlProductManagementUnitOfWork(SqlProductManagmentContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            _context = context;

            ProductRepository = new SqlProductRepository(_context);
        }

        public IProductRepository ProductRepository { get; }
        
        /// <summary>
        /// Commits the current atomic transaction
        /// </summary>
        public void Complete()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~SqlProductManagementUnitOfWork()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                // free other managed objects that implement
                // IDisposable only
                _context.Dispose();
            }

            // release any unmanaged objects
            // set the object references to null

            _disposed = true;
        }
    }
}