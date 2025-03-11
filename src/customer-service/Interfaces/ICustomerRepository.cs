
namespace customer_service.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetCustomersAsync(int page, int pageSize);
        Task<List<Customer>> GetCustomersAsync(DateTime? lastCreatedDate, int pageSize);
        Task InsertCustomerAsync(CreateCustomerDto createCustomerDto);
    }
}
