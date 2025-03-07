namespace customer_service.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository _repository;

        public CustomerService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<List<Customer>>> GetCustomersAsync(int page, int pageSize)
        {
            var customers = await _repository.CustomerRepository.GetCustomersAsync(page, pageSize);
            return ApiResponse<List<Customer>>.Success(customers, StatusCodes.Status200OK);
        }

        public void CreateCustomers(int numberOfCustomer)
        {
            for (int i = 0; i < numberOfCustomer; i++)
            {
                var createCustomerDto = new CreateCustomerDto
                {
                    Name = $"Customer-{i + 1}",
                    DateOfBirth = new DateTime(1997, 8, 2),
                    PlaceOfBirth = "Texas"
                };

                _repository.CustomerRepository.InsertCustomerAsync(createCustomerDto).GetAwaiter().GetResult();
            }
        }

        public async Task CreateCustomerAsync(CreateCustomerDto createCustomerDto)
        {
            await _repository.CustomerRepository.InsertCustomerAsync(createCustomerDto);
        }
    }
}
