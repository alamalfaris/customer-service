using Dapper;
using System.Data;

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

        public async Task InsertCustomerAsync(CreateCustomerDto createCustomerDto)
        {
            string sql = $@"INSERT INTO Customers ([Id],[Name],[DateOfBirth],[PlaceOfBirth],[DeleteFlag],[CreatedDate])
                            VALUES (NEWID(),@Name,@DateOfBirth,@PlaceOfBirth,0,GETDATE())";

            var parameters = new DynamicParameters();
            parameters.Add("Name", createCustomerDto.Name, DbType.String);
            parameters.Add("DateOfBirth", createCustomerDto.DateOfBirth, DbType.DateTime);
            parameters.Add("PlaceOfBirth", createCustomerDto.PlaceOfBirth, DbType.String);

            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(sql, parameters);
        }
    }
}
