using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VPP.Application.Dto;
using VPP.Application.Services.WareHouse;
using VPP.Application.Services.WareHouseDetail;

namespace VPP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WareHouseDetailController : ControllerBase
    {
        private readonly IWareHouseDetailService _whdService;
        public WareHouseDetailController(IWareHouseDetailService whdService)
        {
            _whdService = whdService;
        }

        [HttpPost]
        public IActionResult AddWareHouse(WareHouseDetailDto whdDto)
        {
            try
            {
                whdDto.WareHouseDetailId = Guid.NewGuid();

                if (_whdService.Add(whdDto))
                {
                    return CreatedAtAction(nameof(GetWareHouseDetailById), new { id = whdDto.WareHouseDetailId }, whdDto);
                }
                else
                {
                    return BadRequest(new { Message = "Không thể thêm kho chi tiết." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpGet]
        public IActionResult GetAllWareHouseDetails()
        {
            try
            {
                var whds = _whdService.GetAll();
                return Ok(whds);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetWareHouseDetailById(Guid id)
        {
            try
            {
                var whd = _whdService.Get(id);
                if (whd == null)
                {
                    return NotFound();
                }
                return Ok(whd);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateWareHouse(Guid id, WareHouseDetailDto whdDto)
        {
            try
            {
                whdDto.WareHouseDetailId = id;
                var isUpdated = _whdService.Update(whdDto);
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
        public IActionResult DeleteWareHouseDetail(Guid id)
        {
            try
            {
                var isDeleted = _whdService.Delete(id);
                if (isDeleted)
                {
                    return NoContent();
                }
                else
                {
                    return NotFound("Không thể xóa kho chi tiết này không tồn tại");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }
    }
}
