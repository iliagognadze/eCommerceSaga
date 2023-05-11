using MongoDB.Bson;

namespace Contracts;

public interface IRepositoryBase<T> where T : class
{
    Task Add(T entity);
    
    Task Update(ObjectId id, T entity);
    Task Delete(ObjectId id);
    
    Task<T> GetById(ObjectId id);
    IEnumerable<T> GetAll();
}