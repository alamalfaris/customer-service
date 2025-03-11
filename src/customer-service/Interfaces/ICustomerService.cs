
namespace customer_service.Interfaces
{
    public interface ICustomerService
    {
        Task<ApiResponse<List<Customer>>> GetCustomersAsync(int page, int pageSize);
        void CreateCustomers(int numberOfCustomer);
        Task CreateCustomerAsync(CreateCustomerDto createCustomerDto);
        Task<ApiResponse<List<Customer>>> GetCustomersAsync(DateTime? lastCreatedDate, int pageSize);
    }
}
