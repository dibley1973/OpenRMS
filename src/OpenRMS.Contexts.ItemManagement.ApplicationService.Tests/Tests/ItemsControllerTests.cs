using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenRMS.Contexts.ItemManagement.ApplicationService.CommandStack.Services;
using OpenRMS.Contexts.ItemManagement.Domain.Interfaces;
using OpenRMS.Contexts.ItemManagement.ApplicationService.Tests.Fakes;
using OpenRMS.Contexts.ItemManagement.Api.Controllers;
using System.Linq;
using FluentAssertions;

namespace OpenRMS.Contexts.ItemManagement.ApplicationService.Tests
{
    [TestClass]
    public class ItemsControllerTests
    {
        private IItemCommandService _fakeItemCommandService;
        private IItemRepository _fakeItemRepository;
        private ItemsController _controller;

        [TestInitialize]
        public void TestInitialize()
        {
            _fakeItemCommandService = new FakeItemCommandService();
            _fakeItemRepository = new FakeItemRepository();
            _controller = new ItemsController(_fakeItemCommandService, _fakeItemRepository);
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
