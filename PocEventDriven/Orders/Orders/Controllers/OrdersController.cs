using MediatR;
using Microsoft.AspNetCore.Mvc;
//using Orders.Notifications;
using Orders.Commands;
using Orders.Queries;
using Orders.Models;


namespace Orders.Controllers;

[Route("api/orders")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IPublisher _publisher;

    public OrdersController(ISender sender, IPublisher publisher)
    {
        _sender = sender;
        _publisher = publisher;
    }

    /// <summary>
    /// GetOrders
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult> GetOrders()
    {
        var orders = await _sender.Send(new GetOrdersQuery());
        return Ok(orders);
    }

    /// <summary>
    /// GetOrdersById
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:int}", Name = "GetOrderById")]
    public async Task<ActionResult> GetOrderById(int id)
    {
        var order = await _sender.Send(new GetOrderByIdQuery(id));
        return Ok(order);
    }

    /// <summary>
    /// AddOrder
    /// </summary>
    /// <param name="order"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult> AddOrder([FromBody]Order order)
    {
        var orderToReturn = await _sender.Send(new AddOrderCommand(order));
        return CreatedAtRoute("GetOrderById", new { id = order.Id }, orderToReturn);

        //Publisher
        //await _publisher.Publish(new OrderAddedNotifications(orderToReturn));
    }


    /// <summary>
    /// UpdateOrder
    /// </summary>
    /// <param name="id"></param>
    /// <param name="order"></param>
    /// <returns></returns>
    [HttpPut("{id:int}")]    
    public async Task<IActionResult> UpdateOrder(int id, [FromBody] Order order)
    {
        if (id != order.Id)
        {
            return BadRequest("Orden id no existe");
        }

        var response = await _sender.Send(new UpdateOrderCommand(order));
        return Ok(response);
    }


    /// <summary>
    /// DeleteOrders
    /// </summary>
    /// <param name="id"></param>
    /// <param name="order"></param>
    /// <returns></returns>
    [HttpDelete("{id:int}")]    
    public async Task<IActionResult> DeleteOrder(int id, [FromBody] Order order)
    {
        if (id != order.Id)
        {
            return BadRequest("Orden id no existe");
        }

        var response = await _sender.Send(new DeleteOrderCommand(order));
        
        return Ok(response);
    }
}