using Contracts;
using MongoDB.Driver;

namespace Repository;

public class RepositoryManager : IRepositoryManager
{
    private readonly Lazy<IOrderRepository> _orderRepository;
    
    private readonly IMongoDatabase _database;
    private readonly IClientSessionHandle _session;

    public RepositoryManager(IMongoClient client)
    {
        _database = client.GetDatabase("mydatabase");
        _session = client.StartSession();

        _orderRepository = new Lazy<IOrderRepository>(() =>
            new OrderRepository("", "", ""));
    }

    public IOrderRepository OrderRepository => _orderRepository.Value;

    public async Task SaveChangesAsync()
    {
        await _session.CommitTransactionAsync();
        _session.Dispose();
    }
}