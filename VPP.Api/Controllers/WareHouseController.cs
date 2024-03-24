using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VPP.Application.Dto;
using VPP.Application.Services.Category;
using VPP.Application.Services.WareHouse;

namespace VPP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WareHouseController : ControllerBase
    {
        private readonly IWareHouseService _whService;
        public WareHouseController(IWareHouseService whService)
        {
            _whService = whService;
        }

        [HttpPost]
        public IActionResult AddWareHouse(WareHouseDto whDto)
        {
            try
            {
                whDto.WareHouseId = Guid.NewGuid();

                if (_whService.Add(whDto))
                {
                    return CreatedAtAction(nameof(GetWareHouseById), new { id = whDto.WareHouseId }, whDto);
                }
                else
                {
                    return BadRequest(new { Message = "Không thể thêm kho." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpGet]
        public IActionResult GetAllWareHouses()
        {
            try
            {
                var whs = _whService.GetAll();
                return Ok(whs);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetWareHouseById(Guid id)
        {
            try
            {
                var wh = _whService.Get(id);
                if (wh == null)
                {
                    return NotFound();
                }
                return Ok(wh);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateWareHouse(Guid id, WareHouseDto whDto)
        {
            try
            {
                whDto.WareHouseId = id;
                var isUpdated = _whService.Update(whDto);
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
        public IActionResult DeleteWareHouse(Guid id)
        {
            try
            {
                var isDeleted = _whService.Delete(id);
                if (isDeleted)
                {
                    return NoContent();
                }
                else
                {
                    return NotFound("Không thể xóa kho này không tồn tại");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }
    }
}
