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
    using Constants.ErrorKeys;
    using Helpers;
    using Shared.SharedKernel.Amplifiers;
    using Shared.SharedKernel.BaseClasses;
    using Shared.SharedKernel.CommonEntities;
    using Shared.SharedKernel.Contracts;

    /// <summary>
    /// Represents a product item.
    /// </summary>
    public class Item : AggregateRoot<Guid>
    {
        private readonly IStateChangeRuleSet<ItemState> _itemStateChangeRuleSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="Item"/> class, with
        /// the default implementation of the item state change rule set.
        /// </summary>
        /// <param name="id">The id of the aggregate root.</param>
        private Item(Guid id)
            : base(id)
        {
            _itemStateChangeRuleSet = new DefaultItemStateChangeRuleSet();
            SetInitialItemState(ItemState.Created);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Item"/> class.
        /// Sets the state to <see cref="Entities.ItemState.Created"/>.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        private Item(Name name, ShortDescription description)
            : this(Guid.NewGuid())
        {
            ChangeName(name);
            ChangeDescription(description);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Item" /> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="state">The state.</param>
        private Item(Guid id, Name name, ShortDescription description, ItemState state)
            : this(id)
        {
            ChangeName(name);
            ChangeDescription(description);
            SetInitialItemState(state);
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
        /// <param name="state">The newItemState.</param>
        /// <returns>Returns a <see cref="Result{Item}"/></returns>
        public static Result<Item> Create(Guid id, Name name, ShortDescription description, ItemState state)
        {
            if (id == Guid.Empty) return Result.Fail<Item>(ItemErrorKeys.IdIsDefaultOrEmpty);
            if (name == null) return Result.Fail<Item>(ItemErrorKeys.NameIsNull);
            if (description == null) return Result.Fail<Item>(ItemErrorKeys.DescriptionIsNull);
            if (state == null) return Result.Fail<Item>(ItemErrorKeys.ItemStateIsNull);

            return Result.Ok(new Item(id, name, description, state));
        }

        /// <summary>
        /// Determines whether the current item state for this instance
        /// can be changed to the new specofied state; or not.
        /// </summary>
        /// <param name="newItemState">New state of the item.</param>
        /// <returns>
        /// <c>true</c> if the current item state for this instance
        /// can change to the specified state; otherwise <c>false</c>.
        /// </returns>
        public bool CanChangeState(ItemState newItemState)
        {
            return _itemStateChangeRuleSet.CanChange(ItemState, newItemState);
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
        /// Changes the newItemState of this instance.
        /// </summary>
        /// <param name="newItemState">The newItemState.</param>
        /// <exception cref="ArgumentNullException">newItemState</exception>
        public void ChangeItemState(ItemState newItemState)
        {
            if (newItemState == null) throw new ArgumentNullException(nameof(newItemState));

            if (CanChangeState(newItemState))
            {
                ItemState = newItemState;
            }
            else
            {
                throw new InvalidOperationException(ItemErrorKeys.CannotChangeItemStateConsiderCallingCanChangeFirst);
            }
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

        /// <summary>
        /// Changes the item state but by-passes validity checks, so should
        /// only be used for initial setting only.
        /// </summary>
        /// <param name="newItemState">New state of the item.</param>
        /// <exception cref="ArgumentNullException">newItemState</exception>
        private void SetInitialItemState(ItemState newItemState)
        {
            ItemState = newItemState ?? throw new ArgumentNullException(nameof(newItemState));
        }
    }
}