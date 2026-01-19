using ChairSetting.Data.Interface;
using ChairSetting.Data.Model;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Crypto.Generators;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ChairSetting.Data.Service
{
    public class AuthService:IAuthService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;

        public AuthService(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public string Login(string username, string password)
        {
            var user = _context.Users
                .FirstOrDefault(x => x.Username == username);

            if (user == null)
                return null;
              if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
        return null;

            var claims = new[]
            {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.Role),
            new Claim("UserId", user.Id.ToString())
        };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: new SigningCredentials(
                    key, SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public void Signup(string username, string password)
        {
            if (_context.Users.Any(x => x.Username == username))
                throw new Exception("User already exists");

            var user = new User
            {
                Username = username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
                Role = "User" // default role
            };

            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
