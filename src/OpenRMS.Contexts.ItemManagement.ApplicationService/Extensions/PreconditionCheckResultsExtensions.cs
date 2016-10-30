using Microsoft.AspNetCore.Mvc.ModelBinding;
using OpenRMS.Contexts.ItemManagement.ApplicationService.Attributes;
using OpenRMS.Contexts.ItemManagement.ApplicationService.CommandStack.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace OpenRMS.Contexts.ItemManagement.ApplicationService.Extensions
{
    public static class PreconditionCheckResultsExtensions
    {
        public static ModelStateDictionary AsModelState<TModel>(this IEnumerable<PreconditionFailure> instance) where TModel : class
        {
            var modelStateErrors = new ModelStateDictionary();

            // Get pi of the model
            IList<PropertyInfo> modelPropertyInfo = new List<PropertyInfo>(typeof(TModel).GetProperties());

            foreach (var preconditionFailure in instance)
            {
                // Look for attributes of the model that define a mapping between command and model properties
                var attributedModelProperties = modelPropertyInfo
                    .Where(property => 
                        property.GetCustomAttributes()
                            .Any(attribute => attribute is MapToCommandPropertyAttribute
                                && ((MapToCommandPropertyAttribute)attribute).PropertyName.Equals(preconditionFailure.Property, StringComparison.OrdinalIgnoreCase)));

                if (attributedModelProperties.Any())
                {
                    // Add a model state error for each model property that is mapped to the command property
                    foreach (var modelProperty in attributedModelProperties)
                    {
                        modelStateErrors.AddModelError(modelProperty.Name, preconditionFailure.FailureMessage);
                    }
                }
                else
                { 
                    modelStateErrors.AddModelError(preconditionFailure.Property, preconditionFailure.FailureMessage);
                }
            }

            return modelStateErrors;
        }
    }
}
