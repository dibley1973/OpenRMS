using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OpenRMS.Contexts.ItemManagement.Api.Controllers;
using OpenRMS.Contexts.ItemManagement.ApplicationService.CommandStack.Commands;
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
    public class ItemsControllerTests
    {
        private Mock<ICommandHandler<CreateItemCommand, Item>> _createItemCommandHandlerMock;
        private Mock<ICommandHandler<UpdateItemCommand>> _updateItemCommandHandlerMock;
        private Mock<ICommandHandler<DeleteItemCommand>> _deleteItemCommandHandlerMock;
        private Mock<IItemRepository> _itemRepositoryMock;
        private ItemsController _controller;

        [TestInitialize]
        public void TestInitialize()
        {
            var testItemToCreate = new Item(Guid.NewGuid(), "Test item", "Test description");

            _createItemCommandHandlerMock = new Mock<ICommandHandler<CreateItemCommand, Item>>();
            _createItemCommandHandlerMock.Setup(m => m.Execute(It.IsAny<CreateItemCommand>())).Returns(testItemToCreate);

            _updateItemCommandHandlerMock = new Mock<ICommandHandler<UpdateItemCommand>>();

            _deleteItemCommandHandlerMock = new Mock<ICommandHandler<DeleteItemCommand>>();

            _itemRepositoryMock = new Mock<IItemRepository>();

            _controller = new ItemsController(
                _itemRepositoryMock.Object,
                _createItemCommandHandlerMock.Object, 
                _updateItemCommandHandlerMock.Object, 
                _deleteItemCommandHandlerMock.Object);
        }

        [TestMethod]
        public void Delete_ExecutesTheDeleteCommandHandler()
        {
            // ARRANGE            

            // ACT
            _controller.Delete(Guid.NewGuid());

            // ASSERT
            _deleteItemCommandHandlerMock.Verify(handler => handler.Execute(It.IsAny<DeleteItemCommand>()), Times.Once);
        }

        [TestMethod]
        public void Put_ExecutesTheUpdateCommandHandler()
        {
            // ARRANGE            
            var updateModel = new UpdateItemModel()
            {
                Name = "Updated Item",
                Description = "Updated item description"
            };

            // ACT
            _controller.Put(Guid.NewGuid(), updateModel);

            // ASSERT
            _updateItemCommandHandlerMock.Verify(handler => handler.Execute(It.IsAny<UpdateItemCommand>()), Times.Once);
        }

        [TestMethod]
        public void Post_ExecutesTheCreateCommandHandler()
        {
            // ARRANGE                        
            var createModel = new CreateItemModel()
            {
                Name = "Item name",
                Description = "Item description"
            };

            // ACT
            _controller.Post(createModel);

            // ASSERT
            _createItemCommandHandlerMock.Verify(handler => handler.Execute(It.IsAny<CreateItemCommand>()), Times.Once);
        }

        [TestMethod]
        public void Post_ReturnsTheIdOfTheCreatedItem()
        {
            // ARRANGE            
            var createdItem = new Item(Guid.NewGuid(), "Created item", "Created item description");
            _createItemCommandHandlerMock.Setup(m => m.Execute(It.IsAny<CreateItemCommand>())).Returns(createdItem);
            var createModel = new CreateItemModel()
            {
                Name = "Item name",
                Description = "Item description"
            };

            // ACT
            var createdItemId = _controller.Post(createModel);

            // ASSERT
            createdItemId.Should().Be(createdItem.Id);
        }

        [TestMethod]
        public void Get_ReturnsAllItemsInTheRepository()
        {
            // ARRANGE            
            var items = new List<Item>()
            {
                new Item(Guid.NewGuid(), "Item 1", "Item 1"),
                new Item(Guid.NewGuid(), "Item 2", "Item 2"),
                new Item(Guid.NewGuid(), "Item 3", "Item 3")
            };
            _itemRepositoryMock.Setup(m => m.GetAll()).Returns(items);

            // ACT
            var returnedItems = _controller.Get().ToList();

            // ASSERT
            returnedItems.Count.Should().Be(items.Count);
            foreach(GetItemModel returnedItem in returnedItems)
            {
                Assert.IsTrue(items.Any(item => item.Id == returnedItem.Id));
            }
        }

        [TestMethod]
        public void GetForId_ReturnsTheExpectedItemFromTheRepository()
        {
            // ARRANGE            
            var itemToFind = new Item(Guid.NewGuid(), "Item 2", "Item 2");     
            // DW: Resharper advised not used variable. JC to confirm if can be removed.
            //var items = new List<Item>()
            //{
            //    new Item(Guid.NewGuid(), "Item 1", "Item 1"),
            //    itemToFind,
            //    new Item(Guid.NewGuid(), "Item 3", "Item 3")
            //};
            _itemRepositoryMock.Setup(m => m.GetForId(It.IsAny<Guid>())).Returns(itemToFind);

            // ACT
            var returnedItem = _controller.Get(itemToFind.Id);

            // ASSERT
            returnedItem.Should().NotBe(null);
            returnedItem.Id.Should().Be(itemToFind.Id);
            returnedItem.Name.Should().Be(itemToFind.Name);
            returnedItem.Description.Should().Be(itemToFind.Description);
        }
    }
}
