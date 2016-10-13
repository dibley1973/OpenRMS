using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using OpenRMS.Contexts.ItemManagement.Domain.Entities;
using OpenRMS.Contexts.ItemManagement.Infrastructure.PostgreSql.EntityConfigurations;

namespace OpenRMS.Contexts.ItemManagement.Infrastructure.PostgreSql
{
    /// <summary>
    /// Extends EF DbContext to provide a data context for product management.
    /// </summary>
    public class PostgreSqlItemManagementContext : DbContext
    {
        /// <summary>
        /// Construct.
        /// </summary>
        /// <param name="options">The options to configure the context.</param>
        public PostgreSqlItemManagementContext(DbContextOptions<PostgreSqlItemManagementContext> options) 
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
            new ItemConfiguration(builder.Entity<Item>());
        }
    }
}