using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VPP.Application.Dto;
using VPP.Application.Services.UserRole;

namespace VPP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleService _urService;
        public UserRoleController(IUserRoleService urService)
        {
            _urService = urService;
        }

        [HttpPost]
        public IActionResult AddUserRole(UserRoleDto urDto)
        {
            try
            {
                urDto.UserRoleId = Guid.NewGuid();

                if (_urService.Add(urDto))
                {
                    return CreatedAtAction(nameof(GetUserRoleById), new { id = urDto.UserRoleId }, urDto);
                }
                else
                {
                    return BadRequest(new { Message = "Không thể thêm danh sách quyền người dùng." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpGet]
        public IActionResult GetAllUserRoles()
        {
            try
            {
                var uroles = _urService.GetAll();
                return Ok(uroles);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetUserRoleById(Guid id)
        {
            try
            {
                var urole = _urService.Get(id);
                if (urole == null)
                {
                    return NotFound();
                }
                return Ok(urole);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateUserRole(Guid id, UserRoleDto urDto)
        {
            try
            {
                urDto.UserRoleId = id;
                var isUpdated = _urService.Update(urDto);
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
        public IActionResult DeleteUserRole(Guid id)
        {
            try
            {
                var isDeleted = _urService.Delete(id);
                if (isDeleted)
                {
                    return NoContent();
                }
                else
                {
                    return NotFound("Không thể xóa vì không tồn tại");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }
    }
}
