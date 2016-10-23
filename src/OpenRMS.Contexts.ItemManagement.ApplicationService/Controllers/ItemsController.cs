using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using OpenRMS.Contexts.ItemManagement.ApplicationService.CommandStack.Commands;
using OpenRMS.Contexts.ItemManagement.ApplicationService.CommandStack.Handlers;
using OpenRMS.Contexts.ItemManagement.Domain.Interfaces;
using OpenRMS.Contexts.ItemManagement.Domain.Entities;
using OpenRMS.Shared.Kernel.Interfaces;
using OpenRMS.Contexts.ItemManagement.ApplicationService.Models;

namespace OpenRMS.Contexts.ItemManagement.Api.Controllers
{
    [Route("itemmanagement/[controller]")]
    public class ItemsController : Controller
    {
        private IItemRepository _itemRepository;
        private ICommandHandler<CreateItemCommand, Item> _createItemHandler;
        private ICommandHandler<UpdateItemCommand> _updateItemHandler;
        private IActionHandler<UpdateItemModel, IActionResult> _updateItemHandlerV2;
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
            IActionHandler<UpdateItemModel, IActionResult> updateItemHandlerV2,
            ICommandHandler<DeleteItemCommand> deleteItemHandler)
        {
            _itemRepository = itemRepository;
            _createItemHandler = createItemHandler;
            _updateItemHandler = updateItemHandler;
            _updateItemHandlerV2 = updateItemHandlerV2;
            _deleteItemHandler = deleteItemHandler;
        }

        // GET items
        [HttpGet]
        public IEnumerable<GetItemModel> Get()
        {
            return _itemRepository.GetAll().Select(item => new GetItemModel()
            {
                Id = item.Id,
                Code = item.Code.Value,
                Name = item.Name,
                Description = item.Description
            });
        }

        // GET items/5
        [HttpGet("{id}", Name = "GetItem")]
        public IActionResult Get(Guid id)
        {
            var result = _itemRepository.GetForId(id);
            
            if (result.HasValue())
            {
                var retrievedItem = result.Value;
                return new ObjectResult(new GetItemModel()
                {
                    Id = retrievedItem.Id,
                    Code = retrievedItem.Code.Value,
                    Name = retrievedItem.Name,
                    Description = retrievedItem.Description
                });
            }

            return NotFound();
        }

        // POST items
        [HttpPost]
        public IActionResult Create([FromBody]CreateItemModel model)
        {
            if (model == null) return BadRequest();

            var command = new CreateItemCommand(new ItemCode(model.Code), model.Name, model.Description);
            var item = _createItemHandler.Execute(command);

            return CreatedAtRoute("GetItem", new {id = item.Id}, item);
        }

        //TODO: Decide V1 - Using command handler agnostic to service and web api
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody]UpdateItemModel model)
        {
            var command = new UpdateItemCommand(id, model.Name, model.Description);
            _updateItemHandler.Execute(command);
        }

        
        //TODO: Decide V2 - Using action handler, inherently tied to web api, uses model to cut out middleman and ensure model state errors reflect model properties
        [HttpPut("PutV2/{id}")]
        public IActionResult PutV2(Guid id, [FromBody]UpdateItemModel model)
        {
            return _updateItemHandlerV2.Execute(model, this);
        }

        //TODO: Decide V3 - Does the work directly in the body of the Action Method, forgoing commands and handlers with the downside of having chunky action methods
        [HttpPut("PutV3/{id}")]
        public IActionResult PutV3(Guid id, [FromBody]UpdateItemModel model)
        {
            if (model == null) return BadRequest();

            //var maybeItem = _unitOfWork.ItemRepository.GetForId(id);
            var maybeItem = _itemRepository.GetForId(id);

            if (!maybeItem.HasValue()) return NotFound();

            var item = maybeItem.Single();

            var canChangeName = item.CanChangeName(model.Name);
            var canChangeDescription = item.CanChangeDescription(model.Description);
            if (!canChangeName || !canChangeDescription)
            {
                ModelState.AddModelError(nameof(model.Name), canChangeName.ErrorMessage);
                ModelState.AddModelError(nameof(model.Description), canChangeDescription.ErrorMessage);
                return BadRequest(ModelState);
            }

            item.ChangeName(model.Name);
            item.ChangeDescription(model.Description);

            //_unitOfWork.Commit()

            return NoContent();

        }

        // DELETE items/5
        //TODO: Implement with IActionResult, returning NotFound() if doesn't exist, or NoContentResult() if all goes OK.
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            var command = new DeleteItemCommand(id);
            _deleteItemHandler.Execute(command);
        }
    }
}
