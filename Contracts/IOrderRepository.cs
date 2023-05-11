using Entities.Models;

namespace Contracts;

public interface IOrderRepository
{
    Task<IEnumerable<Order>> GetAll();
}