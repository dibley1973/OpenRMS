using System;
using OpenRMS.Contexts.ItemManagement.Domain.Interfaces;

namespace OpenRMS.Contexts.ItemManagement.Infrastructure.PostgreSql
{ 
    /// <summary>
    /// This UnitOfWork is specific for the current bounded context only, ItemManagement.
    /// </summary>
    public class PostgreSqlItemManagementUnitOfWork : IItemManagementUnitOfWork
    {
        private readonly PostgreSqlItemManagementContext _context;
        private readonly PostgreSqlItemRepository _itemRepository;
        private bool _disposed;

        /// <summary>
        /// Provides access to the product repository.
        /// </summary>
        public IItemRepository ItemRepository { get { return _itemRepository; } }

        /// <summary>
        /// Construct.
        /// </summary>
        /// <param name="context">The product management data context.</param>
        /// <param name="itemRepository">A repository of products.</param>
        public PostgreSqlItemManagementUnitOfWork(PostgreSqlItemManagementContext context, IItemRepository itemRepository)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            _context = context;

            _itemRepository = new PostgreSqlItemRepository(_context);
        }

        /// <summary>
        /// Destruct.
        /// </summary>
        ~PostgreSqlItemManagementUnitOfWork()
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