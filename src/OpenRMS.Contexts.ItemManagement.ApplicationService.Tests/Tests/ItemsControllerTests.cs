using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenRMS.Contexts.ItemManagement.ApplicationService.CommandStack.Services;
using OpenRMS.Contexts.ItemManagement.Domain.Interfaces;
using OpenRMS.Contexts.ItemManagement.ApplicationService.Tests.Fakes;
namespace OpenRMS.Contexts.ItemManagement.ApplicationService.Tests
{
    [TestClass]
    public class ItemsControllerTests
    {
        private IItemCommandService _fakeItemCommandService;
        private IItemRepository _fakeItemRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            _fakeItemCommandService = new FakeItemCommandService();
            _fakeItemRepository = new FakeItemRepository();
        }
    }
}
