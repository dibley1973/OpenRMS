//-----------------------------------------------------------------------
// <copyright file="ItemState.cs" company="Chesil Media">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

namespace ORMS.Contexts.ItemManagement.Domain.Entities
{
    using ORMS.Shared.SharedKernel.BaseClasses;

    /// <summary>
    /// Represents the state of an <see cref="Item"/>
    /// </summary>
    public class ItemState : Entity<int>
    {
        /// <summary>
        /// Creates an instance of an <see cref="ItemState"/> which represents the "created" state.
        /// </summary>
        public static readonly ItemState Created = new ItemState(1, "Created");

        /// <summary>
        /// Creates an instance of an <see cref="ItemState"/> which represents the "Active" state.
        /// </summary>
        public static readonly ItemState Active = new ItemState(2, "Active");

        /// <summary>
        /// Creates an instance of an <see cref="ItemState"/> which represents the "Deactivated" state.
        /// </summary>
        public static readonly ItemState Deactivated = new ItemState(3, "Deactivated");

        /// <summary>
        /// Creates an instance of an <see cref="ItemState"/> which represents the "Discontinued" state.
        /// </summary>
        public static readonly ItemState Discontinued = new ItemState(4, "Discontinued");

        private readonly string _name;

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemState"/> class.
        /// </summary>
        /// <param name="id">The identity of the state</param>
        /// <param name="name">The name of the state</param>
        private ItemState(int id, string name)
            : base(id)
        {
            _name = name;
        }

        /// <summary>
        /// Gets a value for the name
        /// </summary>
        public string Name => _name;
    }
}