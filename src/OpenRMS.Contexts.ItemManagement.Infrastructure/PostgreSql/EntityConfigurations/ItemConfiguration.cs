using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenRMS.Contexts.ItemManagement.Domain;
using OpenRMS.Contexts.ItemManagement.Domain.Entities;

namespace OpenRMS.Contexts.ItemManagement.Infrastructure.PostgreSql.EntityConfigurations
{
    /// <summary>
    /// Configures the ef mapping for the product entity.
    /// </summary>
    public class ItemConfiguration
    {
        /// <summary>
        /// Construct.
        /// </summary>
        /// <param name="entityBuilder">An EF entity builder which can be used to configure the product entity.</param>
        public ItemConfiguration(EntityTypeBuilder<Item> entityBuilder)
        {
            entityBuilder.HasKey(product => product.Id);
        }
    }
}
