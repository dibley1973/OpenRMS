using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenRMS.Shared.Kernel.BaseClasses
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }

        /// <summary>
        /// Construct.
        /// </summary>
        /// <param name="id">The id of the entity.</param>
        public Entity(Guid id)
        {
            if (id == null)
                throw new ArgumentNullException("id");

            Id = id;
        }
    }
}
