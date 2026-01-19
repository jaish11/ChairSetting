using ChairSetting.Data.DTO;
using ChairSetting.Data.Model;

namespace ChairSetting.Data.Interface
{
    public interface IUserService
    {
        void CreateUser(CreateUserDto dto);
        IEnumerable<User> GetAllUsers();
        void UpdateUser(int id, UpdateUserDto dto);
        void DeleteUser(int id);
    }
}
