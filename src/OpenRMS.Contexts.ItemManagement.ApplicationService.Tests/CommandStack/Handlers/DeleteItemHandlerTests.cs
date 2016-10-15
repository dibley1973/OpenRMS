using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenRMS.Contexts.ItemManagement.ApplicationService.CommandStack.Commands;
using OpenRMS.Contexts.ItemManagement.ApplicationService.CommandStack.Handlers;
using OpenRMS.Contexts.ItemManagement.ApplicationService.Tests.Fakes;
using OpenRMS.Contexts.ItemManagement.Domain.Interfaces;

namespace OpenRMS.Contexts.ItemManagement.ApplicationService.Tests.CommandStack.Commands
{
    [TestClass]
    public class DeleteItemHandlerTests
    {
        //private IItemManagementUnitOfWorkFactory _unitOfWorkFactory;
        //private DeleteItemHandler _handler;

        //[TestInitialize]
        //public void TestInitialize()
        //{
        //    _unitOfWorkFactory = new Fakes.ItemManagementUnitOfWorkFactory();
        //    _handler = new DeleteItemHandler(_unitOfWorkFactory);
        //}

        //public void Test()
        //{
        //    // ARRANGE
        //    var id = FakeItems.Item3Id;
        //    DeleteItemCommand command = new DeleteItemCommand(id);

        //    // ACT
        //    _handler.Execute(command);
        //}
    }
}