using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using OpenRMS.Contexts.ProductManagement.Domain;
using OpenRMS.Contexts.ProductManagement.Infrastructure.PostgreSql.EntityConfigurations;
using System;

namespace OpenRMS.Contexts.ProductManagement.Infrastructure.PostgreSql
{
    /// <summary>
    /// Extends EF DbContext to provide a data context for product management.
    /// </summary>
    public class PostgreSqlProductManagementContext : DbContext
    {
        /// <summary>
        /// Construct.
        /// </summary>
        /// <param name="options">The options to configure the context.</param>
        public PostgreSqlProductManagementContext(DbContextOptions<PostgreSqlProductManagementContext> options) 
            : base(options)
        {
            
        }

        /// <summary>
        /// Executes when the model is being created.
        /// </summary>
        /// <param name="builder">Model builder.</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {            
            base.OnModelCreating(builder);

            // Add postgres extension to support guids
            builder.HasPostgresExtension("uuid-ossp");

            // Add entity cofigurations
            new ProductConfiguration(builder.Entity<Product>());
            new ProductAttributeConfiguration(builder.Entity<ProductAttribute>());
        }
    }
}