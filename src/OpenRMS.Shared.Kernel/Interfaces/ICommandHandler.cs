using OpenRMS.Shared.Kernel.BaseClasses;

namespace OpenRMS.Shared.Kernel.Interfaces
{
    public interface ICommandHandler<in TCommand, out TEntity> 
        where TCommand : Command 
        //where TEntity : Entity<TId>
        //where TId : struct
    {
        TEntity Execute(TCommand command);
    }
}
