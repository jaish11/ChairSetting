using ChairSetting.Data.DTO;
using ChairSetting.Data.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChairSetting.Controllers
{
    [ApiController]
    [Route("api/admin/users")]
    [Authorize(Roles = "Admin")]
    public class AdminUsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public AdminUsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Create(CreateUserDto dto)
        {
            _userService.CreateUser(dto);
            return Ok("User created");
        }

        [HttpGet]
        public IActionResult GetAll()
            => Ok(_userService.GetAllUsers());

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateUserDto dto)
        {
            _userService.UpdateUser(id, dto);
            return Ok("User updated");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userService.DeleteUser(id);
            return Ok("User deleted");
        }
    }
}
