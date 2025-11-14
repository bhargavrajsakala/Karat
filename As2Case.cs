using System;
using System.Collections.Generic;

// Abstract base class
public abstract class SubscriberBase
{
    public abstract void OnNotificationReceived(string message);
}

// EmailSubscriber class
public class EmailSubscriber : SubscriberBase
{
    public override void OnNotificationReceived(string message)
    {
        Console.WriteLine($"EmailSubscriber: Received update - {message}");
    }
}

// SMSSubscriber class
public class SMSSubscriber : SubscriberBase
{
    public override void OnNotificationReceived(string message)
    {
        Console.WriteLine($"SMSSubscriber: Received update - {message}");
    }
}

// Publisher class using events and delegates
public class Publisher
{
    public delegate void NotificationDelegate(string message);
    public event NotificationDelegate NotificationEvent;

    public List<SubscriberBase> Subscribers { get; } = new List<SubscriberBase>();

    public void AddSubscriber(SubscriberBase subscriber)
    {
        NotificationEvent += subscriber.OnNotificationReceived;
        Subscribers.Add(subscriber);
    }

    public void RemoveSubscriber(SubscriberBase subscriber)
    {
        NotificationEvent -= subscriber.OnNotificationReceived;
        Subscribers.Remove(subscriber);
    }

    public void SendNotification(string message)
    {
        NotificationEvent?.Invoke(message);
    }
}

// Demonstration
class Program
{
    static void Main(string[] args)
    {
        Publisher publisher = new Publisher();

        // Create subscribers dynamically
        EmailSubscriber emailSubscriber = new EmailSubscriber();
        SMSSubscriber smsSubscriber = new SMSSubscriber();

        // Add subscribers
        publisher.AddSubscriber(emailSubscriber);
        publisher.AddSubscriber(smsSubscriber);

        // Send a notification (Publisher triggers event)
        publisher.SendNotification("Stock Price Changed");

        // Remove an email subscriber dynamically
        publisher.RemoveSubscriber(emailSubscriber);
        publisher.RemoveSubscriber(smsSubscriber);


        // Send another notification
        publisher.SendNotification("Market Closed");}
}
