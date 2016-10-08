using System;
using System.Collections;
using System.Collections.Generic;
using OpenRMS.Shared.Kernel.BaseClasses;

namespace OpenRMS.Shared.Kernel.Amplifiers
{
    public class Maybe<TEntity, TId> : IEnumerable<TEntity>
        where TEntity : Entity<TId>
        where TId : struct
    {
        private readonly TEntity _entity;

        public Maybe()
        {
        }

        public Maybe(TEntity entity)
        {
            _entity = entity;
        }

        public bool HasValue()
        {
            return _entity != null;
        }

        public TEntity Entity
        {
            get
            {
                if (HasValue()) return _entity;

                throw new InvalidOperationException("No Entity to return");
            }
        }

        public IEnumerator<TEntity> GetEnumerator()
        {
            if (_entity != null)
            {
                yield return _entity;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Casts an object of <see cref="TEntity"/> to an object of type <see cref="Maybe{TEntity, TId}"/>
        /// </summary>
        /// <param name="value">The <see cref="TEntity"/> to cast from</param>
        public static implicit operator Maybe<TEntity, TId>(TEntity value)
        {
            return new Maybe<TEntity, TId>(value);
        }

        /// <summary>
        /// Casts an object of type <see cref="Maybe{TEntity, TId}"/> to an object of type <see cref="TEntity"/>
        /// </summary>
        /// <param name="value">The <see cref="Maybe{TEntity, TId}"/> to cast from</param>
        public static implicit operator TEntity(Maybe<TEntity, TId> value)
        {
            return value.Entity;
        }

    }
}