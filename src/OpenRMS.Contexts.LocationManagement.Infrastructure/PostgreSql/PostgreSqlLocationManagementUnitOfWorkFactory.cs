using System;
using OpenRMS.Contexts.LocationManagement.Domain.Interfaces;

namespace OpenRMS.Contexts.LocationManagement.Infrastructure.PostgreSql
{
    /// <summary>
    /// A factory that can create product management units of work.
    /// </summary>
    public class PostgreSqlLocationManagementUnitOfWorkFactory : ILocationManagementUnitOfWorkFactory
    {
        private readonly IServiceProvider _services;

        /// <summary>
        /// Construct.
        /// </summary>
        /// <param name="services">A provider of services that are needed to build units of work.</param>
        public PostgreSqlLocationManagementUnitOfWorkFactory(IServiceProvider services)
        {
            _services = services;
        }

        /// <summary>
        /// Creates a unit of work.
        /// </summary>
        /// <returns>An instantiated unit of work.</returns>
        public ILocationManagementUnitOfWork CreateUnitOfWork()
        {
            var context = _services.GetService(typeof(PostgreSqlLocationManagementContext)) as PostgreSqlLocationManagementContext;
            var productRepository = _services.GetService(typeof(ILocationRepository)) as ILocationRepository;

            return new PostgreSqlLocationManagementUnitOfWork(context, productRepository);
        }
    }
}