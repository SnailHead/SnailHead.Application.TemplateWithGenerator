using System.Net;
using System.Text.Json;

namespace Service.TemplateController.AdminPanel.Application.Helpers;

public static class ResponseContentParse
{
    public static async Task<T> ReadContentAsync<T>(this HttpResponseMessage content)
    {
        try
        {
            if (content is null || content.StatusCode == HttpStatusCode.InternalServerError)
            {
                return default;
            }
            var responseString = await content.Content.ReadAsStringAsync();
            var response = JsonSerializer.Deserialize<T>(responseString);
            return response;
        }
        catch (Exception e)
        {
            return default;
        }
    }
}