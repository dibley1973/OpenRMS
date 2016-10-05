using OpenRMS.Shared.Kernel.BaseClasses;


namespace OpenRMS.Shared.Kernel.Interfaces
{
    /// <summary>
    /// An interface that provides access to a query handler.
    /// </summary>
    /// <typeparam name="TQuery">The type of query being handled.</typeparam>
    /// <typeparam name="TResult">The type of result returned by the query.</typeparam>
    public interface IQueryHandler<TQuery, TResult> 
        where TQuery : Query 
        where TResult : class
    {
        TResult Execute(TQuery query);
    }
}
