using System;
using System.Collections.Generic;
using System.Linq;
using OpenRMS.Contexts.ItemManagement.Domain;
using OpenRMS.Contexts.ItemManagement.Interfaces;
using OpenRMS.Shared.Kernel.Amplifiers;

namespace OpenRMS.Contexts.ItemManagement.Infrastructure.PostgreSql
{
    /// <summary>
    /// A repository of products.
    /// </summary>
    public class PostgreSqlItemRepository : IItemRepository
    {
        private readonly PostgreSqlItemManagementContext _context;

        /// <summary>
        /// Construct.
        /// </summary>
        /// <param name="context">A data context to retrieve products from.</param>
        public PostgreSqlItemRepository(PostgreSqlItemManagementContext context)
        {
            if(context == null)
                throw new ArgumentNullException(nameof(context));

            _context = context;
        }

        /// <summary>
        /// Gets all products.
        /// </summary>
        /// <returns>All products.</returns>
        public IEnumerable<Item> GetAll()
        {
            return _context.Set<Item>();
        }

        /// <summary>
        /// Gets the product identified by the specified ID.
        /// </summary>
        /// <param name="id">The ID of the product that is required.</param>
        /// <returns>A product with the specified ID if found.</returns>
        public Maybe<Item> GetForId(Guid id)
        {
            var product = _context.Set<Item>().SingleOrDefault(p => p.Id == id);

            return new Maybe<Item>(product);
        }

        /// <summary>
        /// Gets the product with a name matching that supplied.
        /// </summary>
        /// <param name="name">The name of the product that is required.</param>
        /// <returns>A product with the specified name if found.</returns>
        public Maybe<Item> GetForName(string name)
        {
            var product = _context.Set<Item>().SingleOrDefault(p => p.Name == name);

            return new Maybe<Item>(product);
        }

        /// <summary>
        /// Creates a new product within the repository.
        /// </summary>
        /// <param name="entity">The product to create.</param>
        public void Create(Item entity)
        {
            _context.Set<Item>().Add(entity);
        }

        /// <summary>
        /// Updates the entity provided in the repository.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        public void Update(Item entity)
        {
            _context.Set<Item>().Update(entity);
        }

        /// <summary>
        /// Deletes the entity provided from the repository.
        /// </summary>
        /// <param name="entity">The entity to delete.</param>
        public void Delete(Item entity)
        {
            _context.Set<Item>().Remove(entity);
        }
    }
}
