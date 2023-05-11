using Contracts;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Repository;

public class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    private readonly IMongoCollection<T> _collection;

    protected RepositoryBase(string connectionString, string databaseName, string collectionName)
    {
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase(databaseName);
        _collection = database.GetCollection<T>(collectionName);
    }

    public async Task Add(T entity) => 
        await _collection.InsertOneAsync(entity);

    public async Task Update(ObjectId id, T entity) =>
        await _collection.ReplaceOneAsync(Builders<T>.Filter.Eq("_id", id), entity);

    public async Task Delete(ObjectId id) => 
        await _collection.DeleteOneAsync(Builders<T>.Filter.Eq("_id", id));
    
    public async Task<T> GetById(ObjectId id)
    {
        var document = await _collection.FindAsync(Builders<T>.Filter.Eq("_id", id));
        return await document.SingleOrDefaultAsync();
    }
    
    public IEnumerable<T> GetAll()
    {
        throw new NotImplementedException();
    }
}