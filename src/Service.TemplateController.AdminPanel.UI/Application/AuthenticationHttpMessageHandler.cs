using System.Net.Http.Headers;
using Blazored.LocalStorage;
using Microsoft.Extensions.Caching.Memory;

namespace Service.TemplateController.AdminPanel.UI.Application;

public sealed class AuthenticationHttpMessageHandler : DelegatingHandler
{
    private readonly ILocalStorageService _localStorage;
    private readonly IMemoryCache _memoryCache;

    public AuthenticationHttpMessageHandler(ILocalStorageService localStorage, IMemoryCache memoryCache)
    {
        _localStorage = localStorage;
        _memoryCache = memoryCache;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        //TODO: check expiration
        await AddBearerTokenAsync(request, cancellationToken);
        return await base.SendAsync(request, cancellationToken);
        
    }

    private async Task AddBearerTokenAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        _memoryCache.TryGetValue("access_token", out string token);
        //var token = await _localStorage.GetItemAsStringAsync("access_token", cancellationToken);
        if (token is null)
        {
            return;
        }
        token = token.Trim('\"');

        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }
}