using AccountingOfApples.ViewModels;
using AutoMapper;
using BLL.DTO;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace AccountingOfApples.Controllers;

public class OrderController : Controller
{
    private readonly IOrderControlService _orderControlService;
    private readonly IMapper _mapper;

    public OrderController(IOrderControlService orderControlService, IMapper mapper)
    {
        _orderControlService = orderControlService;
        _mapper = mapper;
    }

    [HttpGet("List")]
    public async Task<IActionResult> GetOrders()
    {
        return Ok(_mapper.Map<List<OrderViewModel>>(await _orderControlService.GetAllAsync()));
    }

    [HttpGet("Get/{id}")]
    public async Task<IActionResult> GetOrderById(Guid id)
    {
        return Ok(_mapper.Map<OrderViewModel>(await _orderControlService.GetByIdAsync(id)));
    }

    [HttpPost("Add")]
    public async Task<IActionResult> CreateOrder([FromBody]OrderViewModel order)
    {
        if (ModelState.IsValid)
        {
            OrderDTO? newOrderDTO = await _orderControlService.CreateAsync(_mapper.Map<OrderDTO>(order));
            if (newOrderDTO != null)
            {
                return StatusCode(StatusCodes.Status201Created, order);
            }
            return BadRequest("Save changes Exeption!");
        }
        return BadRequest("Incorrect data!");
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(OrderViewModel order)
    {
        if (ModelState.IsValid)
        {
            OrderDTO? updateOrderDTO = await _orderControlService.UpdateAsync(_mapper.Map<OrderDTO>(order));
            if (updateOrderDTO != null)
            {
                return StatusCode(StatusCodes.Status200OK, order);
            }
            return BadRequest("Save changes Exeption!");
        }
        return BadRequest("Incorrect data!");
    }

    [HttpDelete("Remove/{id}")]
    public async Task<IActionResult> Remove(Guid id)
    {
        if (await _orderControlService.Remove(id))
        {
            return NoContent();
        }
        return BadRequest("Remove Exeption!");
    }
}
