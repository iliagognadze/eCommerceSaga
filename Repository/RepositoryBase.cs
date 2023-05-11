using Contracts;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Repository;

public class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    private readonly IMongoCollection<T> _collection;

    protected RepositoryBase(IMongoCollection<T> collection)
    {
        _collection = collection;
    }

    public async Task AddAsync(T entity) => 
        await _collection.InsertOneAsync(entity);

    public async Task UpdateAsync(ObjectId id, T entity) =>
        await _collection.ReplaceOneAsync(Builders<T>.Filter.Eq("_id", id), entity);

    public async Task DeleteAsync(ObjectId id) => 
        await _collection.DeleteOneAsync(Builders<T>.Filter.Eq("_id", id));
    
    public async Task<T> GetByIdAsync(ObjectId id)
    {
        var document = await _collection.FindAsync(Builders<T>.Filter.Eq("_id", id));
        return await document.SingleOrDefaultAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        var entities = await _collection.FindAsync(Builders<T>.Filter.Empty);
        return await entities.ToListAsync();
    }
}