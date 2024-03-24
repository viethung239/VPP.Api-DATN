using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VPP.Application.Dto;
using VPP.Application.Services.Role;
using VPP.Application.Services.User;
using VPP.Application.Services.UserRole;

namespace VPP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        private readonly IUserRoleService _urService;

        private readonly IRoleService _roleService;
        public AuthController(IUserService userService, IConfiguration configuration, IUserRoleService urService, IRoleService roleService)
        {
            _userService = userService;
            _configuration = configuration;
            _urService = urService;
            _roleService = roleService;
        }
       
        [HttpPost("dang-nhap")]
        public IActionResult Login([FromBody] UserDto userDto)
        {
            if (userDto?.UserName == null || userDto?.Password == null)
            {
                return Unauthorized();
            }

            var secretKey = _configuration["JWT:Secret"];
            if (secretKey == null)
            {
                return Unauthorized();
            }

            var user = _userService.GetAll().Find(x => x.UserName == userDto.UserName && x.Password == userDto.Password);

            if (user != null)
            {
                var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
                var signingCredential = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, userDto.UserName),
        };

               
                var userRoles = _urService.GetRolesByUserId(user.UserId);

                foreach (var userRole in userRoles)
                {
                    
                    var role = _roleService.Get(userRole.RoleId);

                    if (role != null)
                    {
                        
                        claims.Add(new Claim(ClaimTypes.Role, role.RoleName??"bị null"));
                    }
                }

               
                var token = new JwtSecurityToken
                (
                    issuer: _configuration["JWT:Issuer"],
                    audience: _configuration["JWT:Audience"],
                    expires: DateTime.Now.AddHours(24),
                    signingCredentials: signingCredential,
                    claims: claims
                );

               
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }

            return Unauthorized();
        }

        [HttpPost("dang-ky")]
        public IActionResult DangKy([FromBody] UserDto userDto)
        {
        
            if (userDto == null || string.IsNullOrEmpty(userDto.UserName) || string.IsNullOrEmpty(userDto.Password))
            {
                return BadRequest(new { Message = "Thông tin người dùng không hợp lệ." });
            }

          
            if (_userService.GetAll().Any(x => x.UserName == userDto.UserName))
            {
                return BadRequest(new { Message = "Tên tài khoản đã tồn tại." });
            }

            userDto.UserId = Guid.NewGuid();
            if (_userService.Add(userDto))
            {
              
                var addedUser = _userService.GetAll().FirstOrDefault(x => x.UserName == userDto.UserName);
               
                if (addedUser != null)
                {
                    
                    var defaultRole = _roleService.GetAll().FirstOrDefault(r => r.RoleName == "User");

                    if (defaultRole != null)
                    {
                       
                        var userRole = new UserRoleDto
                        {
                            UserId = addedUser.UserId,
                            RoleId = defaultRole.RoleId
                        };

                        _urService.Add(userRole);

                        return Ok(new { Message = "Đăng ký thành công" });
                    }
                    else
                    {
                        return BadRequest(new { Message = "Không tìm thấy vai trò mặc định." });
                    }
                }
                else
                {
                    return BadRequest(new { Message = "Đăng ký không thành công" });
                }
            }
            else
            {
                return BadRequest(new { Message = "Đăng ký không thành công" });
            }
        }



    }
}


