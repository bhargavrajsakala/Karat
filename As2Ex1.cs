using System;

public sealed class AppConfig
{
    private static readonly object _lock = new object();
    private static AppConfig _instance;

    public string HandlerType { get; private set; }

    private AppConfig()
    {
        // Hardcoding handler type for this example
        HandlerType = "Email"; 
    }

    public static AppConfig Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new AppConfig();
                    }
                }
            }
            return _instance;
        }
    }
}

public interface IHandler
{
    void Handle(string msg);
}

public class EmailHandler : IHandler
{
    public void Handle(string msg)
    {
        // Simulate email sending logic
        Console.WriteLine($"EmailHandler: Sending email with message: {msg}");
    }
}

public class PushNotificationHandler : IHandler
{
    public void Handle(string msg)
    {
        // Simulate push notification logic
        Console.WriteLine($"PushNotificationHandler: Sending push notification with message: {msg}");
    }
}

public static class HandlerFactory
{
    public static IHandler Create()
    {
        string type = AppConfig.Instance.HandlerType;

        if (type == "Email")
        {
            return new EmailHandler();
        }
        else if (type == "PushNotification")
        {
            return new PushNotificationHandler();
        }
        else
        {
            throw new InvalidOperationException($"Unknown handler type: {type}");
        }
    }
}

class Program
{
    static void Main()
    {
        var handler = HandlerFactory.Create();
        handler.Handle("Welcome!");
    }
}
