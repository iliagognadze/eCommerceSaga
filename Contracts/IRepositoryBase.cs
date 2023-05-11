using MongoDB.Bson;

namespace Contracts;

public interface IRepositoryBase<T> where T : class
{
    Task AddAsync(T entity);
    
    Task UpdateAsync(ObjectId id, T entity);
    Task DeleteAsync(ObjectId id);
    
    Task<T> GetByIdAsync(ObjectId id);
    Task<IEnumerable<T>> GetAllAsync();
}