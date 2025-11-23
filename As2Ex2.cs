_stock = newStock; 
means that the value of the parameter newStock passed to the SetStock method is being assigned to the private field _stock.
Why this assignment is done:
_stock is a private variable inside the Inventory class that holds the current stock quantity.
newStock is the new value that someone wants to set for the stock.
When SetStock is called with a new stock value, the assignment updates the internal _stock field to that new value.
Calls the NotifyObservers method on the current object (an instance of Inventory).
Passes a string message into that method. This string is created using string interpolation (the $"" syntax) which inserts the current value of _stock into the message. For example, if _stock is 5, the message becomes "Stock is low: 5 items left."
Inside the NotifyObservers method, this message is sent to all attached observers by calling their Update methods.
Observers call Attach on the subject to register themselves.
The subject adds them to the _observers list.
When the subject’s state (e.g., stock count) changes and meets a condition, it calls NotifyObservers.
NotifyObservers loops through the _observers list and calls Update on each observer.
This triggers each observer’s individual response to the update.
    
    
CASE STUDY 2— Observer Pattern for Inventory Notifications

**Theme:** Stock Management
**Pattern:** Observer (Publisher–Subscriber)
**Goal:** Notify different departments when inventory level changes.

---

*Requirement*

Implement an inventory tracking system where:

* `Inventory` acts as the **Subject**.
* Observers include:

  * `WarehouseNotifier`
  * `BillingNotifier`
  * `MobileAppNotifier`
* When stock drops below threshold, all observers must be notified.
* Complete the missing parts in the code below.

---


```csharp
public interface IObserver
{
    void Update(string message);
}

public interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void NotifyObservers(string msg);
}

public class Inventory : ISubject
{
    private List<IObserver> _observers = new();
    private int _stock;

    public void SetStock(int newStock)
    {
        _stock = newStock;
        
        if (_stock < 10)
        {
            // TODO: notify observers
        }
    }

    public void Attach(IObserver observer)
    {
        // TODO
    }

    public void Detach(IObserver observer)
    {
        // TODO
    }

    public void NotifyObservers(string msg)
    {
        // TODO
    }
}

public class WarehouseNotifier : IObserver
{
    public void Update(string message)
    {
        // TODO: show message
    }
}

public class BillingNotifier : IObserver
{
    public void Update(string message)
    {
        // TODO
    }
}

public class MobileAppNotifier : IObserver
{
    public void Update(string message)
    {
        // TODO
    }
}

class Program
{
    static void Main()
    {
        var inventory = new Inventory();

        // TODO: attach observers

        inventory.SetStock(5); // triggers notification
    }
}
```

code :

using System;
using System.Collections.Generic;

public interface IObserver
{
    void Update(string message);
}

public interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void NotifyObservers(string msg);
}

public class Inventory : ISubject
{
    private List<IObserver> _observers = new();
    private int _stock;

    public void SetStock(int newStock)
    {
        _stock = newStock;

        if (_stock < 10)
        {
            NotifyObservers($"Stock is low: {_stock} items left.");
        }
    }

    public void Attach(IObserver observer)
    {
        if (!_observers.Contains(observer))
            _observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        if (_observers.Contains(observer))
            _observers.Remove(observer);
    }

    public void NotifyObservers(string msg)
    {
        foreach (var observer in _observers)
        {
            observer.Update(msg);
        }
    }
}

public class WarehouseNotifier : IObserver
{
    public void Update(string message)
    {
        Console.WriteLine($"Warehouse Notification: {message}");
    }
}

public class BillingNotifier : IObserver
{
    public void Update(string message)
    {
        Console.WriteLine($"Billing Notification: {message}");
    }
}

public class MobileAppNotifier : IObserver
{
    public void Update(string message)
    {
        Console.WriteLine($"Mobile App Notification: {message}");
    }
}

class Program
{
    static void Main()
    {
        var inventory = new Inventory();

        // Attach observers
        inventory.Attach(new WarehouseNotifier());
        inventory.Attach(new BillingNotifier());
        inventory.Attach(new MobileAppNotifier());

        // Set stock to trigger notification
        inventory.SetStock(5);
    }
}

