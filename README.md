# DbdTricky.Net

[![NuGet](https://img.shields.io/nuget/v/DbdTricky.Net.svg)](https://www.nuget.org/packages/DbdTricky.Net/)\
A .NET library for interacting with https://dbd.tricky.lol/api endpoints.
With this library you can easily retrieve e.g. a list of all perks, items, characters, player statistics and more!

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
var http = new HttpClient {
    BaseAddress = new Uri("https://dbd.tricky.lol/api/");
    DefaultRequestHeaders.Add("User-Agent", "DbdTricky.Lib");
};
var perksClient = new DbdTrickyPerksClient(http);
var perks = await perksClient.GetPerks("dwight", cancellationToken: default);
```

### Configuration

When using DI you can configure the `HttpClient` directly or use the `DbdTrickyConfiguration` parameter to configure
some basic properties.

```csharp
var configuration = new DbdTrickyConfiguration {
    BaseUrl = new Uri("https://dbd.tricky.lol/api/"),
    UserAgent = "DbdTricky.Lib",
    ApiKey = "your-api-key" // I don't know how API keys work for this API, but you can set it anyways
};

// Configure the HttpClient manually, note that this overwrites configuration applied using DbdTrickyConfiguration.
services.AddDbdTricky(configuration, configureClient: client => {
    client.Timeout = TimeSpan.FromSeconds(10);
    client.AddPolicyHandler(Policy
        .HandleResult<HttpResponseMessage>(r => r.StatusCode == HttpStatusCode.TooManyRequests)
        .WaitAndRetryAsync(3, i => TimeSpan.FromSeconds(Math.Pow(2, i)))
    );
});
```

## Supported endpoints

| Supported Endpoints    | Not Supported Endpoints   |
|------------------------|---------------------------|
| ✅ `/addons`            | ⬜️ `/gamemodes`           |
| ✅ `/addoninfo`         | ⬜️ `/killswitch`          |
| ✅ `/archives`          | ⬜️ `/leaderboardposition` |
| ✅ `/characters`        | ⬜️ `/playeradepts`        |
| ✅ `/characterinfo`     | ⬜️ `/playerstats`         |
| ✅ `/customizations`    |                           |
| ✅ `/customizationinfo` |                           |
| ✅ `/dlc`               |                           |
| ✅ `/events`            |                           |
| ✅ `/items`             |                           |
| ✅ `/iteminfo`          |                           |
| ✅ `/journals`          |                           |
| ✅ `/maps`              |                           |
| ✅ `/mapinfo`           |                           |
| ✅ `/offerings`         |                           |
| ✅ `/offeringinfo`      |                           |
| ✅ `/patchnotes`        |                           |
| ✅ `/perkinfo`          |                           |
| ✅ `/perks`             |                           |
| ✅ `/playercount`       |                           |
| ✅ `/randomcharacter`   |                           |
| ✅ `/randomperks`       |                           |
| ✅ `/rankreset`         |                           |
| ✅ `/rift`              |                           |
| ✅ `/shrine`            |                           |
| ✅ `/topstats`          |                           |
| ✅ `/versions`          |                           |
