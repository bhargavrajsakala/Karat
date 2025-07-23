using System;
using System.Xml; // Added for XmlDocument and XmlNode operations
 
public class ConfigReader
{
    private readonly XmlDocument _doc;
 
    public ConfigReader(string xmlPath)
    {
        _doc = new XmlDocument();
        _doc.Load(xmlPath);
    }
 
    public int GetInt(string key, int defaultValue)
    {
        string val = _doc.SelectSingleNode($"//setting[@key='{key}']")?.InnerText;
        return int.TryParse(val, out int result) ? result : defaultValue;
    }
 
    public bool GetBool(string key, bool defaultValue)
    {
        // Similar logic to GetInt, but using bool.TryParse
        string val = _doc.SelectSingleNode($"//setting[@key='{key}']")?.InnerText;
        return bool.TryParse(val, out bool result) ? result : defaultValue;
    }
 
    public DateTime GetDateTime(string key, DateTime defaultValue)
    {
        // Similar logic to GetInt, but using DateTime.TryParse
        string val = _doc.SelectSingleNode($"//setting[@key='{key}']")?.InnerText;
        return DateTime.TryParse(val, out DateTime result) ? result : defaultValue;
    }
 
    // Task for candidate: How would you design a method that safely converts
    // configuration values into correct types (bool, int, DateTime) with fallback defaults?
    // The methods above already address this directly by providing type-specific getters.
    // However, if the question implies a single, generic method, you could consider
    // a more advanced approach, but for simplicity and directness based on the existing
    // code structure, the current approach of having specific Get methods for each type is good.
 
    // If a more generic approach was desired, it would typically involve:
    // 1. A generic method `T GetValue<T>(string key, T defaultValue)`
    // 2. Using `Convert.ChangeType` or a series of `if-else if` with `TryParse` based on `typeof(T)`.
    //    However, `Convert.ChangeType` might not handle all custom formats as robustly as
    //    `TryParse` for specific types, and `TryParse` methods are not available generically.
    //    So, for this specific problem, having individual `GetInt`, `GetBool`, `GetDateTime` is
    //    a practical and safe solution that aligns with the partial code provided.
}