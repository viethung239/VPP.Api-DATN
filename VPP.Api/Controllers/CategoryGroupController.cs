using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VPP.Application.Dto;
using VPP.Application.Services.Category;
using VPP.Application.Services.CategoryGroup;

namespace VPP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryGroupController : ControllerBase
    {
        private readonly ICategoryGroupService _categorygroupService;
        public CategoryGroupController(ICategoryGroupService categorygroupService)
        {
            _categorygroupService = categorygroupService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin,NVSanPham")]
        public IActionResult AddCategoryGroup(CategoryGroupDto categorygroupDto)
        {
            try
            {
                categorygroupDto.CategoryGroupId = Guid.NewGuid();

                if (_categorygroupService.Add(categorygroupDto))
                {
                    return CreatedAtAction(nameof(GetCategoryGroupById), new { id = categorygroupDto.CategoryGroupId }, categorygroupDto);
                }
                else
                {
                    return BadRequest(new { Message = "Không thể thêm nhóm danh mục." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpGet]
        public IActionResult GetAllCategoryGroups()
        {
            try
            {
                var categorygroups = _categorygroupService.GetAll();
                return Ok(categorygroups);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryGroupById(Guid id)
        {
            try
            {
                var categorygroup = _categorygroupService.Get(id);
                if (categorygroup == null)
                {
                    return NotFound();
                }
                return Ok(categorygroup);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateCategoryGroup(Guid id, CategoryGroupDto categorygroupDto)
        {
            try
            {
                categorygroupDto.CategoryGroupId = id;
                var isUpdated = _categorygroupService.Update(categorygroupDto);
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
        public IActionResult DeleteCategoryGroup(Guid id)
        {
            try
            {
                var isDeleted = _categorygroupService.Delete(id);
                if (isDeleted)
                {
                    return NoContent();
                }
                else
                {
                    return NotFound("Không thể xóa vì nhóm danh mục này này không tồn tại");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }
    }
}
