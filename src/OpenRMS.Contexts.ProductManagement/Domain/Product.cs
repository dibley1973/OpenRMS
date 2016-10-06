using OpenRMS.Shared.Kernel.BaseClasses;
using System;
using System.Collections.Generic;

namespace OpenRMS.Contexts.ProductManagement.Domain
{
    public class Product : Entity<Guid>
    {
        #region Properties

        public string Name { get; private set; }
        public string Description { get; private set; }
        public virtual ICollection<ProductAttribute> Attributes { get; private set; }

        #endregion

        #region Construct

        /// <summary>
        /// Parameterless constructor.
        /// </summary>
        private Product() : base() { }

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
            ChangeName(name);
            ChangeDescription(description);
            Attributes = attributes ?? new List<ProductAttribute>();
        }

        #endregion

        /// <summary>
        /// Changes the products name.
        /// </summary>
        /// <param name="name">The new name of the product.</param>
        public void ChangeName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            Name = name;
        }

        /// <summary>
        /// Changes the products description.
        /// </summary>
        /// <param name="description">The new description of the product.</param>
        public void ChangeDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentNullException(nameof(description));

            Description = description;
        }
    }
}
