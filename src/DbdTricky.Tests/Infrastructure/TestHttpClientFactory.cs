using System.Net;
using DbdTricky.Lib.Common;
using RichardSzalay.MockHttp;

namespace DbdTricky.Tests.Infrastructure;

public static class TestHttpClientFactory
{
    public static HttpClient CreateClient(string url, string? content = null, HttpStatusCode statusCode = HttpStatusCode.OK)
    {
        var handler = new MockHttpMessageHandler();
        
        if(content == null) handler.When(url).Respond(statusCode);
        else handler.When(url).Respond(statusCode, "application/json", content);
        
        var client = new HttpClient(handler);
        var configuration = new DbdTrickyConfiguration();
        client.BaseAddress = new Uri(configuration.BaseUrl);
        return client;
    }
}