using System.Reflection;

namespace DbdTricky.Tests.Infrastructure;

public static class ResourceReader
{
    private const string BaseNamespace = "DbdTricky.Tests.Resources";
    public static string Read(string resourceName)
    {
        var assembly = Assembly.GetExecutingAssembly();
        resourceName = $"{BaseNamespace}.{resourceName}";
        using var stream = assembly.GetManifestResourceStream(resourceName);
        if(stream == null) throw new ArgumentException($"Resource {resourceName} not found");
        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }
}