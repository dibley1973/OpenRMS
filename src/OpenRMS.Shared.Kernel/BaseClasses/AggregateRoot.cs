using System;
using System.Collections.Generic;
using OpenRMS.Shared.Kernel.Interfaces;

namespace OpenRMS.Shared.Kernel.BaseClasses
{
    public class AggregateRoot<TId> : Entity<TId>
        where TId : struct
    {
        private readonly List<IDomainEvent> _domainEvents;
        public virtual IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents;

        public AggregateRoot(TId id) : base(id)
        {
            _domainEvents = new List<IDomainEvent>();
        }

        protected virtual void AddDomainEvent(IDomainEvent newEvent)
        {
            if (newEvent == null) throw new ArgumentNullException(nameof(newEvent));

            _domainEvents.Add(newEvent);
        }

        public virtual void ClearEvents()
        {
            _domainEvents.Clear();
        }

    }
}
