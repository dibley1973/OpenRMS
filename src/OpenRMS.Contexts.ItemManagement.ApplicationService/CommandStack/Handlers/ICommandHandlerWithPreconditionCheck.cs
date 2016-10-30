using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using OpenRMS.Contexts.ItemManagement.Domain.Entities;
using OpenRMS.Shared.Kernel.BaseClasses;
using OpenRMS.Shared.Kernel.Interfaces;

namespace OpenRMS.Contexts.ItemManagement.ApplicationService.CommandStack.Handlers
{
    public interface ICommandHandlerWithPreconditionCheck<in TCommand>: ICommandHandler<TCommand> where TCommand: Command
    {
        PreconditionCheckResult PreconditionsMet(TCommand command);
    }

    public class PreconditionCheckResult
    {
        private readonly List<PreconditionFailure> _failures = new List<PreconditionFailure>();

        public IReadOnlyCollection<PreconditionFailure> Failures
        {
            get { return _failures.AsReadOnly(); }
        }

        public void AddFailure(PreconditionFailure failure)
        {
            _failures.Add(failure);
        }

        public void AddFailure(string propertyName, string failureMessage)
        {
            var  failure= new PreconditionFailure(propertyName,failureMessage);
            _failures.Add(failure);
        }

        public static implicit operator bool(PreconditionCheckResult preconditionCheckResult)
        {
            return !preconditionCheckResult.Failures.Any();
        }
    }

    public class PreconditionFailure
    {


        public PreconditionFailure(string property, string failureMessage)
        {
            if(string.IsNullOrWhiteSpace(property)) throw new ArgumentNullException(nameof(property));
            if (failureMessage == null) throw new ArgumentNullException(nameof(failureMessage));

            Property = property;
            FailureMessage = failureMessage;
        }

        public string Property { get; }
        public string FailureMessage { get; }

    }

    public static class PreconditionCheckResultsExtensions
    {
        public static ModelStateDictionary AsModelState (this IEnumerable<PreconditionFailure> instance)
        {
            var modelStateErrors = new ModelStateDictionary();
            foreach (var preconditionFailure in instance)
            {
                modelStateErrors.AddModelError(preconditionFailure.Property,preconditionFailure.FailureMessage);
            }

            return modelStateErrors;
        }
    }
}
