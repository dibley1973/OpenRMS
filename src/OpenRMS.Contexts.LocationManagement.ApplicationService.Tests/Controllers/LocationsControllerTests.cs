using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OpenRMS.Contexts.LocationManagement.Api.Controllers;
using OpenRMS.Contexts.LocationManagement.ApplicationService.CommandStack.Commands;
using OpenRMS.Contexts.LocationManagement.ApplicationService.Models;
using OpenRMS.Contexts.LocationManagement.Domain.Entities;
using OpenRMS.Contexts.LocationManagement.Domain.Interfaces;
using OpenRMS.Shared.Kernel.BaseClasses;
using OpenRMS.Shared.Kernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenRMS.Contexts.LocationManagement.ApplicationService.Tests.Controllers
{
    [TestClass]
    public class LocationsControllerTests
    {
        private Mock<ICommandHandler<CreateLocationCommand, Location>> _createLocationCommandHandlerMock;
        private Mock<ICommandHandler<UpdateLocationCommand>> _updateLocationCommandHandlerMock;
        private Mock<ICommandHandler<DeleteLocationCommand>> _deleteLocationCommandHandlerMock;
        private Mock<ILocationRepository> _locationRepositoryMock;
        private LocationsController _controller;

        [TestInitialize]
        public void TestInitialize()
        {
            var testLocationToCreate = new Location(new BusinessCode("1"), "Test location");
            testLocationToCreate.ChangeDescription("Test description");

            _createLocationCommandHandlerMock = new Mock<ICommandHandler<CreateLocationCommand, Location>>();
            _createLocationCommandHandlerMock.Setup(m => m.Execute(It.IsAny<CreateLocationCommand>())).Returns(testLocationToCreate);

            _updateLocationCommandHandlerMock = new Mock<ICommandHandler<UpdateLocationCommand>>();

            _deleteLocationCommandHandlerMock = new Mock<ICommandHandler<DeleteLocationCommand>>();

            _locationRepositoryMock = new Mock<ILocationRepository>();

            _controller = new LocationsController(
                _locationRepositoryMock.Object,
                _createLocationCommandHandlerMock.Object, 
                _updateLocationCommandHandlerMock.Object, 
                _deleteLocationCommandHandlerMock.Object);
        }

        [TestMethod]
        public void Delete_ExecutesTheDeleteCommandHandler()
        {
            // ARRANGE            

            // ACT
            _controller.Delete(Guid.NewGuid());

            // ASSERT
            _deleteLocationCommandHandlerMock.Verify(handler => handler.Execute(It.IsAny<DeleteLocationCommand>()), Times.Once);
        }

        [TestMethod]
        public void Put_ExecutesTheUpdateCommandHandler()
        {
            // ARRANGE            
            var updateModel = new UpdateLocationModel()
            {
                Name = "Updated Location",
                Description = "Updated location description"
            };

            // ACT
            _controller.Put(Guid.NewGuid(), updateModel);

            // ASSERT
            _updateLocationCommandHandlerMock.Verify(handler => handler.Execute(It.IsAny<UpdateLocationCommand>()), Times.Once);
        }

        [TestMethod]
        public void Post_ExecutesTheCreateCommandHandler()
        {
            // ARRANGE                        
            var createModel = new CreateLocationModel()
            {
                Code="1",
                Name = "Location name",
                Description = "Location description"
            };

            // ACT
            _controller.Post(createModel);

            // ASSERT
            _createLocationCommandHandlerMock.Verify(handler => handler.Execute(It.IsAny<CreateLocationCommand>()), Times.Once);
        }

        [TestMethod]
        public void Post_ReturnsTheIdOfTheCreatedLocation()
        {
            // ARRANGE            
            var createdLocation = new Location(new BusinessCode("1"), "Created location");

            _createLocationCommandHandlerMock.Setup(m => m.Execute(It.IsAny<CreateLocationCommand>())).Returns(createdLocation);
            var createModel = new CreateLocationModel()
            {
                Code="1",
                Name = "Location name",
                Description = "Location description"
            };

            // ACT
            var createdLocationId = _controller.Post(createModel);

            // ASSERT
            createdLocationId.Should().Be(createdLocation.Id);
        }

        [TestMethod]
        public void Get_ReturnsAllLocationsInTheRepository()
        {
            // ARRANGE            
            var locations = new List<Location>()
            {
                new Location(new BusinessCode("1"), "Location 1"),
                new Location(new BusinessCode("2"), "Location 2"),
                new Location(new BusinessCode("3"), "Location 3")
            };
            _locationRepositoryMock.Setup(m => m.GetAll()).Returns(locations);

            // ACT
            var returnedLocations = _controller.Get().ToList();

            // ASSERT
            returnedLocations.Count.Should().Be(locations.Count);
            foreach(GetLocationModel returnedLocation in returnedLocations)
            {
                Assert.IsTrue(locations.Any(location => location.Id == returnedLocation.Id));
            }
        }

        [TestMethod]
        public void GetForId_ReturnsTheExpectedLocationFromTheRepository()
        {
            // ARRANGE            
            var locationToFind = new Location(new BusinessCode("2"),  "Location 2");     
            _locationRepositoryMock.Setup(m => m.GetForId(It.IsAny<Guid>())).Returns(locationToFind);

            // ACT
            var returnedLocation = _controller.Get(locationToFind.Id);

            // ASSERT
            returnedLocation.Should().NotBe(null);
            returnedLocation.Id.Should().Be(locationToFind.Id);
            returnedLocation.Name.Should().Be(locationToFind.Name);
            returnedLocation.Description.Should().Be(locationToFind.Description);
        }
    }
}
