﻿using Contracts;
using Entities.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Repository;

public class RepositoryManager : IRepositoryManager
{
    private readonly Lazy<IOrderRepository> _orderRepository;
    
    private readonly IMongoDatabase _database;
    private readonly IClientSessionHandle _session;

    public RepositoryManager(IOptions<ECommerceDatabaseSettings> eCommerceDatabaseSettings)
    {
        var mongoClient = new MongoClient(eCommerceDatabaseSettings.Value.ConnectionString);
        _database = mongoClient.GetDatabase(eCommerceDatabaseSettings.Value.DatabaseName);
        
        _session = mongoClient.StartSession();

        _orderRepository = new Lazy<IOrderRepository>(() =>
            new OrderRepository(_database.GetCollection<Order>
                (eCommerceDatabaseSettings.Value.RequestedOrdersCollectionName)));
    }

    public IOrderRepository OrderRepository => _orderRepository.Value;

    public async Task SaveChangesAsync()
    {
        await _session.CommitTransactionAsync();
        _session.Dispose();
    }
}