using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using VPP.Application.Dto;
using VPP.Application.Services.User;

namespace VPP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
     
        [HttpPost]
        public IActionResult AddUser(UserDto userDto)
        {
            try
            {
               
                var existingUser = _userService.GetAll().FirstOrDefault(x => x.UserName == userDto.UserName);
                if (existingUser != null)
                {
                    return BadRequest(new { Message = "Tài khoản đã tồn tại." });
                }

                
                userDto.UserId = Guid.NewGuid();
                var isAdded = _userService.Add(userDto);
               
                if (isAdded)
                {
                    return CreatedAtAction(nameof(GetUserById), new { id = userDto.UserId }, new { Message = "Tạo tài khoản thành công", CreatedUserId = userDto.UserId });
                }
                else
                {
                    return BadRequest(new { Message = "Không thể thêm người dùng." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            try
            {
                var users = _userService.GetAll();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(Guid id)
        {
            try
            {
                var user = _userService.Get(id);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(Guid id, UserDto userDto)
        {
            try
            {
                userDto.UserId = id;
                var isUpdated = _userService.Update(userDto);
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
        public IActionResult DeleteUser(Guid id)
        {
            try
            {
                var isDeleted = _userService.Delete(id);
                if (isDeleted)
                {
                    return NoContent();
                }
                else
                {
                    return NotFound("Không thể xóa vì user này không tồn tại");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }
    }
}
