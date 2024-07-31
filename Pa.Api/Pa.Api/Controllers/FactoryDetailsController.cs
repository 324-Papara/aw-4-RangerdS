using Microsoft.AspNetCore.Mvc;
using Pa.Base.Response;
using Pa.Schema.Factory;
using MediatR;
using Pa.Business.Cqrs;
using Pa.Schema.FactoryDetail;


namespace Pa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactoryDetailsController : ControllerBase
    {
        private readonly IMediator mediator;

        public FactoryDetailsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET: api/FactoryDetails
        [HttpGet]
        public async Task<ApiResponse<List<FactoryDetailResponse>>> Get()
        {
            var operation = new GetAllFactoryDetailQuery();
            var result = await mediator.Send(operation);
            return result;
        }

        // GET: api/FactoryDetails/GetFilterByFactoryId?factoryId=1
        [HttpGet("GetFilterByFactoryId")]
        public async Task<ApiResponse<List<FactoryDetailResponse>>> GetFilterByFactoryId(long? factoryId)
        {
            var operation = new GetFactoryDetailByParameterQuery(factoryId);
            var result = await mediator.Send(operation);
            return result;
        }

        // GET: api/FactoryDetails/5
        [HttpGet("{factoryDetailId}")]
        public async Task<ApiResponse<FactoryDetailResponse>> Get(long factoryDetailId)
        {
            var operation = new GetFactoryDetailByIdQuery(factoryDetailId);
            var result = await mediator.Send(operation);
            return result;
        }

        // POST: api/FactoryDetails
        [HttpPost]
        public async Task<ApiResponse<FactoryDetailResponse>> Post([FromBody] FactoryDetailRequest entity)
        {
            if (!ModelState.IsValid)
            {
                var errorResponse = new ApiResponse<FactoryDetailResponse>(
                    null,
                    false,
                    "Validation errors occurred: " + ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList()
                    );
                return errorResponse;
            }

            var operation = new CreateFactoryDetailCommand(entity);
            var result = await mediator.Send(operation);
            return result;
        }

        // PUT: api/FactoryDetails/5
        [HttpPut("{factoryDetailId}")]
        public async Task<ApiResponse> Put(long factoryDetailId, [FromBody] FactoryDetailRequest entity)
        {
            if (!ModelState.IsValid)
            {
                var errorResponse = new ApiResponse<FactoryDetailResponse>(
                    null,
                    false,
                    "Validation errors occurred: " + ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList()
                    );
                return errorResponse;
            }

            var operation = new UpdateFactoryDetailCommand(factoryDetailId, entity);
            var result = await mediator.Send(operation);
            return result;
        }

        // DELETE: api/FactoryDetails/5
        [HttpDelete("{factoryDetailId}")]
        public async Task<ApiResponse> Delete(long factoryDetailId)
        {
            var operation = new DeleteFactoryDetailCommand(factoryDetailId);
            var result = await mediator.Send(operation);
            return result;
        }
    }
}
