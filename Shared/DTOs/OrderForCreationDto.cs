namespace Shared.DTOs;

public class OrderForCreationDto
{
    public string CustomerName { get; set; }
    public string CustomerEmail { get; set; }
    public DateTime Date { get; set; }
    public decimal TotalPrice { get; set; }
    public List<OrderItemDto> Items { get; set; }
}