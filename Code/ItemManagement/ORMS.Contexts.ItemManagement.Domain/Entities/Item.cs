//-----------------------------------------------------------------------
// <copyright file="Item.cs" company="Chesil Media">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

namespace ORMS.Contexts.ItemManagement.Domain.Entities
{
    using System;
    using Shared.SharedKernel.BaseClasses;
    using Shared.SharedKernel.CommonEntities;

    /// <summary>
    /// Represents a product item.
    /// </summary>
    public class Item : AggregateRoot<Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Item"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        public Item(Name name, ShortDescription description)
            : base(Guid.NewGuid())
        {
            ChangeName(name);
            ChangeDescription(description);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Item"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        public Item(Guid id, Name name, ShortDescription description)
            : this(id, name, description, ItemState.Created)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Item" /> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="state">The state.</param>
        public Item(Guid id, Name name, ShortDescription description, ItemState state)
            : base(id)
        {
            ChangeName(name);
            ChangeDescription(description);
            ChangeItemState(state);
        }

        /// <summary>
        /// Gets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        public Code Code { get; private set; }

        /// <summary>
        /// Gets the state of the item.
        /// </summary>
        /// <value>
        /// The state of the item.
        /// </value>
        public ItemState ItemState { get; private set; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public Name Name { get; private set; }

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public ShortDescription Description { get; private set; }

        /// <summary>
        /// Changes the products code.
        /// </summary>
        /// <param name="code">The new code of the product.</param>
        public void ChangeCode(Code code)
        {
            Code = code ?? throw new ArgumentNullException(nameof(code));
        }

        /// <summary>
        /// Changes the state of the item.
        /// </summary>
        /// <param name="state">The state.</param>
        /// <exception cref="ArgumentNullException">state</exception>
        public void ChangeItemState(ItemState state)
        {
            ItemState = state ?? throw new ArgumentNullException(nameof(state));
        }

        /// <summary>
        /// Changes the products name.
        /// </summary>
        /// <param name="name">The new name of the product.</param>
        public void ChangeName(Name name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        /// <summary>
        /// Changes the products description.
        /// </summary>
        /// <param name="description">The new description of the product.</param>
        public void ChangeDescription(ShortDescription description)
        {
            Description = description ?? throw new ArgumentNullException(nameof(description));
        }
    }
}
