using ChairSetting.UI.Helpers;
using ChairSetting.UI.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.Text.Json;

namespace ChairSetting.UI.Services
{
    public class AuthService
    {
        private readonly HttpClient _http;
        private readonly IJSRuntime _js;
        private readonly AuthenticationStateProvider _authState;

        public AuthService(
            HttpClient http,
            IJSRuntime js,
            AuthenticationStateProvider authState)
        {
            _http = http;
            _js = js;
            _authState = authState;
        }

        //public async Task Login(LoginDto dto)
        //{
        //    var response = await _http.PostAsJsonAsync("api/Auth/login", dto);

        //    if (!response.IsSuccessStatusCode)
        //        throw new Exception("Invalid username or password");

        //    var result = await response.Content.ReadFromJsonAsync<JsonElement>();
        //    var token = result.GetProperty("token").GetString();

        //    await _js.InvokeVoidAsync("localStorage.setItem", "token", token);

        //    if (_authState is JwtAuthStateProvider jwt)
        //    {
        //        jwt.MarkJsReady();
        //    }
        //}
        public async Task Login(LoginDto dto)
        {
            var response = await _http.PostAsJsonAsync("api/Auth/login", dto);

            if (!response.IsSuccessStatusCode)
                throw new Exception("Invalid username or password");

            var result = await response.Content.ReadFromJsonAsync<JsonElement>();
            var token = result.GetProperty("token").GetString();

            if (_authState is not JwtAuthStateProvider jwt)
                throw new InvalidOperationException("AuthStateProvider is not JwtAuthStateProvider");

            await jwt.NotifyUserAuthentication(token!);
        }


        public async Task Signup(SignupDto dto)
        {
            await _http.PostAsJsonAsync("api/Auth/signup", dto);
        }

        public async Task Logout()
        {
            await _js.InvokeVoidAsync("localStorage.removeItem", "token");

            if (_authState is JwtAuthStateProvider jwt)
            {
                jwt.NotifyUserLogout();
            }
        }
    }

}
