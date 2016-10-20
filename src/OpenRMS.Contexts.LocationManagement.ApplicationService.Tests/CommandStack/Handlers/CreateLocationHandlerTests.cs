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
    public class CreateLocationHandlerTests
    {
        private Mock<ILocationManagementUnitOfWorkFactory> _unitOfWorkFactoryMock;
        private Mock<ILocationManagementUnitOfWork> _unitOfWorkMock;
        private Mock<ILocationRepository> _locationRepositoryMock;

        [TestInitialize]
        public void TestInitialize()
        {
            _locationRepositoryMock = new Mock<ILocationRepository>();

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
            var createLocationHandler = new CreateLocationHandler(_unitOfWorkFactoryMock.Object);

            // ACT
            Action action = () => createLocationHandler.Execute(null);

            // ASSERT
            action.ShouldThrow<ArgumentNullException>();
        }

        // Should create a unit of work
        [TestMethod]
        public void HandlingTheCommand_ShouldCreateAnUnitOfWork()
        {
            // ARRANGE
            var createLocationHandler = new CreateLocationHandler(_unitOfWorkFactoryMock.Object);
            var command = new CreateLocationCommand(new BusinessCode("1"), "New location name", "New location description");

            // ACT
            createLocationHandler.Execute(command);

            // ASSERT
            _unitOfWorkFactoryMock.Verify(factory => factory.CreateUnitOfWork(), Times.Once);
        }

        [TestMethod]
        public void HandlingTheCommand_ShouldCreateLocationWithANewId()
        {
            // ARRANGE
            var createLocationHandler = new CreateLocationHandler(_unitOfWorkFactoryMock.Object);
            var command = new CreateLocationCommand(new BusinessCode("1"), "New location name", "New location description");
            Location actualLocation = null;
            _locationRepositoryMock.Setup(repository => repository.Create(It.IsAny<Location>()))
                .Callback((Location location) => actualLocation = location);

            // ACT
            createLocationHandler.Execute(command);

            // ASSERT
            actualLocation.Id.Should().NotBeEmpty();
        }

        // Should change the name of the location
        [TestMethod]
        public void HandlingTheCommand_ShouldCreateLocationWithPropertiesSet()
        {
            // ARRANGE
            var createLocationHandler = new CreateLocationHandler(_unitOfWorkFactoryMock.Object);
            var command = new CreateLocationCommand(new BusinessCode("1"), "New location with name", "New location with description");
            Location actualLocation = null;
            _locationRepositoryMock.Setup(repository => repository.Create(It.IsAny<Location>()))
                .Callback((Location location) => actualLocation = location);

            // ACT
            createLocationHandler.Execute(command);

            // ASSERT
            actualLocation.Code.Should().Be(command.Code);
            actualLocation.Name.Should().Be(command.Name);
            actualLocation.Description.Should().Be(command.Description);
        }

        [TestMethod]
        public void HandlingTheCommand_ShouldCreateLocationWithoutDescrition()
        {
            // ARRANGE
            var createLocationHandler = new CreateLocationHandler(_unitOfWorkFactoryMock.Object);
            var command = new CreateLocationCommand(new BusinessCode("1"), "New location with no description", "");
            Location actualLocation = null;
            _locationRepositoryMock.Setup(repository => repository.Create(It.IsAny<Location>()))
                .Callback((Location location) => actualLocation = location);

            // ACT
            createLocationHandler.Execute(command);

            // ASSERT
            actualLocation.Description.Should().BeEmpty();
            actualLocation.Code.Should().Be(command.Code);
            actualLocation.Name.Should().Be(command.Name);
            
        }

        // Should update the repository
        [TestMethod]
        public void HandlingTheCommand_ShouldAddToTheRepository()
        {
            // ARRANGE
            var createLocationHandler = new CreateLocationHandler(_unitOfWorkFactoryMock.Object);
            var command = new CreateLocationCommand("1", "Updated location name", "Updated location description");

            // ACT
            createLocationHandler.Execute(command);

            // ASSERT
            _locationRepositoryMock.Verify(repository => repository.Create(It.IsAny<Location>()), Times.Once);
        }

        // Should complete the unit of work
        [TestMethod]
        public void HandlingTheCommand_ShouldCompleteTheUnitOfWork()
        {
            // ARRANGE
            var createLocationHandler = new CreateLocationHandler(_unitOfWorkFactoryMock.Object);
            var command = new CreateLocationCommand("1", "Updated location name", "Updated location description");

            // ACT
            createLocationHandler.Execute(command);

            // ASSERT
            _unitOfWorkMock.Verify(unitOfWork => unitOfWork.Complete(), Times.Once);
        }
    }
}
