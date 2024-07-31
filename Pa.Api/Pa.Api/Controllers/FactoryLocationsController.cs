using Microsoft.AspNetCore.Mvc;
using Pa.Base.Response;
using Pa.Schema.Factory;
using MediatR;
using Pa.Business.Cqrs;
using Pa.Schema.FactoryLocation;


namespace Pa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactoryLocationsController : ControllerBase
    {
        private readonly IMediator mediator;
        public FactoryLocationsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET: api/FactoryLocations
        [HttpGet]
        public async Task<ApiResponse<List<FactoryLocationResponse>>> Get()
        {
            var operation = new GetAllFactoryLocationQuery();
            var result = await mediator.Send(operation);
            return result;
        }

        // GET: api/FactoryLocations/GetFilterByFactoryLocationName?factoryLocationName=string
        [HttpGet("GetFilterByFactoryLocationName")]
        public async Task<ApiResponse<List<FactoryLocationResponse>>> GetFilterByFactoryLocationName(string? factoryLocationName)
        {
            var operation = new GetFactoryLocationByParameterQuery(factoryLocationName);
            var result = await mediator.Send(operation);
            return result;
        }

        // GET: api/FactoryLocations/5
        [HttpGet("{factoryLocationId}")]
        public async Task<ApiResponse<FactoryLocationResponse>> Get(long factoryLocationId)
        {
            var operation = new GetFactoryLocationByIdQuery(factoryLocationId);
            var result = await mediator.Send(operation);
            return result;
        }

        // POST: api/FactoryLocations
        [HttpPost]
        public async Task<ApiResponse<FactoryLocationResponse>> Post([FromBody] FactoryLocationRequest entity)
        {
            if (!ModelState.IsValid)
            {
                var errorResponse = new ApiResponse<FactoryLocationResponse>(
                    null,
                    false,
                    "Validation errors occurred: " + ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList()
                    );
                return errorResponse;
            }
            var operation = new CreateFactoryLocationCommand(entity);
            var result = await mediator.Send(operation);
            return result;
        }

        // PUT: api/FactoryLocations/5
        [HttpPut("{factoryLocationId}")]
        public async Task<ApiResponse> Put(long factoryLocationId, [FromBody] FactoryLocationRequest entity)
        {
            if (!ModelState.IsValid)
            {
                var errorResponse = new ApiResponse<FactoryLocationResponse>(
                    null,
                    false,
                    "Validation errors occurred: " + ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList()
                    );
                return errorResponse;
            }
            var operation = new UpdateFactoryLocationCommand(factoryLocationId, entity);
            var result = await mediator.Send(operation);
            return result;
        }

        // DELETE: api/FactoryLocations/5
        [HttpDelete("{factoryLocationId}")]
        public async Task<ApiResponse> Delete(long factoryLocationId)
        {
            var operation = new DeleteFactoryLocationCommand(factoryLocationId);
            var result = await mediator.Send(operation);
            return result;
        }
    }
}