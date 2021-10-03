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
    }
}
