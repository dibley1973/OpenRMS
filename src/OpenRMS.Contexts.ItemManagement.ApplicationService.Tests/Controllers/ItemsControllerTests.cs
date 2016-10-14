using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenRMS.Contexts.ItemManagement.Domain.Interfaces;
using OpenRMS.Contexts.ItemManagement.ApplicationService.Tests.Fakes;
using OpenRMS.Contexts.ItemManagement.Api.Controllers;
using System.Linq;
using FluentAssertions;
using OpenRMS.Contexts.ItemManagement.ApplicationService.CommandStack.Commands;
using OpenRMS.Shared.Kernel.Interfaces;
using OpenRMS.Contexts.ItemManagement.Domain.Entities;

namespace OpenRMS.Contexts.ItemManagement.ApplicationService.Tests
{
    [TestClass]
    public class ItemsControllerTests
    {
        private ICommandHandler<CreateItemCommand, Item> _fakeCreateItemHandler;
        private ICommandHandler<UpdateItemCommand> _fakeUpdateItemHandler;
        private ICommandHandler<DeleteItemCommand> _fakeDeleteItemHandler;
        private IItemRepository _fakeItemRepository;
        private ItemsController _controller;

        [TestInitialize]
        public void TestInitialize()
        {
            _fakeCreateItemHandler = new FakeCreateItemCommandHandler();
            _fakeUpdateItemHandler = new FakeUpdateItemCommandHandler();
            _fakeDeleteItemHandler = new FakeDeleteItemCommandHandler();
            _fakeItemRepository = new FakeItemRepository();

            _controller = new ItemsController(
                _fakeItemRepository, _fakeCreateItemHandler, _fakeUpdateItemHandler, _fakeDeleteItemHandler);
        }

        [TestMethod]
        public void Delete_AFterCalling_CountOfItemsInRepositoryHasDecreasedByOne()
        {
            // ARRANGE
            var idToDelete = FakeItems.Item3Id;
            var countOfItemsBefore = _fakeItemRepository.GetAll().Count();

            // ACT
            _controller.Delete(idToDelete);
            var countOfItemsAfter = _fakeItemRepository.GetAll().Count();
            var actual = countOfItemsAfter == countOfItemsBefore - 1;

            // ASSERT
            actual.Should().BeTrue();
        }

        [TestMethod]
        public void Delete_AFterCalling_DeletedItemInRepositoryIsNotAvailable()
        {
            // ARRANGE
            var idToDelete = FakeItems.Item3Id;
            var existsBefore = _fakeItemRepository.GetForId(idToDelete);

            // ACT
            _controller.Delete(idToDelete);
            

            // ASSERT


        }
    }
}
