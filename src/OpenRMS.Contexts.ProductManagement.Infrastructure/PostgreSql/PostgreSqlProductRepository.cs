using System;
using System.Collections.Generic;
using System.Linq;

using OpenRMS.Contexts.ProductManagement.Domain;
using OpenRMS.Contexts.ProductManagement.Interfaces;
using OpenRMS.Shared.Kernel.Amplifiers;
using Microsoft.EntityFrameworkCore;

namespace OpenRMS.Contexts.ProductManagement.Infrastructure.PostgreSql
{
    /// <summary>
    /// A repository of products.
    /// </summary>
    public class PostgreSqlProductRepository : IProductRepository
    {
        private readonly PostgreSqlProductManagementContext _context;

        /// <summary>
        /// Construct.
        /// </summary>
        /// <param name="context">A data context to retrieve products from.</param>
        public PostgreSqlProductRepository(PostgreSqlProductManagementContext context)
        {
            if(context == null)
                throw new ArgumentNullException(nameof(context));

            _context = context;
        }

        /// <summary>
        /// Gets all products.
        /// </summary>
        /// <returns>All products.</returns>
        public IEnumerable<Product> GetAll()
        {
            return _context.Set<Product>();
        }

        /// <summary>
        /// Gets the product identified by the specified ID.
        /// </summary>
        /// <param name="id">The ID of the product that is required.</param>
        /// <returns>A product with the specified ID if found.</returns>
        public Maybe<Product, Guid> GetForId(Guid id)
        {
            var product = _context.Set<Product>().SingleOrDefault(p => p.Id == id);

            // TODO: Review if thsi would be preferred?
            return new Maybe<Product, Guid>(product);

            //return product != null
            //    ? new Maybe<Product, Guid>(product)
            //    : new Maybe<Product, Guid>();
        }

        /// <summary>
        /// Gets the product with a name matching that supplied.
        /// </summary>
        /// <param name="name">The name of the product that is required.</param>
        /// <returns>A product with the specified name if found.</returns>
        public Maybe<Product, Guid> GetForName(string name)
        {
            var product = _context.Set<Product>().SingleOrDefault(p => p.Name == name);

            return new Maybe<Product, Guid>(product);
        }

        /// <summary>
        /// Creates a new product within the repository.
        /// </summary>
        /// <param name="entity">The product to create.</param>
        public void Create(Product entity)
        {
            _context.Set<Product>().Add(entity);
        }

        /// <summary>
        /// Updates the entity provided in the repository.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        public void Update(Product entity)
        {
            _context.Set<Product>().Update(entity);
        }

        /// <summary>
        /// Deletes the entity provided from the repository.
        /// </summary>
        /// <param name="entity">The entity to delete.</param>
        public void Delete(Product entity)
        {
            _context.Set<Product>().Remove(entity);
        }
    }
}
