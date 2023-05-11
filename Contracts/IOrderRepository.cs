using Entities.Models;

namespace Contracts;

public interface IOrderRepository
{
    Task<IEnumerable<RequestedOrder>> GetAll();
}