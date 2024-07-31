using Microsoft.AspNetCore.Mvc;
using Pa.Base.Response;
using Pa.Schema.Factory;
using MediatR;
using Pa.Business.Cqrs;
using Pa.Schema.FactoryPhone;


namespace Pa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactoryPhonesController : ControllerBase
    {
        private readonly IMediator mediator;
        public FactoryPhonesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET: api/FactoryPhones
        [HttpGet]
        public async Task<ApiResponse<List<FactoryPhoneResponse>>> Get()
        {
            var operation = new GetAllFactoryPhoneQuery();
            var result = await mediator.Send(operation);
            return result;
        }

        // GET: api/FactoryPhones/GetFactoryPhoneByParameter?FactoryId=1&IsPrimary=true&CountryCode=TUR
        [HttpGet("GetFactoryPhoneByParameter")]
        public async Task<ApiResponse<List<FactoryPhoneResponse>>> GetFactoryPhoneByParameter(long? FactoryId, bool? IsPrimary, string? CountryCode)
        {
            var operation = new GetFactoryPhoneByParameterQuery(FactoryId, IsPrimary, CountryCode);
            var result = await mediator.Send(operation);
            return result;
        }

        // GET: api/FactoryPhones/5
        [HttpGet("{factoryPhoneId}")]
        public async Task<ApiResponse<FactoryPhoneResponse>> Get(long factoryPhoneId)
        {
            var operation = new GetFactoryPhoneByIdQuery(factoryPhoneId);
            var result = await mediator.Send(operation);
            return result;
        }

        // POST: api/FactoryPhones
        [HttpPost]
        public async Task<ApiResponse<FactoryPhoneResponse>> Post([FromBody] FactoryPhoneRequest entity)
        {
            if (!ModelState.IsValid)
            {
                var errorResponse = new ApiResponse<FactoryPhoneResponse>(
                    null,
                    false,
                    "Validation errors occurred: " + ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList()
                    );
                return errorResponse;
            }
            var operation = new CreateFactoryPhoneCommand(entity);
            var result = await mediator.Send(operation);
            return result;
        }

        // PUT: api/FactoryPhones/5
        [HttpPut("{factoryPhoneId}")]
        public async Task<ApiResponse> Put(long factoryPhoneId, [FromBody] FactoryPhoneRequest entity)
        {
            if (!ModelState.IsValid)
            {
                var errorResponse = new ApiResponse<FactoryPhoneResponse>(
                    null,
                    false,
                    "Validation errors occurred: " + ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList()
                    );
                return errorResponse;
            }
            var operation = new UpdateFactoryPhoneCommand(factoryPhoneId, entity);
            var result = await mediator.Send(operation);
            return result;
        }

        // DELETE: api/FactoryPhones/5
        [HttpDelete("{factoryPhoneId}")]
        public async Task<ApiResponse> Delete(long factoryPhoneId)
        {
            var operation = new DeleteFactoryPhoneCommand(factoryPhoneId);
            var result = await mediator.Send(operation);
            return result;
        }
    }
}
    