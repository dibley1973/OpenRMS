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

        public string Name { get; protected set; }
        public string Value { get; protected set; }

        #endregion

        #region Construct

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
            SetValues(name, value);
        }

        #endregion

        /// <summary>
        /// Sets the shallow properties of the product attribute.
        /// </summary>
        /// <param name="name">The name of the product attribute.</param>
        /// <param name="value">The value of the product attribute.</param>
        public void SetValues(string name, string value)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException(nameof(value));

            Name = name;
            Value = Value;
        }
    }
}
