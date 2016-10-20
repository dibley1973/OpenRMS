using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenRMS.Contexts.LocationManagement.Domain;
using OpenRMS.Contexts.LocationManagement.Domain.Entities;

namespace OpenRMS.Contexts.LocationManagement.Infrastructure.PostgreSql.EntityConfigurations
{
    /// <summary>
    /// Configures the ef mapping for the product entity.
    /// </summary>
    public class LocationConfiguration
    {
        /// <summary>
        /// Construct.
        /// </summary>
        /// <param name="entityBuilder">An EF entity builder which can be used to configure the product entity.</param>
        public LocationConfiguration(EntityTypeBuilder<Location> entityBuilder)
        {
            entityBuilder.HasKey(product => product.Id);
            entityBuilder.Ignore(product => product.Code);
        }
    }
}
