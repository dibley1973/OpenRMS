using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OpenRMS.Contexts.ItemManagement.ApplicationService.CommandStack.Commands;
using OpenRMS.Contexts.ItemManagement.ApplicationService.CommandStack.Services;
using OpenRMS.Contexts.ItemManagement.Domain.Interfaces;
using OpenRMS.Contexts.ItemManagement.Domain.Entities;

namespace OpenRMS.Contexts.ItemManagement.Api.Controllers
{
    [Route("itemmanagement/[controller]")]
    public class ItemsController : Controller
    {
        // TODO: This controller accesses the repository directly - is this acceptable? If we are
        // following CQRS then no. If we're not then is this still correct?

        private IItemCommandService _itemCommandService;
        private IItemRepository _itemRepository;

        /// <summary>
        /// Construct.
        /// </summary>
        /// <param name="itemCommandService">A service that can execute item commands.</param>
        /// <param name="itemRepository">A repository of items.</param>
        public ItemsController(IItemCommandService itemCommandService, IItemRepository itemRepository)
        {
            _itemCommandService = itemCommandService;
            _itemRepository = itemRepository;
        }

        // GET items
        [HttpGet]
        public IEnumerable<Item> Get()
        {
            return _itemRepository.GetAll();
        }

        // GET items/5
        [HttpGet("{id}")]
        public Item Get(Guid id)
        {
            return _itemRepository.GetForId(id);
        }

        // POST items
        [HttpPost]
        public Guid Post([FromBody]CreateItemCommand model)
        {
            return _itemCommandService.CreateItem(model);
        }

        // PUT items/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody]UpdateItemCommand model)
        {
            _itemCommandService.UpdateItem(model);
        }

        // DELETE items/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            var command = new DeleteItemCommand(id);
            _itemCommandService.DeleteItem(command);
        }
    }
}
