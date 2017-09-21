//-----------------------------------------------------------------------
// <copyright file="IRepository{TEntity,TId}.cs" company="Chesil Media">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

namespace ORMS.Shared.SharedKernel.Interfaces
{
    using System.Collections.Generic;
    using Amplifiers;
    using BaseClasses;

    /// <summary>
    /// An interface that provides access to a repository of entities.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the entity's identifier.</typeparam>
    public interface IRepository<TEntity, in TId>
        where TEntity : Entity<TId>
        where TId : struct
    {
        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <returns>Returns a <see cref="IEnumerable{TEntity}" />/</returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Gets the  wrapped in a <see cref="Maybe{TEntity}" /> for the supplied id.
        /// If no item was found then an empty <see cref="Maybe{TEntity}" />.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Returns a <see cref="Maybe{TEntity}" />
        /// </returns>
        Maybe<TEntity> GetForId(TId id);

        /// <summary>
        /// Creates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Create(TEntity entity);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Update(TEntity entity);

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Delete(TEntity entity);
    }
}