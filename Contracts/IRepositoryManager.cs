namespace Contracts;

public interface IRepositoryManager
{
    IOrderRepository OrderRepository { get; }

    Task SaveChangesAsync();
}