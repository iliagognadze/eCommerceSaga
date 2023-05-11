namespace Shared.DTOs;

public class OrderForCreationDto
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public string CustomerEmail { get; set; }
    public DateTime Date { get; set; }
    public decimal TotalPrice { get; set; }
    public List<OrderItem> Items { get; set; }
}