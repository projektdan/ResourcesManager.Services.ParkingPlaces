using MediatR;
using Microsoft.AspNetCore.Mvc;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Cqrs.Requests.Resources;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Models.Dtos;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Models.Payloads;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResourcesManager.Services.ParkingPlaces.Api.Controllers
{
    [Route("resources")]
    [ApiController]
    public class ResourcesController : Controller
    {
        private readonly IMediator mediator;

        public ResourcesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Get resource
        /// </summary>
        /// <param name="unique_resource_identifier"></param>
        /// <returns></returns>
        /// <response code="200">Returns resource</response>
        /// <response code="204">Returns no content</response>
        /// <response code="400">Returns json object which contains error code and message</response>
        /// /// <response code="404">Returns when resource was not found</response>
        [HttpGet("{unique_resource_identifier}")]
        public async Task<ActionResult<ResourceDto>> Get([FromRoute] string unique_resource_identifier)
        {
            var request = new GetResourceRequest(unique_resource_identifier);
            var result = await this.mediator.Send(request);

            return Ok(result);
        }

        /// <summary>
        /// Get all resources
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Returns resource</response>
        /// <response code="204">Returns no content</response>
        /// <response code="400">Returns json object which contains error code and message</response>
        /// <response code="404">Returns when resource was not found</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResourceDto>>> GetAll()
        {
            var request = new GetAllResourcesRequest();
            var result = await mediator.Send(request);

            return Ok(result);
        }

        /// <summary>
        /// Add resource
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        /// <response code="201">Returns newly created resource</response>
        /// <response code="400">Returns json object which contains error code and message</response>
        /// <response code="404">Returns when resource was not found</response>
        [HttpPost]
        public async Task<ActionResult<ResourceDto>> Add([FromBody]AddResourcePayload payload)
        {
            var request = new AddResourceRequest(payload);
            var result = await this.mediator.Send(request);

            return Created($"resources/{result.UniqueResourceIdentifier}", result);
        }

        /// <summary>
        /// Delete a resource
        /// </summary>
        /// <param name="unique_resource_identifier"></param>
        /// <returns></returns>
        /// <response code="204">Returns no content</response>
        /// <response code="400">Returns json object which contains error code and message</response>
        /// <response code="404">Returns when resource was not found</response>
        [HttpDelete("{unique_resource_identifier}")]
        public async Task<IActionResult> Delete([FromRoute]string unique_resource_identifier)
        {
            var request = new RemoveResourceRequest(unique_resource_identifier);
            await this.mediator.Send(request);

            return NoContent();
        }

        [HttpPatch("{location_name}/resources/{uniqe_resource_identifier}/{resource_quantity}/register")]
        public async Task<IActionResult> RegisterResourceInLocation([FromRoute]string location_name, 
            [FromRoute]string uniqe_resource_identifier, [FromRoute]int resource_quantity)
        {
            var request = new RegisterResourceInLocationRequest(uniqe_resource_identifier, resource_quantity, location_name);
            await mediator.Send(request);

            return NoContent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="location_name"></param>
        /// <param name="uniqe_resource_identifier"></param>
        /// <returns></returns>
        [HttpDelete("{location_name}/resources/{uniqe_resource_identifier}/unregister")]
        public async Task<IActionResult> UnregisterResourceInLocation([FromRoute] string location_name,
            [FromRoute] string uniqe_resource_identifier)
        {
            var request = new UnregisterResourceInLocationRequest(location_name, uniqe_resource_identifier);
            await mediator.Send(request);

            return NoContent();
        }

        [HttpPatch("{location_name}/resources/{uniqe_resource_identifier}/{resource_quantity}/update")]
        public async Task<IActionResult> UpdateResourceInLocation([FromRoute] string location_name,
            [FromRoute] string uniqe_resource_identifier, [FromRoute] int resource_quantity)
        {
            var request = new UpdateResourceInLocationRequest(uniqe_resource_identifier, resource_quantity, location_name);
            await mediator.Send(request);

            return NoContent();
        }
    }
}
