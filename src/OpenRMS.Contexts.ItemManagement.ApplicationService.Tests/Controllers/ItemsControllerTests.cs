using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenRMS.Contexts.ItemManagement.Api.Controllers;
using OpenRMS.Contexts.ItemManagement.ApplicationService.CommandStack.Commands;
using OpenRMS.Contexts.ItemManagement.ApplicationService.Tests.Fakes;
using OpenRMS.Contexts.ItemManagement.Domain.Entities;
using OpenRMS.Contexts.ItemManagement.Domain.Interfaces;
using OpenRMS.Shared.Kernel.Interfaces;

namespace OpenRMS.Contexts.ItemManagement.ApplicationService.Tests.Controllers
{
    [TestClass]
    public class ItemsControllerTests
    {
        private ICommandHandler<CreateItemCommand, Item> _fakeCreateItemHandler;
        private ICommandHandler<UpdateItemCommand> _fakeUpdateItemHandler;
        private FakeDeleteItemCommandHandler _fakeDeleteItemHandler;

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
        public void Delete_AfterCalling_HandlerExecuteCalled()
        {
            // ARRANGE
            var idToDelete = FakeItems.Item3Id;

            // ACT
            _controller.Delete(idToDelete);

            // ASSERT
            var actual = _fakeDeleteItemHandler.ExecuteCalled;
            actual.Should().BeTrue();
        }

        [TestMethod]
        public void Delete_AfterCalling_CorrectIdWasSupplied()
        {
            // ARRANGE
            var idToDelete = FakeItems.Item3Id;

            // ACT
            _controller.Delete(idToDelete);

            // ASSERT
            var actual = _fakeDeleteItemHandler.CommandSupplied.Id;
            actual.Should().Be(idToDelete);
        }
    }
}