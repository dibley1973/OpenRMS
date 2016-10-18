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
    public class CreateItemHandlerTests
    {
        private Mock<IItemManagementUnitOfWorkFactory> _unitOfWorkFactoryMock;
        private Mock<IItemManagementUnitOfWork> _unitOfWorkMock;
        private Mock<IItemRepository> _itemRepositoryMock;

        [TestInitialize]
        public void TestInitialize()
        {
            _itemRepositoryMock = new Mock<IItemRepository>();

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
            var createItemHandler = new CreateItemHandler(_unitOfWorkFactoryMock.Object);

            // ACT
            Action action = () => createItemHandler.Execute(null);

            // ASSERT
            action.ShouldThrow<ArgumentNullException>();
        }

        // Should create a unit of work
        [TestMethod]
        public void HandlingTheCommand_ShouldCreateAnUnitOfWork()
        {
            // ARRANGE
            var createItemHandler = new CreateItemHandler(_unitOfWorkFactoryMock.Object);
            var command = new CreateItemCommand(new ItemCode("1"), "New item name", "New item description");

            // ACT
            createItemHandler.Execute(command);

            // ASSERT
            _unitOfWorkFactoryMock.Verify(factory => factory.CreateUnitOfWork(), Times.Once);
        }

        [TestMethod]
        public void HandlingTheCommand_ShouldCreateItemWithANewId()
        {
            // ARRANGE
            var createItemHandler = new CreateItemHandler(_unitOfWorkFactoryMock.Object);
            var command = new CreateItemCommand(new ItemCode("1"), "New item name", "New item description");
            Item actualItem = null;
            _itemRepositoryMock.Setup(repository => repository.Create(It.IsAny<Item>()))
                .Callback((Item item) => actualItem = item);

            // ACT
            createItemHandler.Execute(command);

            // ASSERT
            actualItem.Id.Should().NotBeEmpty();
        }

        // Should change the name of the item
        [TestMethod]
        public void HandlingTheCommand_ShouldCreateItemWithPropertiesSet()
        {
            // ARRANGE
            var createItemHandler = new CreateItemHandler(_unitOfWorkFactoryMock.Object);
            var command = new CreateItemCommand(new ItemCode("1"), "New item with name", "New item with description");
            Item actualItem = null;
            _itemRepositoryMock.Setup(repository => repository.Create(It.IsAny<Item>()))
                .Callback((Item item) => actualItem = item);

            // ACT
            createItemHandler.Execute(command);

            // ASSERT
            actualItem.Code.Should().Be(command.Code);
            actualItem.Name.Should().Be(command.Name);
            actualItem.Description.Should().Be(command.Description);
        }

        [TestMethod]
        public void HandlingTheCommand_ShouldCreateItemWithoutDescrition()
        {
            // ARRANGE
            var createItemHandler = new CreateItemHandler(_unitOfWorkFactoryMock.Object);
            var command = new CreateItemCommand(new ItemCode("1"), "New item with no description", "");
            Item actualItem = null;
            _itemRepositoryMock.Setup(repository => repository.Create(It.IsAny<Item>()))
                .Callback((Item item) => actualItem = item);

            // ACT
            createItemHandler.Execute(command);

            // ASSERT
            actualItem.Description.Should().BeEmpty();
            actualItem.Code.Should().Be(command.Code);
            actualItem.Name.Should().Be(command.Name);
            
        }

        // Should update the repository
        [TestMethod]
        public void HandlingTheCommand_ShouldAddToTheRepository()
        {
            // ARRANGE
            var createItemHandler = new CreateItemHandler(_unitOfWorkFactoryMock.Object);
            var command = new CreateItemCommand("1", "Updated item name", "Updated item description");

            // ACT
            createItemHandler.Execute(command);

            // ASSERT
            _itemRepositoryMock.Verify(repository => repository.Create(It.IsAny<Item>()), Times.Once);
        }

        // Should complete the unit of work
        [TestMethod]
        public void HandlingTheCommand_ShouldCompleteTheUnitOfWork()
        {
            // ARRANGE
            var createItemHandler = new CreateItemHandler(_unitOfWorkFactoryMock.Object);
            var command = new CreateItemCommand("1", "Updated item name", "Updated item description");

            // ACT
            createItemHandler.Execute(command);

            // ASSERT
            _unitOfWorkMock.Verify(unitOfWork => unitOfWork.Complete(), Times.Once);
        }
    }
}
