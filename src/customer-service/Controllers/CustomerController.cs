using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace customer_service.Controllers
{
    [Route("api")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;

        public CustomerController(ILogger<CustomerController> logger, ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        [HttpGet("v1/customers")]
        public IActionResult GetCustomersAsync()
        {
            _logger.LogInformation("TraceIdentifier: {Identifier} - GET v1/customers initialize", HttpContext.TraceIdentifier);
            var response = _customerService.GetCustomersAsync();
            return StatusCode(response.StatusCode, response);
        }
    }
}
