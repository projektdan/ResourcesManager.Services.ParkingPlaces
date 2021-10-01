using MediatR;
using Microsoft.AspNetCore.Mvc;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Cqrs.Requests.Resources;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Models.Dtos;
using ResourcesManager.Services.ParkingPlaces.Infrastructure.Models.Payloads;
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
        /// 
        /// </summary>
        /// <param name="unique_resource_identifier"></param>
        /// <returns></returns>
        /// <response code="200">Returns resource</response>
        [HttpGet("{unique_resource_identifier}")]
        public async Task<ActionResult<ResourceDto>> Get([FromRoute]string unique_resource_identifier)
        {
            var request = new GetResourceRequest(unique_resource_identifier);
            var result = await this.mediator.Send(request);

            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResourceDto>> Add([FromBody]AddResourcePayload payload)
        {
            var request = new AddResourceRequest(payload);
            var result = await this.mediator.Send(request);

            return Created($"resources/{result.Name}", result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unique_resource_identifier"></param>
        /// <returns></returns>
        [HttpDelete("{unique_resource_identifier}")]
        public async Task<IActionResult> Delete([FromRoute]string unique_resource_identifier)
        {
            var request = new RemoveResourceRequest(unique_resource_identifier);
            await this.mediator.Send(request);

            return NoContent();
        }
    }
}
