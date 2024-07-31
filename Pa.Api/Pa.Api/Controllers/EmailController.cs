using Microsoft.AspNetCore.Mvc;
using Pa.Api.Services;
using Pa.Base.Response;

namespace Pa.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : Controller
    {
        private readonly EmailQueueService emailQueueService;

        public EmailController(EmailQueueService emailQueueService)
        {
            this.emailQueueService = emailQueueService;
        }

        [HttpPost]
        public IActionResult SendEmail([FromBody] EmailMessage emailMessage)
        {
            emailQueueService.EnqueueEmail(emailMessage);
            return Ok("Email queued successfully");
        }

        [HttpGet]
        public ApiResponse Get()
        {
            return new ApiResponse();
        }
    }
}
