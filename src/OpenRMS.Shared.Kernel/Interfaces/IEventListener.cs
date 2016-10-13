using OpenRMS.Shared.Kernel.BaseClasses;

namespace OpenRMS.Shared.Kernel.Interfaces
{
    public interface IEventListener<TAggregateRoot, TId>
        where TAggregateRoot : AggregateRoot<TId>
        where TId : struct
    {
        
    }
}