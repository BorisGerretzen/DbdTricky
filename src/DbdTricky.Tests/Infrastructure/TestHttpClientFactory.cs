using System.Net;
using DbdTricky.Lib.Common;
using RichardSzalay.MockHttp;

namespace DbdTricky.Tests.Infrastructure;

public static class TestHttpClientFactory
{
    private const string BaseUrl = "https://dbd.tricky.lol/api";
    
    public static HttpClient CreateClient(string url, string? content = null, HttpStatusCode statusCode = HttpStatusCode.OK)
    {
        var handler = new MockHttpMessageHandler();
        
        if(content == null) handler.When(BaseUrl + url).Respond(statusCode);
        else handler.When(BaseUrl + url).Respond(statusCode, "application/json", content);
        
        var client = new HttpClient(handler);
        var configuration = new DbdTrickyConfiguration();
        client.BaseAddress = new Uri(configuration.BaseUrl);
        return client;
    }
}