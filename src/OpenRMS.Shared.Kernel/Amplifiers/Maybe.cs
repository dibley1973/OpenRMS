using System;
using OpenRMS.Shared.Kernel.BaseClasses;

namespace OpenRMS.Shared.Kernel.Amplifiers
{
    //TODO : Discuss - Maybe is for use on objects, not just entities,  the fact that the internal implementation makes no use od this is a hint?!
    public class Maybe<TEntity>
        where TEntity : class
    {
        private readonly TEntity _entity;

        public Maybe()
        {
        }

        public Maybe(TEntity entity)
        {
            //if (entity == null)
            //    throw new ArgumentNullException(nameof(entity),
            //        "Consider using default constructor if passing null was intended");

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