using System;
using System.Collections.Generic;
using System.Linq;
using OpenRMS.Contexts.LocationManagement.Domain;
using OpenRMS.Contexts.LocationManagement.Domain.Interfaces;
using OpenRMS.Shared.Kernel.Amplifiers;
using OpenRMS.Contexts.LocationManagement.Domain.Entities;

namespace OpenRMS.Contexts.LocationManagement.Infrastructure.PostgreSql
{
    /// <summary>
    /// A repository of products.
    /// </summary>
    public class PostgreSqlLocationRepository : ILocationRepository
    {
        private readonly PostgreSqlLocationManagementContext _context;

        /// <summary>
        /// Construct.
        /// </summary>
        /// <param name="context">A data context to retrieve products from.</param>
        public PostgreSqlLocationRepository(PostgreSqlLocationManagementContext context)
        {
            if(context == null)
                throw new ArgumentNullException(nameof(context));

            _context = context;
        }

        /// <summary>
        /// Gets all products.
        /// </summary>
        /// <returns>All products.</returns>
        public IEnumerable<Location> GetAll()
        {
            return _context.Set<Location>();
        }

        /// <summary>
        /// Gets the product identified by the specified ID.
        /// </summary>
        /// <param name="id">The ID of the product that is required.</param>
        /// <returns>A product with the specified ID if found.</returns>
        public Maybe<Location> GetForId(Guid id)
        {
            var product = _context.Set<Location>().SingleOrDefault(p => p.Id == id);

            return new Maybe<Location>(product);
        }

        /// <summary>
        /// Gets the product with a name matching that supplied.
        /// </summary>
        /// <param name="name">The name of the product that is required.</param>
        /// <returns>A product with the specified name if found.</returns>
        public Maybe<Location> GetForName(string name)
        {
            var product = _context.Set<Location>().SingleOrDefault(p => p.Name == name);

            return new Maybe<Location>(product);
        }

        /// <summary>
        /// Creates a new product within the repository.
        /// </summary>
        /// <param name="entity">The product to create.</param>
        public void Create(Location entity)
        {
            _context.Set<Location>().Add(entity);
        }

        /// <summary>
        /// Updates the entity provided in the repository.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        public void Update(Location entity)
        {
            _context.Set<Location>().Update(entity);
        }

        /// <summary>
        /// Deletes the entity provided from the repository.
        /// </summary>
        /// <param name="entity">The entity to delete.</param>
        public void Delete(Location entity)
        {
            _context.Set<Location>().Remove(entity);
        }
    }
}
