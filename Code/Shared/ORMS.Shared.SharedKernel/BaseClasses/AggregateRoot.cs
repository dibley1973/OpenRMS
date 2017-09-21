//-----------------------------------------------------------------------
// <copyright file="AggregateRoot.cs" company="Chesil Media">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

namespace ORMS.Shared.SharedKernel.BaseClasses
{
    /// <summary>
    /// The base class which all aggregate roots should inherit from
    /// </summary>
    /// <typeparam name="TId">Indicates the type of the entities identifier. Normally a Long or Guid.</typeparam>
    public abstract class AggregateRoot<TId> : Entity<TId>
        where TId : struct
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateRoot{TId}"/> class.
        /// </summary>
        /// <param name="id">The id of the aggregate root.</param>
        protected AggregateRoot(TId id)
            : base(id)
        {
        }
    }
}