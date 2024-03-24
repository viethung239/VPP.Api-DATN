using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VPP.Application.Dto;
using VPP.Application.Services.Order;
using VPP.Application.Services.OrderDetail;

namespace VPP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailService _orderdetailService;
        public OrderDetailController(IOrderDetailService orderdetailService)
        {
            _orderdetailService = orderdetailService;
        }

        [HttpPost]
        public IActionResult AddOrderDetail(OrderDetailDto orderdetailDto)
        {
            try
            {
                orderdetailDto.OrderDetailId = Guid.NewGuid();

                if (_orderdetailService.Add(orderdetailDto))
                {
                    return CreatedAtAction(nameof(GetOrderDetailById), new { id = orderdetailDto.OrderDetailId }, orderdetailDto);
                }
                else
                {
                    return BadRequest(new { Message = "Không thể thêm đơn hàng chi tiết." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpGet]
        public IActionResult GetAllOrderDetails()
        {
            try
            {
                var orders = _orderdetailService.GetAll();
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderDetailById(Guid id)
        {
            try
            {
                var orderdetail = _orderdetailService.Get(id);
                if (orderdetail == null)
                {
                    return NotFound();
                }
                return Ok(orderdetail);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateOrderDetail(Guid id, OrderDetailDto orderdetailDto)
        {
            try
            {
                orderdetailDto.OrderDetailId = id;
                var isUpdated = _orderdetailService.Update(orderdetailDto);
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
        public IActionResult DeleteOrderDetail(Guid id)
        {
            try
            {
                var isDeleted = _orderdetailService.Delete(id);
                if (isDeleted)
                {
                    return NoContent();
                }
                else
                {
                    return NotFound("Không thể xóa vì chi tiết đơn hàng này này không tồn tại");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }
    }
}
