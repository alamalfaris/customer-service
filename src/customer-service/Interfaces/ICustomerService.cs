namespace customer_service.Interfaces
{
    public interface ICustomerService
    {
        ApiResponse<List<Customer>> GetCustomers(int page, int pageSize);
        void CreateCustomers(int numberOfCustomer);
        void CreateCustomer(CreateCustomerDto createCustomerDto);
    }
}
