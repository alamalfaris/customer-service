using customer_service.Models;
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

        public async Task<List<Customer>> GetCustomersAsync(int page, int pageSize)
        {
            string sql = $@"SELECT [Id],[Name],[DateOfBirth],[PlaceOfBirth],[DeleteFlag],[CreatedDate]
                            FROM Customers
                            ORDER BY [CreatedDate] DESC
                            OFFSET (@Page - 1) * @PageSize ROWS
                            FETCH NEXT @PageSize ROWS ONLY";

            var parameters = new DynamicParameters();
            parameters.Add("Page", page, DbType.Int32);
            parameters.Add("PageSize", pageSize, DbType.Int32);

            using var connection = _context.CreateConnection();
            var customers = await connection.QueryAsync<Customer>(sql, parameters);
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
