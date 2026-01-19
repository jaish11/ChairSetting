using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ChairSetting.UI.Helpers
{
    public class JwtAuthStateProvider : AuthenticationStateProvider
    {
        private readonly IJSRuntime _js;
        private bool _jsReady;

        public JwtAuthStateProvider(IJSRuntime js)
        {
            _js = js;
        }

        // Called ONCE after first render
        public void MarkJsReady()
        {
            if (_jsReady) return;

            _jsReady = true;
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            if (!_jsReady)
            {
                return new AuthenticationState(
                    new ClaimsPrincipal(new ClaimsIdentity()));
            }

            var token = await _js.InvokeAsync<string>(
                "localStorage.getItem", "token");

            if (string.IsNullOrWhiteSpace(token))
            {
                return new AuthenticationState(
                    new ClaimsPrincipal(new ClaimsIdentity()));
            }

            var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);
            var identity = new ClaimsIdentity(jwt.Claims, "jwt");

            return new AuthenticationState(new ClaimsPrincipal(identity));
        }

        // SAFE token getter
        public async Task<string?> GetTokenSafely()
        {
            if (!_jsReady)
                return null;

            return await _js.InvokeAsync<string>(
                "localStorage.getItem", "token");
        }

        public async Task NotifyUserAuthentication(string token)
        {
            if (_jsReady)
            {
                await _js.InvokeVoidAsync("localStorage.setItem", "token", token);
            }

            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }


        public async Task NotifyUserLogout()
        {
            if (_jsReady)
            {
                await _js.InvokeVoidAsync("localStorage.removeItem", "token");
            }

            NotifyAuthenticationStateChanged(
                Task.FromResult(
                    new AuthenticationState(
                        new ClaimsPrincipal(new ClaimsIdentity())
                    )
                )
            );
        }

    }
}
