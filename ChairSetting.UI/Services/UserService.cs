using ChairSetting.UI.Helpers;
using ChairSetting.UI.Models;
using System.Net.Http.Json;

namespace ChairSetting.UI.Services
{
    public class UserService
    {
        private readonly ApiHttpClient _api;

        public UserService(ApiHttpClient api)
        {
            _api = api;
        }

        public async Task<List<UserDto>> GetAll()
        {
            var http = await _api.CreateClientAsync();
            return await http.GetFromJsonAsync<List<UserDto>>("api/admin/users");
        }

        public async Task Create(CreateUserDto dto)
        {
            var http = await _api.CreateClientAsync();
            await http.PostAsJsonAsync("api/admin/users", dto);
        }

        public async Task Update(int id, UpdateUserDto dto)
        {
            var http = await _api.CreateClientAsync();
            await http.PutAsJsonAsync($"api/admin/users/{id}", dto);
        }

        public async Task Delete(int id)
        {
            var http = await _api.CreateClientAsync();
            await http.DeleteAsync($"api/admin/users/{id}");
        }
    }

    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
    }
}
