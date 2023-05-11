using Entities.Models;

namespace Contracts;

public interface IOrderRepository
{
    public IEnumerable<Order> GetAll();
}