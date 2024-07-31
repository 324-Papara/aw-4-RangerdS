using Microsoft.AspNetCore.Mvc;
using Pa.Base.Response;
using Pa.Schema.Factory;
using MediatR;
using Pa.Business.Cqrs;


namespace Pa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactoriesController : ControllerBase
    {
        private readonly IMediator mediator;
        public FactoriesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET: api/Factories
        [HttpGet]
        public async Task<ApiResponse<List<FactoryResponse>>> Get()
        {
            var operation = new GetAllFactoryQuery();
            var result = await mediator.Send(operation);
            return result;
        }

        // GET: api/Factories/GetFilterByFactoryName?factoryName=string
        [HttpGet("GetFilterByFactoryName")]
        public async Task<ApiResponse<List<FactoryResponse>>> GetFilterByFactoryName(string? factoryName)
        {
            var operation = new GetFactoryByParameterQuery(null, factoryName, null);
            var result = await mediator.Send(operation);
            return result;
        }

        // GET: api/Factories/GetFilterByCapacity?capacity=135
        [HttpGet("GetFilterByCapacity")]
        public async Task<ApiResponse<List<FactoryResponse>>> GetFilterByCapacity(int? capacity)
        {
            var operation = new GetFactoryByParameterQuery(null, null, capacity);
            var result = await mediator.Send(operation);
            return result;
        }

        // GET: api/Factories/5
        [HttpGet("{factoryId}")]
        public async Task<ApiResponse<FactoryResponse>> Get(long factoryId)
        {
            var operation = new GetFactoryByIdQuery(factoryId);
            var result = await mediator.Send(operation);
            return result;
        }

        // POST: api/Factories
        [HttpPost]
        public async Task<ApiResponse<FactoryResponse>> Post([FromBody] FactoryRequest entity)
        {
            if (!ModelState.IsValid)
            {
                var errorResponse = new ApiResponse<FactoryResponse>(
                    null, 
                    false, 
                    "Validation errors occurred: " + ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList()
                    );
                return errorResponse;
            }

            var operation = new CreateFactoryCommand(entity);
            var result = await mediator.Send(operation);
            return result;
        }

        // PUT: api/Factories/5
        [HttpPut("{factoryId}")]
        public async Task<ApiResponse> Put(long factoryId, [FromBody] FactoryRequest entity)
        {
            if (!ModelState.IsValid)
            {
                var errorResponse = new ApiResponse<FactoryResponse>(
                    null,
                    false,
                    "Validation errors occurred: " + ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList()
                    );
                return errorResponse;
            }
            
            var operation = new UpdateFactoryCommand(factoryId, entity);
            var result = await mediator.Send(operation);
            return result;
        }

        // DELETE: api/Factories/5
        [HttpDelete("{factoryId}")]
        public async Task<ApiResponse> Delete(long factoryId)
        {
            var operation = new DeleteFactoryCommand(factoryId);
            var result = await mediator.Send(operation);
            return result;
        }
    }
}
