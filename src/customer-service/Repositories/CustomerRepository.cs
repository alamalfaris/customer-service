using Dapper;

namespace customer_service.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DapperContext _context;

        public CustomerRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            string sql = $@"SELECT [Id],[Name],[DateOfBirth],[PlaceOfBirth],[DeleteFlag],[CreatedDate]
                            FROM Customers";

            using var connection = _context.CreateConnection();
            var customers = await connection.QueryAsync<Customer>(sql);
            return customers.ToList();
        }
    }
}
