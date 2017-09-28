//-----------------------------------------------------------------------
// <copyright file="IItemManagementUnitOfWork.cs" company="Chesil Media">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

namespace ORMS.Contexts.ItemManagement.Domain.Contracts
{
    using Shared.SharedKernel.Interfaces;

    /// <summary>
    /// An interface that provides access to a item management unit of work.
    /// </summary>
    public interface IItemManagementUnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Gets the item repository.
        /// </summary>
        /// <value>
        /// The item repository.
        /// </value>
        IItemRepository ItemRepository { get; }
    }
}