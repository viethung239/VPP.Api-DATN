using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VPP.Application.Dto;
using VPP.Application.Services.Role;
using VPP.Application.Services.User;
using VPP.Application.Services.UserRole;
using VPP.Domain.Entities;
using VPP.Infrastructure.Context;


namespace VPP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        private readonly IUserRoleService _urService;
        private readonly VPPDBContext _context;
        private readonly IRoleService _roleService;
        public AuthController(IUserService userService, IConfiguration configuration, IUserRoleService urService, IRoleService roleService, VPPDBContext context)
        {
            _userService = userService;
            _configuration = configuration;
            _urService = urService;
            _roleService = roleService;
            _context = context;
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

                var isAdmin = user.IsAdmin;
                var userId = user.UserId;
                var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
                var signingCredential = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, userDto.UserName),
                    new Claim(ClaimTypes.Actor, isAdmin.ToString()),
                    new Claim(ClaimTypes.Dsa, userId.ToString() ),

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
            string formattedDate = DateTime.UtcNow.ToString("yyyy-MM-dd");

            userDto.UserId = Guid.NewGuid();
            userDto.Avartar = "defaultavatar.jpg";
            userDto.Phone = "000000000";
            userDto.Address = "Chưa có";
            userDto.Comune = "Chưa có";
            userDto.District = "Chưa có";
            userDto.City = "Chưa có";     
            DateTime? birthDay = DateTime.Parse(formattedDate);
            userDto.BirthDay = birthDay;
            userDto.Gender = 2;
            userDto.IsAdmin = false;
            userDto.IsActive = true;
            DateTime? dateCreated = DateTime.Parse(formattedDate);
            userDto.DateCreated = dateCreated;
            DateTime? dateUpdated = DateTime.Parse(formattedDate);
            userDto.DateUpdated = dateUpdated;
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

        [HttpPost("doi-mat-khau")]
        public IActionResult DoiMatKhau([FromBody] ChangePasswordDto changePasswordDto)
        {
            if (changePasswordDto == null || string.IsNullOrEmpty(changePasswordDto.CurrentPassword) || string.IsNullOrEmpty(changePasswordDto.NewPassword))
            {
                return BadRequest(new { Message = "Dữ liệu không hợp lệ." });
            }

            var userIdClaim = HttpContext.User.FindFirstValue("http://schemas.microsoft.com/ws/2008/06/identity/claims/dsa");

            var user = _context.Users.FirstOrDefault(u => u.UserId == new Guid(userIdClaim!));

            if (user!.Password != changePasswordDto.CurrentPassword)
            {
                return BadRequest(new { Message = "Mật khẩu hiện tại không chính xác." });
            }

            user.Password = changePasswordDto.NewPassword;

            try
            {
                _context.SaveChanges();
                return Ok(new { Message = "Đổi mật khẩu thành công." });
            }
            catch
            {
                return BadRequest(new { Message = "Có lỗi xảy ra khi cập nhật mật khẩu." });
            }
        }



    }
}


