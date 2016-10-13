using System;
using OpenRMS.Shared.Kernel.BaseClasses;

namespace OpenRMS.Contexts.ItemManagement.Domain.Entities
{
    /// <summary>
    /// Represents a product.
    /// </summary>
    public class Item : AggregateRoot<Guid>
    {
        #region Properties

        public string Name { get; private set; }
        public string Description { get; private set; }

        #endregion

        #region Construct

        /// <summary>
        /// Parameterless constructor.
        /// </summary>
        private Item() : base() { }

        /// <summary>
        /// Construct.
        /// </summary>
        /// <param name="name">The name of the product.</param>
        /// <param name="description">The description of the product</param>
        public Item(string name, string description)
            : base(Guid.NewGuid())
        {
            ChangeName(name);
            ChangeDescription(description);
        }

        /// <summary>
        /// Construct.
        /// </summary>
        /// <param name="id">The id of the product.</param>
        /// <param name="name">The name of the product.</param>
        /// <param name="description">The description of the product</param>
        /// <param name="attributes">The attributes of the product</param>
        public Item(Guid id, string name, string description)
            : base(id)
        {
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
        }

        /// <summary>
        /// Changes the products description.
        /// </summary>
        /// <param name="description">The new description of the product.</param>
        public void ChangeDescription(string description)
        {
            if (description==null)
                throw new ArgumentNullException(nameof(description));

            Description = description;
        }

    }
}
