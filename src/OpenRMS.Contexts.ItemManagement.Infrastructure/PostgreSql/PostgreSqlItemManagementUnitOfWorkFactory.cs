using System;
using OpenRMS.Contexts.ItemManagement.Domain.Interfaces;

namespace OpenRMS.Contexts.ItemManagement.Infrastructure.PostgreSql
{
    /// <summary>
    /// A factory that can create product management units of work.
    /// </summary>
    public class PostgreSqlItemManagementUnitOfWorkFactory : IItemManagementUnitOfWorkFactory
    {
        private readonly IServiceProvider _services;

        /// <summary>
        /// Construct.
        /// </summary>
        /// <param name="services">A provider of services that are needed to build units of work.</param>
        public PostgreSqlItemManagementUnitOfWorkFactory(IServiceProvider services)
        {
            _services = services;
        }

        /// <summary>
        /// Creates a unit of work.
        /// </summary>
        /// <returns>An instantiated unit of work.</returns>
        public IItemManagementUnitOfWork CreateUnitOfWork()
        {
            var context = _services.GetService(typeof(PostgreSqlItemManagementContext)) as PostgreSqlItemManagementContext;
            var productRepository = _services.GetService(typeof(IItemRepository)) as IItemRepository;

            return new PostgreSqlItemManagementUnitOfWork(context, productRepository);
        }
    }
}