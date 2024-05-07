using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VPP.Application.Dto;
using VPP.Application.Services.CategoryGroup;
using VPP.Application.Services.CompanySupplier;

namespace VPP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanySupplierController : ControllerBase
    {
        private readonly ICompanySupplierService _splService;
        public CompanySupplierController(ICompanySupplierService splService)
        {
            _splService = splService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin,NVSanPham")]
        public IActionResult AddCompanySupplier(CompanySupplierDto splDto)
        {
            try
            {
                splDto.SupplierId = Guid.NewGuid();

                if (_splService.Add(splDto))
                {
                    return CreatedAtAction(nameof(GetCompanySupplierById), new { id = splDto.SupplierId }, splDto);
                }
                else
                {
                    return BadRequest(new { Message = "Không thể thêm nhà cung cấp." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpGet]
        public IActionResult GetAllCompanySuppliers()
        {
            try
            {
                var spls = _splService.GetAll();
                return Ok(spls);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetCompanySupplierById(Guid id)
        {
            try
            {
                var spl = _splService.Get(id);
                if (spl == null)
                {
                    return NotFound();
                }
                return Ok(spl);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,NVSanPham")]
        public IActionResult UpdateCompanySupplier(Guid id, CompanySupplierDto splDto)
        {
            try
            {
                splDto.SupplierId = id;
                var isUpdated = _splService.Update(splDto);
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
        [Authorize(Roles = "Admin,NVSanPham")]
        public IActionResult DeleteCompanySupplier(Guid id)
        {
            try
            {
                var isDeleted = _splService.Delete(id);
                if (isDeleted)
                {
                    return NoContent();
                }
                else
                {
                    return NotFound("Không thể xóa vì nhà cung cấp này này không tồn tại");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }
    }
}
