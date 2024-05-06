using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VPP.Application.Dto;
using VPP.Application.Services.CompanySupplier;
using VPP.Application.Services.Order;

namespace VPP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public IActionResult AddOrder(OrderDto orderDto)
        {
            try
            {
                

                if (_orderService.Add(orderDto))
                {
                    return CreatedAtAction(nameof(GetOrderById), new { id = orderDto.OrderId }, orderDto);
                }
                else
                {
                    return BadRequest(new { Message = "Không thể thêm đơn hàng." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpGet]
        public IActionResult GetAllOrders()
        {
            try
            {
                var orders = _orderService.GetAll();
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderById(Guid id)
        {
            try
            {
                var order = _orderService.Get(id);
                if (order == null)
                {
                    return NotFound();
                }
                return Ok(order);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateOrder(Guid id, OrderDto orderDto)
        {
            try
            {
                orderDto.OrderId = id;
                var isUpdated = _orderService.Update(orderDto);
                if (isUpdated)
                {
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(Guid id)
        {
            try
            {
                var isDeleted = _orderService.Delete(id);
                if (isDeleted)
                {
                    return NoContent();
                }
                else
                {
                    return NotFound("Không thể xóa vì đơn hàng này này không tồn tại");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }
    }
}
