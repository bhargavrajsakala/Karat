using System;
using System.Collections.Generic;
 
public class ConfigurationManager
{
    private static readonly Lazy<ConfigurationManager> instance =
        new Lazy<ConfigurationManager>(() => new ConfigurationManager());
 
    private readonly Lazy<Dictionary<string, string>> configData =
        new Lazy<Dictionary<string, string>>(() => LoadConfiguration());
 
    private ConfigurationManager() {}
 
    public static ConfigurationManager Instance => instance.Value;
 
    public string GetValue(string key)
    {
        return configData.Value.ContainsKey(key) ? configData.Value[key] : null;
    }
 
    private static Dictionary<string, string> LoadConfiguration()
    {
        Console.WriteLine("Loading configuration...");
        return new Dictionary<string, string>
        {
{ "Url", "https://instagram.com" },
            { "Key", "ABC123" }
        };
    }
}
class Program
{
    static void Main()
    {
        var value = ConfigurationManager.Instance.GetValue("Url");
        Console.WriteLine(value);
    }
}