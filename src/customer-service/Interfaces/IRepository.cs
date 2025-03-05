namespace customer_service.Interfaces
{
    public interface IRepository
    {
        ICustomerRepository CustomerRepository { get; }
    }
}
