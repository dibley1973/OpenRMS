using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OpenRMS.Contexts.ItemManagement.ApplicationService.CommandStack.Commands;
using OpenRMS.Contexts.ItemManagement.ApplicationService.CommandStack.Handlers;
using OpenRMS.Contexts.ItemManagement.Domain.Entities;
using OpenRMS.Contexts.ItemManagement.Domain.Interfaces;
using OpenRMS.Shared.Kernel.Amplifiers;
using System;

namespace OpenRMS.Contexts.ItemManagement.ApplicationService.Tests.CommandStack.Handlers
{
    [TestClass]
    public class UpdateItemHandlerTests
    {
        private Mock<IItemManagementUnitOfWorkFactory> _unitOfWorkFactoryMock;
        private Mock<IItemManagementUnitOfWork> _unitOfWorkMock;
        private Mock<IItemRepository> _itemRepositoryMock;

        // This item will be returned by our mock repository and be updated. We can 
        // use this item to assert that the correct operations have been carried out by the
        // handler.
        private Item _testItemToBeUpdated = new Item(Guid.NewGuid(), "Test Item", "Test item description");

        [TestInitialize]
        public void TestInitialize()
        {
            _itemRepositoryMock = new Mock<IItemRepository>();
            _itemRepositoryMock.Setup(m => m.GetForId(It.IsAny<Guid>()))
                .Returns(new Maybe<Item>(_testItemToBeUpdated));

            _unitOfWorkMock = new Mock<IItemManagementUnitOfWork>();
            _unitOfWorkMock.SetupGet(m => m.ItemRepository).Returns(_itemRepositoryMock.Object);

            _unitOfWorkFactoryMock = new Mock<IItemManagementUnitOfWorkFactory>();
            _unitOfWorkFactoryMock.Setup(m => m.CreateUnitOfWork()).Returns(_unitOfWorkMock.Object);
        }

        // Should throw exception when command is null
        [TestMethod]
        public void HandlingTheCommand_ShouldThrowAnException_WhenTheCommandIsNull()
        {
            // ARRANGE
            var updateItemHandler = new UpdateItemHandler(_unitOfWorkFactoryMock.Object);

            // ACT
            Action action = () => updateItemHandler.Execute(null);

            // ASSERT
            action.ShouldThrow<ArgumentNullException>();
        }

        // Should create a unit of work
        [TestMethod]
        public void HandlingTheCommand_ShouldCreateAnUnitOfWork()
        {
            // ARRANGE
            var updateItemHandler = new UpdateItemHandler(_unitOfWorkFactoryMock.Object);
            var command = new UpdateItemCommand(Guid.NewGuid(), "Updated item name", "Updated item description");

            // ACT
            updateItemHandler.Execute(command);

            // ASSERT
            _unitOfWorkFactoryMock.Verify(factory => factory.CreateUnitOfWork(), Times.Once);
        }

        // Should throw exception when item cannot be found for the command id
        [TestMethod]
        public void HandlingTheCommand_ShouldThrowAnException_WhenAnItemCannotBeFoundForTheCommandId()
        {
            // ARRANGE
            _itemRepositoryMock.Setup(m => m.GetForId(It.IsAny<Guid>())).Returns(new Maybe<Item>());

            var updateItemHandler = new UpdateItemHandler(_unitOfWorkFactoryMock.Object);
            var command = new UpdateItemCommand(Guid.NewGuid(), "Updated item name", "Updated item description");

            // ACT
            Action action = () => updateItemHandler.Execute(command);

            // ASSERT
            action.ShouldThrow<InvalidOperationException>();
        }

        // Should change the name of the item
        [TestMethod]
        public void HandlingTheCommand_ShouldChangeTheNameOfTheItem()
        {
            // ARRANGE
            var updateItemHandler = new UpdateItemHandler(_unitOfWorkFactoryMock.Object);
            var command = new UpdateItemCommand(Guid.NewGuid(), "Updated item name", "Updated item description");

            // ACT
            updateItemHandler.Execute(command);

            // ASSERT
            _testItemToBeUpdated.Name.Should().Be(command.Name);
        }

        // Should change the description of the item
        [TestMethod]
        public void HandlingTheCommand_ShouldChangeTheDescriptionOfTheItem()
        {
            // ARRANGE
            var updateItemHandler = new UpdateItemHandler(_unitOfWorkFactoryMock.Object);
            var command = new UpdateItemCommand(Guid.NewGuid(), "Updated item name", "Updated item description");

            // ACT
            updateItemHandler.Execute(command);

            // ASSERT
            _testItemToBeUpdated.Description.Should().Be(command.Description);
        }

        // Should update the repository
        [TestMethod]
        public void HandlingTheCommand_ShouldUpdateTheRepository()
        {
            // ARRANGE
            var updateItemHandler = new UpdateItemHandler(_unitOfWorkFactoryMock.Object);
            var command = new UpdateItemCommand(Guid.NewGuid(), "Updated item name", "Updated item description");

            // ACT
            updateItemHandler.Execute(command);

            // ASSERT
            _itemRepositoryMock.Verify(repository => repository.Update(It.IsAny<Item>()), Times.Once);
        }

        // Should complete the unit of work
        [TestMethod]
        public void HandlingTheCommand_ShouldCompleteTheUnitOfWork()
        {
            // ARRANGE
            var updateItemHandler = new UpdateItemHandler(_unitOfWorkFactoryMock.Object);
            var command = new UpdateItemCommand(Guid.NewGuid(), "Updated item name", "Updated item description");

            // ACT
            updateItemHandler.Execute(command);

            // ASSERT
            _unitOfWorkMock.Verify(unitOfWork => unitOfWork.Complete(), Times.Once);
        }
    }
}
