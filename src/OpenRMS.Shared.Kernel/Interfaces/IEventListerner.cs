using OpenRMS.Shared.Kernel.BaseClasses;

namespace OpenRMS.Shared.Kernel.Interfaces
{
    public interface IEventListerner<TAggregateRoot, TId>
        where TAggregateRoot : AggregateRoot<TId>
        where TId : struct
    {
        
    }
}