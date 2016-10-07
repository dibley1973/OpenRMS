using System;
using System.Collections.Generic;
using OpenRMS.Shared.Kernel.Interfaces;

namespace OpenRMS.Shared.Kernel.BaseClasses
{
    /// <summary>
    /// The base class which all aggregate roots should inherit from
    /// </summary>
    /// <typeparam name="TId">Indicates the type of the entities identifier. Normally a Long or Guid.</typeparam>
    public abstract class AggregateRoot<TId> : Entity<TId>
        where TId : struct
    {
        private readonly List<IDomainEvent> _domainEvents;
        public virtual IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents;

        /// <summary>
        /// Parameterless constructor.
        /// </summary>
        protected AggregateRoot() : base()
        {
            _domainEvents = new List<IDomainEvent>();
        }

        /// <summary>
        /// Construct.
        /// </summary>
        /// <param name="id">The id of the aggregate root.</param>
        public AggregateRoot(TId id) : base(id)
        {
            _domainEvents = new List<IDomainEvent>();
        }

        /// <summary>
        /// Adds a domain event to the list.
        /// </summary>
        /// <param name="newEvent">The event to add.</param>
        protected virtual void AddDomainEvent(IDomainEvent newEvent)
        {
            if (newEvent == null) throw new ArgumentNullException(nameof(newEvent));

            _domainEvents.Add(newEvent);
        }

        /// <summary>
        /// Clears the domain event collection.
        /// </summary>
        public virtual void ClearEvents()
        {
            _domainEvents.Clear();
        }
    }
}
