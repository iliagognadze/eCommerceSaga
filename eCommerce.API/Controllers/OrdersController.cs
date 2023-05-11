using Contracts;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;

namespace eCommerce.API.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase
{
    private readonly IRepositoryManager _repositoryManager;
    
    public OrdersController(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] OrderForCreationDto order)
    {
        var test = await _repositoryManager.OrderRepository.GetAll();
        
        return Ok(test);
    }
}