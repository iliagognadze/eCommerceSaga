using Contracts;
using Entities.Models;
using MongoDB.Driver;

namespace Repository;

public class OrderRepository : RepositoryBase<RequestedOrder>, IOrderRepository
{
    public OrderRepository(IMongoCollection<RequestedOrder> collection) : base(collection)
    {
    }

    public async Task<IEnumerable<RequestedOrder>> GetAll() => await GetAllAsync();

}