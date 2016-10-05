using System;
using OpenRMS.Contexts.ProductManagement.Interfaces;
using OpenRMS.Shared.Kernel.Interfaces;

namespace OpenRMS.Contexts.ProductManagement.Infrastructure.SqlDatabase
{ 
    /// <summary>
    /// This UnitOfWork is specific for the current bounded context only, ProductManagement.
    /// </summary>
    public class ProductManagementUnitOfWork : IProductManagementUnitOfWork
    {
        private readonly ProductManagementContext _context;
        private bool _disposed;

        public ProductManagementUnitOfWork(ProductManagementContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            _context = context;

            ProductRepository = new ProductRepository(_context);
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

        ~ProductManagementUnitOfWork()
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