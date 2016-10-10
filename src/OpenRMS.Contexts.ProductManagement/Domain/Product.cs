using OpenRMS.Shared.Kernel.BaseClasses;
using System;
using System.Collections.Generic;

namespace OpenRMS.Contexts.ProductManagement.Domain
{
    /// <summary>
    /// Represents a product.
    /// </summary>
    public class Product : AggregateRoot<Guid>
    {
        #region Properties

        public string Code { get; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public virtual ICollection<ProductAttribute> Attributes { get; private set; } = new List<ProductAttribute>();

        #endregion

        #region Construct

        /// <summary>
        /// Parameterless constructor.
        /// </summary>
        private Product() : base() { }

        public Product(string code, string name)
            : this(Guid.NewGuid(), code, name, string.Empty)
        { }
        
        public Product(Guid id, string code , string name, string description)
            : base(id)
        {
            if (string.IsNullOrWhiteSpace(code))
                throw new ArgumentNullException(nameof(code));

            Code = code;
            
            ChangeName(name);
            ChangeDescription(description);
        }

        #endregion

        /// <summary>
        /// Changes the products name.
        /// </summary>
        /// <param name="name">The new name of the product.</param>
        public void ChangeName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));

            Name = name;

            AddDomainEvent(new ProductNameChangedEvent(name));
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
