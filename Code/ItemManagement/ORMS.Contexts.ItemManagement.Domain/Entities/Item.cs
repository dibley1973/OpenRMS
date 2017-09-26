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
    using Constants.ResultErrorKeys;
    using Shared.SharedKernel.Amplifiers;
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
        private Item(Name name, ShortDescription description)
            : base(Guid.NewGuid())
        {
            ChangeName(name);
            ChangeDescription(description);
            ChangeItemState(ItemState.Created);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Item" /> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="state">The state.</param>
        private Item(Guid id, Name name, ShortDescription description, ItemState state)
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
        /// Gets the state of this instance.
        /// </summary>
        /// <value>
        /// The state of this instance.
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
        /// If the specified arguments are valid, then creates a new instance of
        /// the <see cref="Item"/> and wraps it in a <see cref="Result{Item}"/>.
        /// Otherwise returns a fail <see cref="Result{Item}"/>.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <returns>Returns a <see cref="Result{Item}"/></returns>
        public static Result<Item> Create(Name name, ShortDescription description)
        {
            if (name == null) return Result.Fail<Item>(ItemErrorKeys.NameIsNull);
            if (description == null) return Result.Fail<Item>(ItemErrorKeys.DescriptionIsNull);

            return Result.Ok(new Item(name, description));
        }

        /// <summary>
        /// If the specified arguments are valid, then creates a new instance of
        /// the <see cref="Item"/> and wraps it in a <see cref="Result{Item}"/>.
        /// Otherwise returns a fail <see cref="Result{Item}"/>.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="state">The state.</param>
        /// <returns>Returns a <see cref="Result{Item}"/></returns>
        public static Result<Item> Create(Guid id, Name name, ShortDescription description, ItemState state)
        {
            if (id == Guid.Empty) return Result.Fail<Item>(ItemErrorKeys.IdIsNullOrEmpty);
            if (name == null) return Result.Fail<Item>(ItemErrorKeys.NameIsNull);
            if (description == null) return Result.Fail<Item>(ItemErrorKeys.DescriptionIsNull);
            if (state == null) return Result.Fail<Item>(ItemErrorKeys.ItemStateIsNull);

            return Result.Ok(new Item(id, name, description, state));
        }

        /// <summary>
        /// Changes the products code.
        /// </summary>
        /// <param name="code">The new code of the product.</param>
        public void ChangeCode(Code code)
        {
            Code = code ?? throw new ArgumentNullException(nameof(code));
        }

        /// <summary>
        /// Changes the state of this instance.
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
