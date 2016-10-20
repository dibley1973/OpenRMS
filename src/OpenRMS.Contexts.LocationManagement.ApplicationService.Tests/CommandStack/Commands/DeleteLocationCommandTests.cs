using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenRMS.Contexts.LocationManagement.ApplicationService.CommandStack.Commands;
using FluentAssertions;

namespace OpenRMS.Contexts.LocationManagement.ApplicationService.Tests.CommandStack.Commands
{
    [TestClass]
    public class DeleteLocationCommandTests
    {
        [TestMethod]
        public void Id_AfterClassInstantiation_ReturnsCorrectValue()
        {
            // ARRANGE
            var id = Guid.NewGuid();

            // ACT
            var command = new DeleteLocationCommand(id);

            // ASSERT
            command.Id.Should().Be(id);
        }
    }
}
