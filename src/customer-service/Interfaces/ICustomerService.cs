namespace customer_service.Interfaces
{
    public interface ICustomerService
    {
        ApiResponse<List<Customer>> GetCustomersAsync();
    }
}
