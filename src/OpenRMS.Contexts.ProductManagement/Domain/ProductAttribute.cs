using OpenRMS.Shared.Kernel.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenRMS.Contexts.ProductManagement.Domain
{
    public class ProductAttribute : Entity<Guid>
    {
        #region Properties

        public string Name { get; private set; }
        public string Value { get; private set; }

        #endregion

        #region Construct

        /// <summary>
        /// Parameterless constructor.
        /// </summary>
        private ProductAttribute() : base() { }

        /// <summary>
        /// Construct.
        /// </summary>
        /// <param name="name">The name of the product attribute.</param>
        /// <param name="description">The description of the product attribute.</param>
        public ProductAttribute(string name, string description)
            : this(Guid.NewGuid(), name, description)
        { }

        /// <summary>
        /// Construct.
        /// </summary>
        /// <param name="id">The id of the product attribute.</param>
        /// <param name="name">The name of the product attribute.</param>
        /// <param name="value">The value of the product attribute.</param>
        public ProductAttribute(Guid id, string name, string value)
            : base(id)
        {
            ChangeName(name);
            ChangeValue(value);
        }

        #endregion

        /// <summary>
        /// Changes the product attributes name.
        /// </summary>
        /// <param name="name">The new name of the product attribute.</param>
        public void ChangeName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            Name = name;
        }

        /// <summary>
        /// Changes the product attributes value.
        /// </summary>
        /// <param name="value">The new value of the product attribute.</param>
        public void ChangeValue(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException(nameof(value));

            Value = value;
        }
    }
}
