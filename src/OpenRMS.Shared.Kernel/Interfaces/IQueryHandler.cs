using OpenRMS.Shared.Kernel.BaseClasses;


namespace OpenRMS.Shared.Kernel.Interfaces
{
    public interface IQueryHandler<T, R> 
        where T : Query 
        where R : class
    {
        R Execute(T query);
    }
}
