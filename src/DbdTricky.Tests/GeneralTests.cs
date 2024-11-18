using DbdTricky.Lib.Common;
using Microsoft.Extensions.DependencyInjection;

namespace DbdTricky.Tests;

public class GeneralTests
{
    /// <summary>
    /// Make sure all clients are registered in <see cref="IDbdTrickyClient"/>.
    /// </summary>
    [Test]
    public void AllClients_ShouldBeRegistered()
    {
        var clients = typeof(IDbdTrickyClient).GetProperties();
        var actualClients = typeof(DbdTrickyBaseClient).Assembly.GetTypes()
            .Where(t => t is { IsClass: true, IsAbstract: false } && t.BaseType == typeof(DbdTrickyBaseClient))
            .ToList();
        
        Assert.Multiple(() =>
        {
            Assert.That(clients, Is.Not.Null);
            Assert.That(actualClients, Is.Not.Null);
        });

        Assert.That(actualClients, Has.Count.EqualTo(clients.Length));
    }
    
    /// <summary>
    /// Make sure that all clients that are registered in <see cref="IDbdTrickyClient"/> are also registered in the DI container.
    /// </summary>
    [Test]
    public void DependencyInjection_ShouldResolveAllClients()
    {
        var services = new ServiceCollection();
        services.AddDbdTricky();
        var serviceProvider = services.BuildServiceProvider();
        serviceProvider.GetRequiredService<IDbdTrickyClient>();
    }
}