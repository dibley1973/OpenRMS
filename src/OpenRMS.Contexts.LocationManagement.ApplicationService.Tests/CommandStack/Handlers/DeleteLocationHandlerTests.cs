using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OpenRMS.Contexts.LocationManagement.ApplicationService.CommandStack.Handlers;
using OpenRMS.Contexts.LocationManagement.Domain.Entities;
using OpenRMS.Contexts.LocationManagement.Domain.Interfaces;
using OpenRMS.Shared.Kernel.Amplifiers;
using FluentAssertions;
using OpenRMS.Contexts.LocationManagement.ApplicationService.CommandStack.Commands;
using OpenRMS.Shared.Kernel.BaseClasses;

namespace OpenRMS.Contexts.LocationManagement.ApplicationService.Tests.CommandStack.Handlers
{
    [TestClass]
    public class DeleteLocationHandlerTests
    {
        private Mock<ILocationManagementUnitOfWorkFactory> _unitOfWorkFactoryMock;
        private Mock<ILocationManagementUnitOfWork> _unitOfWorkMock;
        private Mock<ILocationRepository> _locationRepositoryMock;

        // This location will be returned by our mock repository and be updated. We can 
        // use this location to assert that the correct operations have been carried out by the
        // handler.
        private readonly Guid _locationId;
        private readonly Location _testLocationToBeUpdated;

        public DeleteLocationHandlerTests()
        {
            _locationId = Guid.NewGuid();
            _testLocationToBeUpdated = new Location(id: _locationId, code: new BusinessCode("t1"), name: "Test Location");
        }

        [TestInitialize]
        public void TestInitialize()
        {
            _locationRepositoryMock = new Mock<ILocationRepository>();

            _locationRepositoryMock.Setup(m => m.GetForId(It.IsAny<Guid>()))
                .Returns(new Maybe<Location>());

            _locationRepositoryMock.Setup(m => m.GetForId(It.Is<Guid>(id => id == _locationId)))
                .Returns(new Maybe<Location>(_testLocationToBeUpdated));

            _locationRepositoryMock.Setup(m => m.Delete(It.IsAny<Location>()));

            _unitOfWorkMock = new Mock<ILocationManagementUnitOfWork>();
            _unitOfWorkMock.SetupGet(m => m.LocationRepository).Returns(_locationRepositoryMock.Object);

            _unitOfWorkFactoryMock = new Mock<ILocationManagementUnitOfWorkFactory>();
            _unitOfWorkFactoryMock.Setup(m => m.CreateUnitOfWork()).Returns(_unitOfWorkMock.Object);
        }

        [TestMethod]
        public void HandlingTheCommand_ShouldThrowAnException_WhenTheCommandIsNull()
        {
            // ARRANGE
            var updateLocationHandler = new DeleteLocationHandler(_unitOfWorkFactoryMock.Object);

            // ACT
            Action action = () => updateLocationHandler.Execute(null);

            // ASSERT
            action.ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        public void HandlingTheCommand_ShouldThrowAnException_WhenTheCommandHasInvalidLocation()
        {
            // ARRANGE
            var updateLocationHandler = new DeleteLocationHandler(_unitOfWorkFactoryMock.Object);
            var command = new DeleteLocationCommand(Guid.Empty);

            // ACT
            Action action = () => updateLocationHandler.Execute(command);

            // ASSERT
            action.ShouldThrow<InvalidOperationException>();

        }

        [TestMethod]
        public void HandlingTheCommand_CallRepositoryRemove_WhenTheCommandHasValidLocation()
        {
            // ARRANGE
            var updateLocationHandler = new DeleteLocationHandler(_unitOfWorkFactoryMock.Object);
            var command = new DeleteLocationCommand(_testLocationToBeUpdated.Id);

            // ACT
            updateLocationHandler.Execute(command);

            // ASSERT
            _locationRepositoryMock.Verify(m => m.Delete(It.IsAny<Location>()), Times.Once);
        }
    }
}
