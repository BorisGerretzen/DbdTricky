using System.Net;
using System.Text;
using System.Text.Json;

namespace DbdTricky.Lib.Common;

public class DbdTrickyBaseClient
{
    private readonly HttpClient _http;

    protected DbdTrickyBaseClient(HttpClient http)
    {
        _http = http;
        _http.BaseAddress ??= new Uri("https://dbd.tricky.lol/api/");
    }
    
    protected async Task<T?> GetOrDefault<T>(string endpoint, Dictionary<string, string?>? parameters, CancellationToken cancellationToken = default)
    {
        var queryString = GetQueryString(parameters);
        var url = endpoint + (string.IsNullOrWhiteSpace(queryString) ? "" : $"?{queryString}");
        var response = await _http.GetAsync(url, cancellationToken);
        if (response.StatusCode == HttpStatusCode.NotFound) return default;
        response.EnsureSuccessStatusCode();
        
        var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
        return await JsonSerializer.DeserializeAsync<T>(stream, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        }, cancellationToken: cancellationToken);
    }

    protected async Task<T> Get<T>(string endpoint, Dictionary<string, string?>? parameters, CancellationToken cancellationToken = default)
    {
        var response = await GetOrDefault<T>(endpoint, parameters, cancellationToken);
        return response ?? throw new InvalidOperationException("Resource not found");
    }

    private static string? GetQueryString(Dictionary<string, string?>? parameters)
    {
        if (parameters == null) return null;
        var sb = new StringBuilder();
        var i = 0;
        
        foreach(var (key, value) in parameters)
        {
            sb.Append(key);
            if(value != null) sb.Append('=').Append(value);
            if(i++ < parameters.Count - 1) sb.Append('&');
        }
        
        return sb.ToString();
    }
}