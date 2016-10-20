using System;
using OpenRMS.Contexts.LocationManagement.Domain.Interfaces;

namespace OpenRMS.Contexts.LocationManagement.Infrastructure.PostgreSql
{ 
    /// <summary>
    /// This UnitOfWork is specific for the current bounded context only, LocationManagement.
    /// </summary>
    public class PostgreSqlLocationManagementUnitOfWork : ILocationManagementUnitOfWork
    {
        private readonly PostgreSqlLocationManagementContext _context;
        private readonly PostgreSqlLocationRepository _itemRepository;
        private bool _disposed;

        /// <summary>
        /// Provides access to the product repository.
        /// </summary>
        public ILocationRepository LocationRepository { get { return _itemRepository; } }

        /// <summary>
        /// Construct.
        /// </summary>
        /// <param name="context">The product management data context.</param>
        /// <param name="itemRepository">A repository of products.</param>
        public PostgreSqlLocationManagementUnitOfWork(PostgreSqlLocationManagementContext context, ILocationRepository itemRepository)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            _context = context;

            _itemRepository = new PostgreSqlLocationRepository(_context);
        }

        /// <summary>
        /// Destruct.
        /// </summary>
        ~PostgreSqlLocationManagementUnitOfWork()
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