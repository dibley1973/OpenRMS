using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenRMS.Contexts.ItemManagement.ApplicationService.CommandStack.Commands;

namespace OpenRMS.Contexts.ItemManagement.ApplicationService.Tests.CommandStack.Commands
{
    [TestClass]
    public class DeleteItemCommandTests
    {
        [TestMethod]
        public void Id_AfterClassInstantiation_ReturnsCorrectValue()
        {
            // ARRANGE
            var id = Guid.NewGuid();

            // ACT
            var command = new DeleteItemCommand(id);

            // ASSERT
            command.Id.Should().Be(id);
        }
    }
}