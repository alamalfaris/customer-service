namespace customer_service.Interfaces
{
    public interface ICustomerService
    {
        ApiResponse<List<Customer>> GetCustomers();
        void CreateCustomers(int numberOfCustomer);
    }
}
