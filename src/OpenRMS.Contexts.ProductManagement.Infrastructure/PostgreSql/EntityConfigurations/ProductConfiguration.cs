using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenRMS.Contexts.ProductManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenRMS.Contexts.ProductManagement.Infrastructure.PostgreSql.EntityConfigurations
{
    /// <summary>
    /// Configures the ef mapping for the product entity.
    /// </summary>
    public class ProductConfiguration
    {
        /// <summary>
        /// Construct.
        /// </summary>
        /// <param name="entityBuilder">An EF entity builder which can be used to configure the product entity.</param>
        public ProductConfiguration(EntityTypeBuilder<Product> entityBuilder)
        {
            entityBuilder.HasKey(product => product.Id);

            // A product has many attributes
            entityBuilder.HasMany(product => product.Attributes).WithOne().HasPrincipalKey(product => product.Id);                
        }
    }
}
