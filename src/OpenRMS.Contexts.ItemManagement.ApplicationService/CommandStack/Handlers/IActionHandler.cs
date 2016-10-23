using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OpenRMS.Shared.Kernel.BaseClasses;

namespace OpenRMS.Contexts.ItemManagement.ApplicationService.CommandStack.Handlers
{
    /// <summary>
    /// An interface that provides access to a command handler.
    /// </summary>
    /// <typeparam name="TCommand">The type of command being handled.</typeparam>
    public interface IActionHandler<in TCommand>
        where TCommand : class
    {
        void Execute(TCommand command);
    }

    /// <summary>
    /// An interface that provides access to a command handler.
    /// </summary>
    /// <typeparam name="TCommand">The type of command being handled.</typeparam>
    /// <typeparam name="TResult">The type of result that the command produces.</typeparam>
    public interface IActionHandler<in TCommand, out TResult>
        where TCommand : class
    {
        TResult Execute(TCommand command, ControllerBase context);
    }

}
