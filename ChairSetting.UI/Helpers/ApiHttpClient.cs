using System.Net.Http.Headers;
using Microsoft.AspNetCore.Components.Authorization;

namespace ChairSetting.UI.Helpers
{
    public class ApiHttpClient
    {
        private readonly HttpClient _http;
        private readonly JwtAuthStateProvider _auth;

        public ApiHttpClient(
            HttpClient http,
            AuthenticationStateProvider authState)
        {
            _http = http;
            _auth = (JwtAuthStateProvider)authState;
        }

        public async Task<HttpClient> CreateClientAsync()
        {
            _http.DefaultRequestHeaders.Authorization = null;

            var token = await _auth.GetTokenSafely();

            if (!string.IsNullOrEmpty(token))
            {
                _http.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
            }

            return _http;
        }
    }
}
