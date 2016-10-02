using System;
using OpenRMS.Shared.Kernel.BaseClasses;

namespace OpenRMS.Shared.Kernel.Amplifiers
{
    public class Maybe<TEntity, TId>
        where TEntity : Entity<TId>
        where TId : struct
    {
        private readonly TEntity _entity;

        public Maybe()
        {
        }

        public Maybe(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity),
                    "Consider using default constructor if passing null was intended");

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

    }
}