using OpenRMS.Shared.Kernel.BaseClasses;

namespace OpenRMS.Shared.Kernel.Interfaces
{
    /// <summary>
    /// An interface that provides access to a command handler.
    /// </summary>
    /// <typeparam name="TCommand">The type of command being handled.</typeparam>
    public interface ICommandHandler<in TCommand>
        where TCommand : Command
    {
        void Execute(TCommand command);
    }

    /// <summary>
    /// An interface that provides access to a command handler.
    /// </summary>
    /// <typeparam name="TCommand">The type of command being handled.</typeparam>
    /// <typeparam name="TResult">The type of result that the command produces.</typeparam>
    public interface ICommandHandler<in TCommand, out TResult>
        where TCommand : Command 
    {
        TResult Execute(TCommand command);
    }
}
