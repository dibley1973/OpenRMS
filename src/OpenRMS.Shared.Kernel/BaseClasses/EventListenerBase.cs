namespace OpenRMS.Shared.Kernel.BaseClasses
{
    public abstract class EventListenerBase<TAggregateRoot, TId>
        where TAggregateRoot : AggregateRoot<TId>
        where TId : struct
    {
        protected  void DispatchEvents(TAggregateRoot aggregateRoot)
        {
            foreach (var domainEvent in aggregateRoot.DomainEvents)
            {
                DomainEvents.Dispatch(domainEvent);
            }

            aggregateRoot.ClearEvents();
        }
    }
}