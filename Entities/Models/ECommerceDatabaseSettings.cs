namespace Entities.Models;

public class ECommerceDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public string RequestedOrdersCollectionName { get; set; } = null!;
}