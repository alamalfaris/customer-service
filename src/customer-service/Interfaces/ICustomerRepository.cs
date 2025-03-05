namespace customer_service.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetCustomersAsync();
        Task InsertCustomerAsync(CreateCustomerDto createCustomerDto);
    }
}
