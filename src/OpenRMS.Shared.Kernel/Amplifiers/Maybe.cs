using System;
using System.Collections;
using System.Collections.Generic;
using OpenRMS.Shared.Kernel.BaseClasses;
using OpenRMS.Shared.Kernel.Resources;

namespace OpenRMS.Shared.Kernel.Amplifiers
{
    /// <summary>
    /// An amplifier of the the specified <see cref="TEntity"/> which the programmer to specify
    /// that the <see cref="TEntity"/> may or may not be present.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the entity's identifier.</typeparam>
    /// <seealso cref="System.Collections.Generic.IEnumerable{TEntity}" />
    public class Maybe<TEntity, TId> : IEnumerable<TEntity>
        where TEntity : Entity<TId>
        where TId : struct
    {
        private readonly TEntity _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="Maybe{TEntity, TId}"/> class without an entity.
        /// </summary>
        public Maybe() { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Maybe{TEntity, TId}"/> class with an entity.
        /// </summary>
        /// <param name="entity">
        /// The entity to construct the instance with. If a null reference entity is provided as the 
        /// then the instance is treated as not having an entity;
        /// </param>
        public Maybe(TEntity entity)
        {
            _entity = entity;
        }

        /// <summary>
        /// Gets the entity if it exists .
        /// </summary>
        /// <value>
        /// The entity.
        /// </value>
        /// <exception cref="System.InvalidOperationException">
        /// Thrown if there is no entity to return.</exception>
        public TEntity Entity
        {
            get
            {
                if (HasValue()) return _entity;

                throw new InvalidOperationException(string.Format(ExceptionMessages.NoEntityToReturn, typeof(TEntity), nameof(HasValue)));
            }
        }

        /// <summary>
        /// Returns an enumerator that will yield the <see cref="TEntity"/> if one exists or nothing if it does not.
        /// </summary>
        /// <returns>
        /// An enumerator that can be used to yield the <see cref="TEntity"/> if it exists.
        /// </returns>
        public IEnumerator<TEntity> GetEnumerator()
        {
            if (HasValue())
            {
                yield return _entity;
            }
        }

        /// <summary>
        /// Returns an enumerator that will yield the <see cref="TEntity"/> if one exists.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator" /> object that can be used to will 
        /// yield the <see cref="TEntity"/> if one exists.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Determines whether this instance has value.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance has value; otherwise, <c>false</c>.
        /// </returns>
        public bool HasValue()
        {
            return _entity != null;
        }

        /// <summary>
        /// Casts an object of <see cref="TEntity"/> to an object of type <see cref="Maybe{TEntity, TId}"/>
        /// </summary>
        /// <param name="entity">The <see cref="TEntity"/> to cast from</param>
        public static implicit operator Maybe<TEntity, TId>(TEntity entity)
        {
            return new Maybe<TEntity, TId>(entity);
        }

        /// <summary>
        /// Casts an object of type <see cref="Maybe{TEntity, TId}"/> to an object of type <see cref="TEntity"/>
        /// </summary>
        /// <param name="maybe">The <see cref="Maybe{TEntity, TId}"/> to cast from</param>
        public static implicit operator TEntity(Maybe<TEntity, TId> maybe)
        {
            return maybe.HasValue() 
                ? maybe.Entity 
                : null;
        }
    }
}