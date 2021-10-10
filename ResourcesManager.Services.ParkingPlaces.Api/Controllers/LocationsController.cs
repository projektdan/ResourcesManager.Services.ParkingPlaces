using MediatR;
using Microsoft.AspNetCore.Mvc;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Cqrs.Requests.Locations;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Models.Dtos;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Models.Payloads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourcesManager.Services.ParkingPlaces.Api.Controllers
{
    [Route("locations")]
    [ApiController]
    public class LocationsController : Controller
    {
        private readonly IMediator mediator;

        public LocationsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        
        /// <summary>
        /// Get location by name
        /// </summary>
        /// <param name="location_name"></param>
        /// <returns></returns>
        [HttpGet("{location_name}")]
        public async Task<ActionResult<LocationDto>> Get([FromRoute]string location_name)
        {
            var request = new GetLocationRequest(location_name);
            var result = await mediator.Send(request);

            return Ok(result);
        }

        /// <summary>
        /// Get all locations
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocationDto>>> GetAll()
        {
            var request = new GetAllLocationsRequest();
            var result = await mediator.Send(request);

            return Ok(result);
        }

        ///// <summary>
        ///// Get all locations by Resource
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet("find_by_resource/{unique_resource_identifier}")]
        //public async Task<ActionResult<IEnumerable<LocationDto>>> GetAllByResource([FromRoute]string unique_resource_identifier)
        //{
        //    var request = new 
        //    var result = await mediator.Send(request);

        //    return Ok(result);
        //}

        /// <summary>
        /// Add location
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<LocationDto>> Add([FromBody]AddLocationPayload payload)
        {
            var request = new AddLocationRequest(payload);
            var resulat = await mediator.Send(request);

            return Created($"locations/{resulat.Name}", resulat);
        }

        [HttpDelete("{location_name}")]
        public async Task<IActionResult> Delete([FromRoute] string location_name)
        {
            var request = new RemoveLocationRequest(location_name);
            await mediator.Send(request);

            return NoContent();
        }
    }
}
