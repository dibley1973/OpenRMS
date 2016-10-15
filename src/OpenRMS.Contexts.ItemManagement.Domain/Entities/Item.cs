using System;
using OpenRMS.Shared.Kernel.BaseClasses;

namespace OpenRMS.Contexts.ItemManagement.Domain.Entities
{
    /// <summary>
    /// Represents a product.
    /// </summary>
    public class Item : AggregateRoot
    {
        #region Properties

        public ItemCode Code { get; private set; }
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
        /// <param name="code"></param>
        /// <param name="name">The name of the product.</param>
        public Item(ItemCode code, string name)
            : this(Guid.NewGuid(), code, name)
        {}

        /// <summary>
        /// Construct.
        /// </summary>
        /// <param name="id">The id of the product.</param>
        /// <param name="code"></param>
        /// <param name="name">The name of the product.</param>
        public Item(Guid id, ItemCode code, string name)
            : base(id)
        {
            if(code == ItemCode.Empty) throw new ArgumentException("The Item Code must be set.  An empty code is not permissable",nameof(code));

            Code = code;
            ChangeName(name);
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
            if (description == null)
                throw new ArgumentNullException(nameof(description));

            Description = description;
        }

    }
}
