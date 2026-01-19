using ChairSetting.Data.DTO;
using ChairSetting.Data.Interface;
using ChairSetting.Data.Model;

namespace ChairSetting.Data.Service
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public void CreateUser(CreateUserDto dto)
        {
            if (_context.Users.Any(x => x.Username == dto.Username))
                throw new Exception("User already exists");

            var user = new User
            {
                Username = dto.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Role = dto.Role
            };

            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public IEnumerable<User> GetAllUsers()
            => _context.Users.ToList();

        public void UpdateUser(int id, UpdateUserDto dto)
        {
            var user = _context.Users.Find(id);
            if (user == null)
                throw new Exception("User not found");

            user.Username = dto.Username;
            user.Role = dto.Role;
            _context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
                throw new Exception("User not found");

            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}
