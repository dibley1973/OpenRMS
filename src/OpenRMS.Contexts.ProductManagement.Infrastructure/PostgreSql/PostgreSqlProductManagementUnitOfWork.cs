using System;
using OpenRMS.Contexts.ProductManagement.Interfaces;
using OpenRMS.Shared.Kernel.Interfaces;

namespace OpenRMS.Contexts.ProductManagement.Infrastructure.PostgreSql
{ 
    /// <summary>
    /// This UnitOfWork is specific for the current bounded context only, ProductManagement.
    /// </summary>
    public class PostgreSqlProductManagementUnitOfWork : IProductManagementUnitOfWork
    {
        private readonly PostgreSqlProductManagementContext _context;
        private readonly PostgreSqlProductRepository _productRepository;
        private bool _disposed;

        /// <summary>
        /// Provides access to the product repository.
        /// </summary>
        public IProductRepository ProductRepository { get { return _productRepository; } }

        /// <summary>
        /// Construct.
        /// </summary>
        /// <param name="context">The product management data context.</param>
        /// <param name="productRepository">A repository of products.</param>
        public PostgreSqlProductManagementUnitOfWork(PostgreSqlProductManagementContext context, IProductRepository productRepository)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            _context = context;

            _productRepository = new PostgreSqlProductRepository(_context);
        }

        /// <summary>
        /// Destruct.
        /// </summary>
        ~PostgreSqlProductManagementUnitOfWork()
        {
            Dispose(false);
        }

        /// <summary>
        /// Commits the current atomic transaction
        /// </summary>
        public void Complete()
        {
            _context.SaveChanges();
        }

        /// <summary>
        /// Disposes of the unit of work.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes the unit of work.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                // free other managed objects that implement IDisposable only
                _context.Dispose();
            }

            // release any unmanaged objects
            // set the object references to null

            _disposed = true;
        }
    }
}