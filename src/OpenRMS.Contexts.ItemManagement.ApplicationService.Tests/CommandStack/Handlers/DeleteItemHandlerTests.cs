using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OpenRMS.Contexts.ItemManagement.ApplicationService.CommandStack.Handlers;
using OpenRMS.Contexts.ItemManagement.Domain.Entities;
using OpenRMS.Contexts.ItemManagement.Domain.Interfaces;
using OpenRMS.Shared.Kernel.Amplifiers;
using FluentAssertions;
using OpenRMS.Contexts.ItemManagement.ApplicationService.CommandStack.Commands;
using OpenRMS.Shared.Kernel.BaseClasses;

namespace OpenRMS.Contexts.ItemManagement.ApplicationService.Tests.CommandStack.Handlers
{
    [TestClass]
    public class DeleteItemHandlerTests
    {
        private Mock<IItemManagementUnitOfWorkFactory> _unitOfWorkFactoryMock;
        private Mock<IItemManagementUnitOfWork> _unitOfWorkMock;
        private Mock<IItemRepository> _itemRepositoryMock;

        // This item will be returned by our mock repository and be updated. We can 
        // use this item to assert that the correct operations have been carried out by the
        // handler.
        private readonly Guid _itemId;
        private readonly Item _testItemToBeUpdated;

        public DeleteItemHandlerTests()
        {
            _itemId = Guid.NewGuid();
            _testItemToBeUpdated = new Item(id: _itemId, code: new BusinessCode("t1"), name: "Test Item");
        }

        [TestInitialize]
        public void TestInitialize()
        {
            _itemRepositoryMock = new Mock<IItemRepository>();

            _itemRepositoryMock.Setup(m => m.GetForId(It.IsAny<Guid>()))
                .Returns(new Maybe<Item>());

            _itemRepositoryMock.Setup(m => m.GetForId(It.Is<Guid>(id => id == _itemId)))
                .Returns(new Maybe<Item>(_testItemToBeUpdated));

            _itemRepositoryMock.Setup(m => m.Delete(It.IsAny<Item>()));

            _unitOfWorkMock = new Mock<IItemManagementUnitOfWork>();
            _unitOfWorkMock.SetupGet(m => m.ItemRepository).Returns(_itemRepositoryMock.Object);

            _unitOfWorkFactoryMock = new Mock<IItemManagementUnitOfWorkFactory>();
            _unitOfWorkFactoryMock.Setup(m => m.CreateUnitOfWork()).Returns(_unitOfWorkMock.Object);
        }

        [TestMethod]
        public void HandlingTheCommand_ShouldThrowAnException_WhenTheCommandIsNull()
        {
            // ARRANGE
            var updateItemHandler = new DeleteItemHandler(_unitOfWorkFactoryMock.Object);

            // ACT
            Action action = () => updateItemHandler.Execute(null);

            // ASSERT
            action.ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        public void HandlingTheCommand_ShouldThrowAnException_WhenTheCommandHasInvalidItem()
        {
            // ARRANGE
            var updateItemHandler = new DeleteItemHandler(_unitOfWorkFactoryMock.Object);
            var command = new DeleteItemCommand(Guid.Empty);

            // ACT
            Action action = () => updateItemHandler.Execute(command);

            // ASSERT
            action.ShouldThrow<InvalidOperationException>();

        }

        [TestMethod]
        public void HandlingTheCommand_CallRepositoryRemove_WhenTheCommandHasValidItem()
        {
            // ARRANGE
            var updateItemHandler = new DeleteItemHandler(_unitOfWorkFactoryMock.Object);
            var command = new DeleteItemCommand(_testItemToBeUpdated.Id);

            // ACT
            updateItemHandler.Execute(command);

            // ASSERT
            _itemRepositoryMock.Verify(m => m.Delete(It.IsAny<Item>()), Times.Once);
        }
    }
}
