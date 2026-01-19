using ChairSetting.Data;
using ChairSetting.Data.DTO;
using ChairSetting.Data.Interface;
using ChairSetting.Data.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChairSetting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly AppDbContext _context;

        public AuthController(IAuthService authService,AppDbContext context)
        {
            _authService = authService;
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            var token = _authService.Login(dto.Username, dto.Password);
            if (token == null)
                return Unauthorized();

            return Ok(new { token });
        }
        [HttpPost("signup")]
        public IActionResult Signup(SignupDto dto)
        {
            _authService.Signup(dto.Username, dto.Password);
            return Ok("User registered successfully");
        }
        [HttpPost("create-admin")]
        public IActionResult CreateAdmin()
        {
            if (_context.Users.Any(x => x.Role == "Admin"))
                return BadRequest("Admin already exists");

            var admin = new User
            {
                Username = "admin",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin@123"),
                Role = "Admin"
            };

            _context.Users.Add(admin);
            _context.SaveChanges();

            return Ok("Admin created");
        }
    }

}
