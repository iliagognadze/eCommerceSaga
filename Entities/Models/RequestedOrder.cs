using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Entities.Models;

public class RequestedOrder
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    
    public string CustomerName { get; set; }

    public string CustomerEmail { get; set; }
    
    public DateTime Date { get; set; }
    
    public decimal TotalPrice { get; set; }
    
    //public ICollection<OrderItem> Items { get; set; }
}