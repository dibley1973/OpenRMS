//-----------------------------------------------------------------------
// <copyright file="IItemRepository.cs" company="Chesil Media">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

namespace ORMS.Contexts.ItemManagement.Domain.Contracts
{
    using System;
    using Entities;
    using Shared.SharedKernel.Amplifiers;
    using Shared.SharedKernel.Interfaces;

    /// <summary>
    /// An interface that provides access to a repository of items.
    /// </summary>
    public interface IItemRepository : IRepository<Item, Guid>
    {
        /// <summary>
        /// Gets the <see cref="Item"/> wrapped in a <see cref="Maybe{Item}"/> for the supplied name.
        /// If no item was found then an empty <see cref="Maybe{Item}"/>.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>Returns a <see cref="Maybe{Item}"/></returns>
        Maybe<Item> GetForName(string name);
    }
}