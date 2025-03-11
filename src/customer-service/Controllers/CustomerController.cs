﻿using Microsoft.AspNetCore.Http;
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

        [HttpGet("v1/customers/offset")]
        public async Task<IActionResult> GetCustomers([FromQuery] int page, [FromQuery] int pageSize)
        {
            _logger.LogInformation("TraceIdentifier: {Identifier} - GET v1/customers initialize", HttpContext.TraceIdentifier);
            var response = await _customerService.GetCustomersAsync(page, pageSize);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("v1/customers/keyset")]
        public async Task<IActionResult> GetCustomers([FromQuery] DateTime? lastCreatedDate, [FromQuery] int pageSize)
        {
            _logger.LogInformation("TraceIdentifier: {Identifier} - GET v1/customers initialize", HttpContext.TraceIdentifier);
            var response = await _customerService.GetCustomersAsync(lastCreatedDate, pageSize);
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

        [HttpPost("v1/customers")]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerDto createCustomerDto)
        {
            await _customerService.CreateCustomerAsync(createCustomerDto);
            return Created();
        }
    }
}
