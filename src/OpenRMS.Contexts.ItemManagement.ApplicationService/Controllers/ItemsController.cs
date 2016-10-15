using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OpenRMS.Contexts.ItemManagement.ApplicationService.CommandStack.Commands;
using OpenRMS.Contexts.ItemManagement.Domain.Interfaces;
using OpenRMS.Contexts.ItemManagement.Domain.Entities;
using OpenRMS.Shared.Kernel.Interfaces;
using OpenRMS.Contexts.ItemManagement.ApplicationService.Models;
using System.Linq;

namespace OpenRMS.Contexts.ItemManagement.Api.Controllers
{
    [Route("itemmanagement/[controller]")]
    public class ItemsController : Controller
    {
        private IItemRepository _itemRepository;
        private ICommandHandler<CreateItemCommand, Item> _createItemHandler;
        private ICommandHandler<UpdateItemCommand> _updateItemHandler;
        private ICommandHandler<DeleteItemCommand> _deleteItemHandler;

        /// <summary>
        /// Construct.
        /// </summary>
        /// <param name="itemRepository">A repository of items.</param>
        /// <param name="createItemHandler">A handler of commands that create products.</param>
        /// <param name="updateItemHandler">A handler of commands that update products.</param>
        /// <param name="deleteItemHandler">A handler of commands that delete products.</param>
        public ItemsController(
            IItemRepository itemRepository,
            ICommandHandler<CreateItemCommand, Item> createItemHandler,
            ICommandHandler<UpdateItemCommand> updateItemHandler,
            ICommandHandler<DeleteItemCommand> deleteItemHandler)
        {
            _itemRepository = itemRepository;
            _createItemHandler = createItemHandler;
            _updateItemHandler = updateItemHandler;
            _deleteItemHandler = deleteItemHandler;
        }

        // GET items
        [HttpGet]
        public IEnumerable<GetItemModel> Get()
        {
            return _itemRepository.GetAll().Select(item => new GetItemModel()
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description
            });
        }

        // GET items/5
        [HttpGet("{id}")]
        public GetItemModel Get(Guid id)
        {
            var result = _itemRepository.GetForId(id);
            
            if (result.HasValue())
            {
                return new GetItemModel()
                {
                    Id = result.Value.Id,
                    Name = result.Value.Name,
                    Description = result.Value.Description
                };
            }

            return null;
        }

        // POST items
        [HttpPost]
        public Guid Post([FromBody]CreateItemModel model)
        {
            var command = new CreateItemCommand(model.Name, model.Description);
            var item = _createItemHandler.Execute(command);

            return item.Id;
        }

        // PUT items/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody]UpdateItemModel model)
        {
            var command = new UpdateItemCommand(id, model.Name, model.Description);
            _updateItemHandler.Execute(command);
        }

        // DELETE items/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            var command = new DeleteItemCommand(id);
            _deleteItemHandler.Execute(command);
        }
    }
}
