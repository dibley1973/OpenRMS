using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenRMS.Contexts.ProductManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenRMS.Contexts.ProductManagement.Infrastructure.PostgreSql.EntityConfigurations
{
    /// <summary>
    /// Configures the ef mapping for the product attribute entity.
    /// </summary>
    public class ProductAttributeConfiguration
    {
        /// <summary>
        /// Construct.
        /// </summary>
        /// <param name="entityBuilder">An EF entity builder which can be used to configure the product attribute entity.</param>
        public ProductAttributeConfiguration(EntityTypeBuilder<ProductAttribute> entityBuilder)
        {
            entityBuilder.HasKey(attribute => attribute.Id);
        }
    }
}
