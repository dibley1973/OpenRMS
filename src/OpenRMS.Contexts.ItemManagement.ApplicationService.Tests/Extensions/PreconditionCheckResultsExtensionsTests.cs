using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OpenRMS.Contexts.ItemManagement.Api.Controllers;
using OpenRMS.Contexts.ItemManagement.ApplicationService.Attributes;
using OpenRMS.Contexts.ItemManagement.ApplicationService.CommandStack.Commands;
using OpenRMS.Contexts.ItemManagement.ApplicationService.CommandStack.Handlers;
using OpenRMS.Contexts.ItemManagement.ApplicationService.Extensions;
using OpenRMS.Contexts.ItemManagement.ApplicationService.Models;
using OpenRMS.Contexts.ItemManagement.Domain.Entities;
using OpenRMS.Contexts.ItemManagement.Domain.Interfaces;
using OpenRMS.Shared.Kernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenRMS.Contexts.ItemManagement.ApplicationService.Tests.Controllers
{
    [TestClass]
    public class PreconditionCheckResultsExtensionsTests
    {
        public class TestModel
        {
            [MapToCommandProperty("CommandPropertyOne")]
            public string PropertyWithMappingAttribute { get; set; }

            [MapToCommandProperty("CommandPropertyTwo")]
            public string PropertyWithMappingAttribute_MultiMappingOne { get; set; }

            [MapToCommandProperty("CommandPropertyTwo")]
            public string PropertyWithMappingAttribute_MultiMappingTwo { get; set; }
        }

        [TestInitialize]
        public void TestInitialize()
        {
        }

        [TestMethod]
        public void ModelStateErrors_ContainsKeyOfModelProperty_WhenSinglePropertyMappedViaAttribute()
        {
            // ARRANGE            
            IEnumerable<PreconditionFailure> failures = new List<PreconditionFailure>()
            {
                new PreconditionFailure("CommandPropertyOne", "Failure on command property one")
            };

            // ACT
            var modelStateErrors = failures.AsModelState<TestModel>();

            // ASSERT
            modelStateErrors.Count.Should().Be(1);
            modelStateErrors.Any(error => error.Key == nameof(TestModel.PropertyWithMappingAttribute)).Should().Be(true);
        }

        [TestMethod]
        public void ModelStateErrors_ContainsKeysOfModelProperties_WhenMultiplePropertiesMappedViaAttributes()
        {
            // ARRANGE            
            IEnumerable<PreconditionFailure> failures = new List<PreconditionFailure>()
            {
                new PreconditionFailure("CommandPropertyTwo", "Failure on command property two")
            };

            // ACT
            var modelStateErrors = failures.AsModelState<TestModel>();

            // ASSERT
            modelStateErrors.Count.Should().Be(2);
            modelStateErrors.Any(error => error.Key == nameof(TestModel.PropertyWithMappingAttribute_MultiMappingOne)).Should().Be(true);
            modelStateErrors.Any(error => error.Key == nameof(TestModel.PropertyWithMappingAttribute_MultiMappingTwo)).Should().Be(true);
        }

        [TestMethod]
        public void ModelStateErrors_ContainsKeyOfCommandProperty_WhenPropertyIsNotMappedOnTheModel()
        {
            // ARRANGE      
            var commandPropertyName = "PropertyNotMappedOnModel";
            IEnumerable<PreconditionFailure> failures = new List<PreconditionFailure>()
            {
                new PreconditionFailure(commandPropertyName, "Failure on a property that is not mapped in the model")
            };

            // ACT
            var modelStateErrors = failures.AsModelState<TestModel>();

            // ASSERT
            modelStateErrors.Count.Should().Be(1);
            modelStateErrors.Any(error => error.Key == commandPropertyName).Should().Be(true);
        }
    }
}