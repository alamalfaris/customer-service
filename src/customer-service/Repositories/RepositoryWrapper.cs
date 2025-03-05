namespace customer_service.Repositories
{
    public class RepositoryWrapper : IRepository
    {
        private readonly DapperContext _context;

        public RepositoryWrapper(DapperContext context)
        {
            _context = context;
        }

        public ICustomerRepository CustomerRepository => new CustomerRepository(_context);
    }
}
