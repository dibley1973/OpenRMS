using System;
using System.Collections.Generic;
using OpenRMS.Shared.Kernel.Interfaces;

namespace OpenRMS.Shared.Kernel.BaseClasses
{
    /// <summary>
    /// The base class which all aggregate roots should inherit from
    /// </summary>
    public abstract class AggregateRoot : Entity
    {
        /// <summary>
        /// Parameterless constructor.
        /// </summary>
        protected AggregateRoot()
        {
        }

        /// <summary>
        /// Construct.
        /// </summary>
        /// <param name="id">The id of the aggregate root.</param>
        public AggregateRoot(Guid id) : base(id)
        {
        }
    }
}
