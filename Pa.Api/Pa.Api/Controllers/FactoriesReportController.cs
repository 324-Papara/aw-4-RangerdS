using Microsoft.AspNetCore.Mvc;
using Pa.Data.DapperRepository;

namespace Pa.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FactoriesReportController : ControllerBase
    {
        private readonly FactoryRepository _factoryRepository;

        public FactoriesReportController(FactoryRepository factoryRepository)
        {
            _factoryRepository = factoryRepository;
        }

        [HttpGet("report")]
        public async Task<IActionResult> GetFactoryReport()
        {
            var factories = await _factoryRepository.GetFactoriesWithDetailsAsync();
            return Ok(factories);
        }
    }
}
