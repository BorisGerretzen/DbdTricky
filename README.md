# DbdTricky.Net

[![NuGet](https://img.shields.io/nuget/v/DbdTricky.Lib.svg)](https://www.nuget.org/packages/DbdTricky.Lib/)

This project is not affiliated with Dead by Daylight or with https://dbd.tricky.lol.

A .NET library for interacting with the Dead by Daylight API provided by https://dbd.tricky.lol 
to quickly retrieve perks, characters, stats, and more! 
All endpoints listed [here](https://dbd.tricky.lol/api/) are supported.

## Usage

### With dependency injection
```csharp
// When using dependency injection
var services = new ServiceCollection();
services.AddDbdTricky();
var sp = services.BuildServiceProvider();

var dbdTrickyClient = sp.GetRequiredService<IDbdTrickyClient>();

// Retrieve all dwight's perks, all endpoints are async and support cancellation tokens
var perks = await dbdTrickyClient.Perks.GetPerks("dwight", cancellationToken: default);
```

### Without dependency injection

```csharp
// Use defaults from DbdTrickyConfiguration for creating the HttpClient
var configuration = new DbdTrickyConfiguration();
var http = new HttpClient {
    BaseAddress = new Uri(configuration.BaseUrl),;
    DefaultRequestHeaders.Add("User-Agent", configuration.UserAgent);
};

// Create the client and retrieve all dwight's perks
var perksClient = new DbdTrickyPerksClient(http);
var perks = await perksClient.GetPerks("dwight", cancellationToken: default);
```

### Configuration
```csharp
var configuration = new DbdTrickyConfiguration {
    BaseUrl = new Uri("https://dbd.tricky.lol/api/"),
    UserAgent = "DbdTricky.Lib",
    ApiKey = "your-api-key" // I don't know how API keys work here, does nothing for now
};

// Add the service with the configuration created above, leave it empty to use the defaults
services.AddDbdTricky(configuration: configuration);

// You can also configure the HttpClient directly, note that you do need to set the BaseAddress and UserAgent headers.
services.AddDbdTricky(client => {
    // Use default configuration
    var conf = new DbdTrickyConfiguration();
    client.BaseAddress = new Uri(conf.BaseUrl);
    client.DefaultRequestHeaders.Add("User-Agent", conf.UserAgent);
    
    // Whatever you want to do with the HttpClient
    client.Timeout = TimeSpan.FromSeconds(10);
    client.AddPolicyHandler(Policy
        .HandleResult<HttpResponseMessage>(r => r.StatusCode == HttpStatusCode.TooManyRequests)
        .WaitAndRetryAsync(3, i => TimeSpan.FromSeconds(Math.Pow(2, i)))
    );
});
```