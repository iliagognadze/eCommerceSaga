namespace Entities.Models;

public class Order
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public string CustomerEmail { get; set; }
    public DateTime Date { get; set; }
    public decimal TotalPrice { get; set; }
    public ICollection<OrderItem> Items { get; set; }
}