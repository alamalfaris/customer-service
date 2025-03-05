namespace customer_service.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository _repository;

        public CustomerService(IRepository repository)
        {
            _repository = repository;
        }

        public ApiResponse<List<Customer>> GetCustomersAsync()
        {
            var customers = _repository.CustomerRepository.GetCustomersAsync().GetAwaiter().GetResult();
            return ApiResponse<List<Customer>>.Success(customers, StatusCodes.Status200OK);
        }
    }
}
