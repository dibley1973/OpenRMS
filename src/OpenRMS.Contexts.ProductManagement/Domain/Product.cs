using OpenRMS.Shared.Kernel.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenRMS.Contexts.ProductManagement.Domain
{
    public class Product : Entity
    {
        #region Properties

        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public virtual ICollection<ProductAttribute> Attributes { get; set; }

        #endregion

        #region Construct

        /// <summary>
        /// Construct.
        /// </summary>
        /// <param name="name">The name of the product.</param>
        /// <param name="description">The description of the product</param>
        public Product(string name, string description)
            : this(Guid.NewGuid(), name, description, null)
        { }

        /// <summary>
        /// Construct.
        /// </summary>
        /// <param name="id">The id of the product.</param>
        /// <param name="name">The name of the product.</param>
        /// <param name="description">The description of the product</param>
        /// <param name="attributes">The attributes of the product</param>
        public Product(Guid id, string name, string description, ICollection<ProductAttribute> attributes)
            : base(id)
        {
            SetValues(name, description);
            Attributes = attributes ?? new List<ProductAttribute>();
        }

        #endregion

        /// <summary>
        /// Sets the shallow properties of the product.
        /// </summary>
        /// <param name="name">The name of the product.</param>
        /// <param name="description">The description of the product</param>
        public void SetValues(string name, string description)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("name");
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentNullException("description");

            Name = name;
            Description = description;
        }
    }
}
