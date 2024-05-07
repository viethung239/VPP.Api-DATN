using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VPP.Application.Dto;
using VPP.Application.Services.Role;

namespace VPP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin,NVNhanSu")]
        public IActionResult AddRole(RoleDto roleDto)
        {
            try
            {
                roleDto.RoleId = Guid.NewGuid();

                if (_roleService.Add(roleDto))
                {
                    return CreatedAtAction(nameof(GetRoleById), new { id = roleDto.RoleId }, roleDto);
                }
                else
                {
                    return BadRequest(new { Message = "Không thể thêm quyền." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpGet]
        public IActionResult GetAllRoles()
        {
            try
            {
                var roles = _roleService.GetAll();
                return Ok(roles);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetRoleById(Guid id)
        {
            try
            {
                var role = _roleService.Get(id);
                if (role == null)
                {
                    return NotFound();
                }
                return Ok(role);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,NVNhanSu")]
        public IActionResult UpdateRole(Guid id, RoleDto roleDto)
        {
            try
            {
                roleDto.RoleId = id;
                var isUpdated = _roleService.Update(roleDto);
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
        [Authorize(Roles = "Admin,NVNhanSu")]
        public IActionResult DeleteRole(Guid id)
        {
            try
            {
                var isDeleted = _roleService.Delete(id);
                if (isDeleted)
                {
                    return NoContent();
                }
                else
                {
                    return NotFound("Không thể xóa vì quyền này không tồn tại");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }
    }
}
