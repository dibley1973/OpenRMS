using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OpenRMS.Contexts.LocationManagement.ApplicationService.CommandStack.Commands;
using OpenRMS.Contexts.LocationManagement.ApplicationService.CommandStack.Handlers;
using OpenRMS.Contexts.LocationManagement.Domain.Entities;
using OpenRMS.Contexts.LocationManagement.Domain.Interfaces;
using OpenRMS.Shared.Kernel.Amplifiers;
using OpenRMS.Shared.Kernel.BaseClasses;
using System;

namespace OpenRMS.Contexts.LocationManagement.ApplicationService.Tests.CommandStack.Handlers
{
    [TestClass]
    public class UpdateLocationHandlerTests
    {
        private Mock<ILocationManagementUnitOfWorkFactory> _unitOfWorkFactoryMock;
        private Mock<ILocationManagementUnitOfWork> _unitOfWorkMock;
        private Mock<ILocationRepository> _locationRepositoryMock;

        // This location will be returned by our mock repository and be updated. We can 
        // use this location to assert that the correct operations have been carried out by the
        // handler.
        private Location _testLocationToBeUpdated = new Location(new BusinessCode("t1"), "Test Location");

        [TestInitialize]
        public void TestInitialize()
        {
            _locationRepositoryMock = new Mock<ILocationRepository>();
            _locationRepositoryMock.Setup(m => m.GetForId(It.IsAny<Guid>()))
                .Returns(new Maybe<Location>(_testLocationToBeUpdated));

            _unitOfWorkMock = new Mock<ILocationManagementUnitOfWork>();
            _unitOfWorkMock.SetupGet(m => m.LocationRepository).Returns(_locationRepositoryMock.Object);

            _unitOfWorkFactoryMock = new Mock<ILocationManagementUnitOfWorkFactory>();
            _unitOfWorkFactoryMock.Setup(m => m.CreateUnitOfWork()).Returns(_unitOfWorkMock.Object);
        }

        // Should throw exception when command is null
        [TestMethod]
        public void HandlingTheCommand_ShouldThrowAnException_WhenTheCommandIsNull()
        {
            // ARRANGE
            var updateLocationHandler = new UpdateLocationHandler(_unitOfWorkFactoryMock.Object);

            // ACT
            Action action = () => updateLocationHandler.Execute(null);

            // ASSERT
            action.ShouldThrow<ArgumentNullException>();
        }

        // Should create a unit of work
        [TestMethod]
        public void HandlingTheCommand_ShouldCreateAnUnitOfWork()
        {
            // ARRANGE
            var updateLocationHandler = new UpdateLocationHandler(_unitOfWorkFactoryMock.Object);
            var command = new UpdateLocationCommand(Guid.NewGuid(), "Updated location name", "Updated location description");

            // ACT
            updateLocationHandler.Execute(command);

            // ASSERT
            _unitOfWorkFactoryMock.Verify(factory => factory.CreateUnitOfWork(), Times.Once);
        }

        // Should throw exception when location cannot be found for the command id
        [TestMethod]
        public void HandlingTheCommand_ShouldThrowAnException_WhenAnLocationCannotBeFoundForTheCommandId()
        {
            // ARRANGE
            _locationRepositoryMock.Setup(m => m.GetForId(It.IsAny<Guid>())).Returns(new Maybe<Location>());

            var updateLocationHandler = new UpdateLocationHandler(_unitOfWorkFactoryMock.Object);
            var command = new UpdateLocationCommand(Guid.NewGuid(), "Updated location name", "Updated location description");

            // ACT
            Action action = () => updateLocationHandler.Execute(command);

            // ASSERT
            action.ShouldThrow<InvalidOperationException>();
        }

        // Should change the name of the location
        [TestMethod]
        public void HandlingTheCommand_ShouldChangeTheNameOfTheLocation()
        {
            // ARRANGE
            var updateLocationHandler = new UpdateLocationHandler(_unitOfWorkFactoryMock.Object);
            var command = new UpdateLocationCommand(Guid.NewGuid(), "Updated location name", "Updated location description");

            // ACT
            updateLocationHandler.Execute(command);

            // ASSERT
            _testLocationToBeUpdated.Name.Should().Be(command.Name);
        }

        // Should change the description of the location
        [TestMethod]
        public void HandlingTheCommand_ShouldChangeTheDescriptionOfTheLocation()
        {
            // ARRANGE
            var updateLocationHandler = new UpdateLocationHandler(_unitOfWorkFactoryMock.Object);
            var command = new UpdateLocationCommand(Guid.NewGuid(), "Updated location name", "Updated location description");

            // ACT
            updateLocationHandler.Execute(command);

            // ASSERT
            _testLocationToBeUpdated.Description.Should().Be(command.Description);
        }

        // Should update the repository
        [TestMethod]
        public void HandlingTheCommand_ShouldUpdateTheRepository()
        {
            // ARRANGE
            var updateLocationHandler = new UpdateLocationHandler(_unitOfWorkFactoryMock.Object);
            var command = new UpdateLocationCommand(Guid.NewGuid(), "Updated location name", "Updated location description");

            // ACT
            updateLocationHandler.Execute(command);

            // ASSERT
            _locationRepositoryMock.Verify(repository => repository.Update(It.IsAny<Location>()), Times.Once);
        }

        // Should complete the unit of work
        [TestMethod]
        public void HandlingTheCommand_ShouldCompleteTheUnitOfWork()
        {
            // ARRANGE
            var updateLocationHandler = new UpdateLocationHandler(_unitOfWorkFactoryMock.Object);
            var command = new UpdateLocationCommand(Guid.NewGuid(), "Updated location name", "Updated location description");

            // ACT
            updateLocationHandler.Execute(command);

            // ASSERT
            _unitOfWorkMock.Verify(unitOfWork => unitOfWork.Complete(), Times.Once);
        }
    }
}
