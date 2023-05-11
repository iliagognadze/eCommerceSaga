using Contracts;
using Entities.Models;
using MongoDB.Driver;

namespace Repository;

public class OrderRepository : RepositoryBase<Order>, IOrderRepository
{
    public OrderRepository(IMongoCollection<Order> collection) : base(collection)
    {
    }

    public async Task<IEnumerable<Order>> GetAll() => await GetAllAsync();

}