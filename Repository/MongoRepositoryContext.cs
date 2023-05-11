using Entities.Models;
using MongoDB.Driver;

namespace Repository;

public class MongoRepositoryContext
{
    private IMongoDatabase _database;

    public MongoRepositoryContext(string connectionString, string databaseName)
    {
        var client = new MongoClient(connectionString);
        _database = client.GetDatabase(databaseName);
    }

    public IMongoCollection<RequestedOrder> Users => _database.GetCollection<RequestedOrder>("orders");

    // Other entity collections can be added here as well
}