using ChairSetting.UI.Helpers;
using ChairSetting.UI.Models;
using System.Net.Http.Json;

namespace ChairSetting.UI.Services
{
    public class ChairService
    {
        private readonly ApiHttpClient _api;

        public ChairService(ApiHttpClient api)
        {
            _api = api;
        }

        public async Task<List<ChairResponseDto>> GetAll()
        {
            var http = await _api.CreateClientAsync();
            return await http.GetFromJsonAsync<List<ChairResponseDto>>("api/Chair");
        }

        public async Task Add(string chairNumber)
        {
            var http = await _api.CreateClientAsync();
            await http.PostAsync($"api/Chair?chairNumber={chairNumber}", null);
        }

        public async Task Delete(int id)
        {
            var http = await _api.CreateClientAsync();
            await http.DeleteAsync($"api/Chair/{id}");
        }

        public async Task Occupy(int id)
        {
            var http = await _api.CreateClientAsync();
            await http.PostAsync($"api/Chair/occupy/{id}", null);
        }

        public async Task Release(int id)
        {
            var http = await _api.CreateClientAsync();
            await http.PostAsync($"api/Chair/release/{id}", null);
        }
    }
}
