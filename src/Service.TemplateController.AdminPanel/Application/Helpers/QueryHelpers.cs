using System.Text;

namespace Service.TemplateController.AdminPanel.Application.Helpers;

public static class QueryHelpers
{
    public static string AddQueryString(string route,  Dictionary<string, object?> queryParametersDictionary)
    {
        if (queryParametersDictionary is null)
            return route;
        var stringBuilder = new StringBuilder(route);
        
        if (stringBuilder[^1] != '?')
            stringBuilder.Append('?');
        
        foreach (var item in queryParametersDictionary)
        {
            if (item.Value is null)
            {
                continue;
            }
            stringBuilder.Append($"{item.Key}={item.Value}&");
        }
        
        if (stringBuilder[^1] == '&')
            stringBuilder.Remove(stringBuilder.Length - 1, 1);
        return stringBuilder.ToString();
    }
}