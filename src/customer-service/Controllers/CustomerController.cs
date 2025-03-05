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
        public IActionResult GetCustomers([FromQuery] int page, [FromQuery] int pageSize)
        {
            _logger.LogInformation("TraceIdentifier: {Identifier} - GET v1/customers initialize", HttpContext.TraceIdentifier);
            var response = _customerService.GetCustomers(page, pageSize);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("v1/customers/many/{numberOfCustomer}")]
        public IActionResult CreateCustomers(int numberOfCustomer)
        {
            _logger.LogInformation("TraceIdentifier: {Identifier} - POST v1/customers/many/{NumberOfCustomer}", 
                HttpContext.TraceIdentifier, numberOfCustomer);

            _customerService.CreateCustomers(numberOfCustomer);
            return Created();
        }

        //[HttpPost("v1/customers")]
        //public IActionResult CreateCustomer([FromBody] CreateCustomerDto createCustomerDto)
    }
}
