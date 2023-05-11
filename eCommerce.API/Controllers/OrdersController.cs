using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;

namespace eCommerce.API.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase
{
    public OrdersController()
    {
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] OrderForCreationDto order)
    {
        return Ok(order);
    }
}