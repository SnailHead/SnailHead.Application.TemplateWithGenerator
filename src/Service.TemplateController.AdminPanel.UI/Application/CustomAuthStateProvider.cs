using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace Service.TemplateController.AdminPanel.UI.Application;

public class CustomAuthStateProvider : AuthenticationStateProvider
{
    private readonly ILocalStorageService _localStorage;

    public CustomAuthStateProvider(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    public override async Task<AuthenticationState?> GetAuthenticationStateAsync()
    {
        string token = await _localStorage.GetItemAsync<string>("access_token");

        if (string.IsNullOrWhiteSpace(token))
        {
            return new AuthenticationState(new ClaimsPrincipal());
        }
        
        token = token.Trim('"');
        
        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);
        var identity = new ClaimsIdentity(jwtToken.Claims, "jwt", JwtRegisteredClaimNames.Name, "role");
        
        string? expClaim = identity.Claims.FirstOrDefault(item => item.Type == "exp")?.Value;
        bool parseExp = int.TryParse(expClaim, out int exp);
        if (string.IsNullOrEmpty(expClaim) && !parseExp) return new AuthenticationState(new ClaimsPrincipal());
        
        DateTime expireDate = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        expireDate = expireDate.AddSeconds(exp);
        if (expireDate <= DateTime.UtcNow)
        {
            await _localStorage.RemoveItemAsync("access_token");
            return new AuthenticationState(new ClaimsPrincipal());
        }

        var user = new ClaimsPrincipal(identity);
        var state = new AuthenticationState(user);

        NotifyAuthenticationStateChanged(Task.FromResult(state));

        return state;
    }
}
