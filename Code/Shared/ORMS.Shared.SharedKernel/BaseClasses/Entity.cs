//-----------------------------------------------------------------------
// <copyright file="Entity.cs" company="Chesil Media">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

namespace ORMS.Shared.SharedKernel.BaseClasses
{
    using System;

    /// <summary>
    /// The base class which all entities should inherit from
    /// </summary>
    /// <typeparam name="TId">
    /// Indicates the type of the entities identifier. Normally a Long or Guid
    /// </typeparam>
    public abstract class Entity<TId>
        where TId : struct
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Entity{TId}"/> class using the default parameterless contructor (Used only by ORM).
        /// </summary>
        protected Entity()
        {
            Id = default(TId);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Entity{TId}"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        protected Entity(TId id)
        {
            if (id.Equals(default(TId)))
            {
                throw new ArgumentNullException(nameof(id));
            }

            Id = id;
        }

        /// <summary>
        /// Gets the identity for the entity
        /// </summary>
        public TId Id { get; }

        /// <summary>
        /// Gets a value indicating whether this instance is persistent. TrPersistentansient indicates this
        /// instance can be persisted to a data store. This state is the opposite of
        /// <see cref="IsTransient"/>
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance is persistent; otherwise, <c>false</c>.
        /// </returns>
        public virtual bool IsPersistent => !IsTransient;

        /// <summary>
        /// Gets a value indicating whether this instance is transient.ransient indicates this
        /// instance cannot be persisted to a data store. This state is the opposite of
        /// <see cref="IsPersistent"/>
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is transient; otherwise, <c>false</c>.
        /// </value>
        public virtual bool IsTransient => Id.Equals(default(TId));

        /// <summary>
        /// Determines whether the first specified <see cref="Entity{TId}" />, is equal to the second <see cref="Entity{TId}" />.
        /// </summary>
        /// <param name="first">The first <see cref="Entity{TId}" />.</param>
        /// <param name="second">The second <see cref="Entity{TId}" />.</param>
        /// <returns>
        ///   <c>true</c> if the first specified <see cref="Entity{TId}" /> is equal to the second <see cref="Entity{TId}" />; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(Entity<TId> first, Entity<TId> second)
        {
            var firstIsNull = ReferenceEquals(first, null);
            var secondIsNull = ReferenceEquals(second, null);
            var bothAreNull = firstIsNull && secondIsNull;
            if (bothAreNull) return true;

            var onlyOneIsNull = firstIsNull || secondIsNull;
            if (onlyOneIsNull) return false;

            return first.Equals(second);
        }

        /// <summary>
        /// Determines whether the first specified <see cref="Entity{TId}" />, is equal to the second <see cref="Entity{TId}" />.
        /// </summary>
        /// <param name="first">The first <see cref="Entity{TId}" />.</param>
        /// <param name="second">The second <see cref="Entity{TId}" />.</param>
        /// <returns>
        ///   <c>true</c> if the first specified <see cref="Entity{TId}" /> is equal to the second <see cref="Entity{TId}" />; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(Entity<TId> first, Entity<TId> second)
        {
            return !(first == second);
        }

        /// <summary>
        /// Determines whether the specified <see cref="object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity<TId>;

            var compareToIsNull = ReferenceEquals(compareTo, null);
            if (compareToIsNull) return false;

            var compareToIsSameReference = ReferenceEquals(this, compareTo);
            if (compareToIsSameReference) return true;

            var compareToIsDifferentType = GetType() != compareTo.GetType();
            if (compareToIsDifferentType) return false;

            var bothArePersistent = IsPersistent && compareTo.IsPersistent;
            var bothIdentitiesMatch = Id.Equals(compareTo.Id);
            if (bothArePersistent && bothIdentitiesMatch) return true;

            return false;
        }

        /// <summary>
        /// Gets the hash code for this entity. This is based upon the type name and the <see cref="Id"/>.
        /// </summary>
        /// <returns>Returns the hash code for this entity</returns>
        public override int GetHashCode()
        {
            return (GetType().ToString() + Id).GetHashCode();
        }
    }
}
