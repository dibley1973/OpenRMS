using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OpenRMS.Contexts.LocationManagement.ApplicationService.CommandStack.Commands;
using OpenRMS.Contexts.LocationManagement.Domain.Interfaces;
using OpenRMS.Contexts.LocationManagement.Domain.Entities;
using OpenRMS.Shared.Kernel.Interfaces;
using OpenRMS.Contexts.LocationManagement.ApplicationService.Models;
using OpenRMS.Shared.Kernel.BaseClasses;

namespace OpenRMS.Contexts.LocationManagement.Api.Controllers
{
    [Route("locationmanagement/[controller]")]
    public class LocationsController : Controller
    {
        private ILocationRepository _locationRepository;
        private ICommandHandler<CreateLocationCommand, Location> _createLocationHandler;
        private ICommandHandler<UpdateLocationCommand> _updateLocationHandler;
        private ICommandHandler<DeleteLocationCommand> _deleteLocationHandler;

        /// <summary>
        /// Construct.
        /// </summary>
        /// <param name="locationRepository">A repository of locations.</param>
        /// <param name="createLocationHandler">A handler of commands that create products.</param>
        /// <param name="updateLocationHandler">A handler of commands that update products.</param>
        /// <param name="deleteLocationHandler">A handler of commands that delete products.</param>
        public LocationsController(
            ILocationRepository locationRepository,
            ICommandHandler<CreateLocationCommand, Location> createLocationHandler,
            ICommandHandler<UpdateLocationCommand> updateLocationHandler,
            ICommandHandler<DeleteLocationCommand> deleteLocationHandler)
        {
            _locationRepository = locationRepository;
            _createLocationHandler = createLocationHandler;
            _updateLocationHandler = updateLocationHandler;
            _deleteLocationHandler = deleteLocationHandler;
        }

        // GET locations
        [HttpGet]
        public IEnumerable<GetLocationModel> Get()
        {
            return _locationRepository.GetAll().Select(location => new GetLocationModel()
            {
                Id = location.Id,
                Name = location.Name,
                Description = location.Description
            });
        }

        // GET locations/5
        [HttpGet("{id}")]
        public GetLocationModel Get(Guid id)
        {
            var result = _locationRepository.GetForId(id);
            
            if (result.HasValue())
            {
                return new GetLocationModel()
                {
                    Id = result.Value.Id,
                    Name = result.Value.Name,
                    Description = result.Value.Description
                };
            }

            return null;
        }

        // POST locations
        [HttpPost]
        public Guid Post([FromBody]CreateLocationModel model)
        {
            var command = new CreateLocationCommand(new BusinessCode(model.Code), model.Name, model.Description);
            var location = _createLocationHandler.Execute(command);

            return location.Id;
        }

        // PUT locations/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody]UpdateLocationModel model)
        {
            var command = new UpdateLocationCommand(id, model.Name, model.Description);
            _updateLocationHandler.Execute(command);
        }

        // DELETE locations/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            var command = new DeleteLocationCommand(id);
            _deleteLocationHandler.Execute(command);
        }
    }
}
