using Contracts;
using Entities.Models;

namespace Repository;

public class OrderRepository : RepositoryBase<Order>, IOrderRepository
{
    public OrderRepository(string connectionString, string databaseName, string collectionName) : base(
        connectionString, databaseName, collectionName)
    {
    }

    public async Task<IEnumerable<Order>> GetAll() => await GetAllAsync();

}