using System;
using OpenRMS.Contexts.ProductManagement.Interfaces;
using OpenRMS.Shared.Kernel.Interfaces;

namespace OpenRMS.Contexts.ProductManagement.Infrastructure.PostgreSql
{
    /// <summary>
    /// A factory that can create product management units of work.
    /// </summary>
    public class PostgreSqlProductManagementUnitOfWorkFactory : IProductManagementUnitOfWorkFactory
    {
        private readonly IServiceProvider _services;

        /// <summary>
        /// Construct.
        /// </summary>
        /// <param name="services">A provider of services that are needed to build units of work.</param>
        public PostgreSqlProductManagementUnitOfWorkFactory(IServiceProvider services)
        {
            _services = services;
        }

        /// <summary>
        /// Creates a unit of work.
        /// </summary>
        /// <returns>An instantiated unit of work.</returns>
        public IProductManagementUnitOfWork CreateUnitOfWork()
        {
            var context = _services.GetService(typeof(PostgreSqlProductManagementContext)) as PostgreSqlProductManagementContext;
            var productRepository = _services.GetService(typeof(IProductRepository)) as IProductRepository;

            return new PostgreSqlProductManagementUnitOfWork(context, productRepository);
        }
    }
}