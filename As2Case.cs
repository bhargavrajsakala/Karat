**1. Fix the Code – Singleton Not Working**

The following Singleton implementation creates multiple instances sometimes during multi-threaded execution.

**Task:** Fix the code to ensure proper *lazy* and *thread-safe* Singleton behavior.

```csharp
public class Logger
{
    private static Logger _instance;

    public static Logger Instance
    {
        get
        {
            if (_instance == null)
                _instance = new Logger(); // NOT thread safe
            return _instance;
        }
    }

    private Logger() { }
}
```

Requirements:

* Fix thread safety
* Ensure lazy initialization
* No external locking object allowed


public class Logger
{
   
    private static readonly Lazy<Logger> _instance = new Lazy<Logger>(() => new Logger());

    public static Logger Instance => _instance.Value;

    private Logger() { }
}

---

**2. Performance Issue – Inefficient Factory Lookup**

A poorly implemented Factory method uses repeated `if/else` checks for every request.

```csharp
public class PaymentFactory
{
    public IPayment GetPayment(string type)
    {
        if (type == "Card") return new CardPayment();
        else if (type == "UPI") return new UpiPayment();
        else if (type == "NetBanking") return new NetBanking();
        else if (type == "Card") return new CardPayment(); // repeated
        else return null;
    }
}
```

Requirements:

* Improve performance
* Avoid repeated condition checks
* Use a pattern-friendly approach (dictionary, reflection, registration list, etc.)

    public interface IPayment
{
    void Pay();
}

public class CardPayment : IPayment
{
    public void Pay() {  }
}

public class UpiPayment : IPayment
{
    public void Pay() {  }
}

public class NetBanking : IPayment
{
    public void Pay() {  }
}

public class PaymentFactory
{
    private Dictionary<string, IPayment> _payments = new Dictionary<string, IPayment>();

    public PaymentFactory()
    {
        _payments.Add("Card", new CardPayment());
        _payments.Add("UPI", new UpiPayment());
        _payments.Add("NetBanking", new NetBanking());
    }

    public IPayment GetPayment(string type)
    {
        if (_payments.ContainsKey(type))
            return _payments[type];

        return null;
    }
}


---

**3. Write a Small Program – Simple Repository Filter**

Write a small C# program that:

Requirements:

* Uses a `ProductRepository`
* Implements `GetProductsByCategory(string category)`
* Returns only matching products
* No database required; use in-memory list

using System;
using System.Collections.Generic;

class Product
{
    public string Name;
    public string Category;
}

class Repository
{
    List<Product> data = new List<Product>
    {
        new Product { Name = "Car", Category = "Toy" },
        new Product { Name = "Block", Category = "Toy" },
        new Product { Name = "Apple", Category = "Food" }
    };

    public List<Product> GetByCategory(string category)
    {
        List<Product> result = new List<Product>();
        foreach (var p in data)
        {
            if (p.Category == category)
                result.Add(p);
        }
        return result;
    }
}

class Program
{
    static void Main()
    {
        var repo = new Repository();
        var toys = repo.GetByCategory("Toy");
        foreach (var toy in toys)
            Console.WriteLine(toy.Name);
    }
}


---

**4. Fix the Failing Test Case – DI Misconfiguration**

A unit test fails because the DI container does not provide the correct service.

```csharp
[Test]
public void ShouldReturnDiscountedPrice()
{
    var services = new ServiceCollection();
    services.AddSingleton<IPriceCalculator, PriceCalculator>();

    var provider = services.BuildServiceProvider();
    var svc = provider.GetService<IPriceCalculator>();

    Assert.AreEqual(90, svc.Calculate(100)); // FAILS
}
```

Requirements:

* Identify why the test fails
* Fix the DI registration or implementation
* Modify only dependency or registration, not assert



------------------


**CASE STUDY 1 — Singleton + Factory Integration**

A system should only load configuration once using Singleton and use that configuration inside a Factory to create the correct handler.

Requirements:

* Implement `AppConfig` Singleton
* Implement `IHandler`, `EmailHandler`, `PushNotificationHandler`
* Implement `HandlerFactory`
* Complete the missing parts


```csharp
public sealed class AppConfig
{
    private static AppConfig _instance;
    public string HandlerType { get; private set; }

    private AppConfig()
    {
        // TODO: Hardcode HandlerType (e.g., "Email")
    }

    public static AppConfig Instance
    {
        get
        {
            // TODO: thread-safe instance
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
        // TODO: email logic
    }
}

public class PushNotificationHandler : IHandler
{
    public void Handle(string msg)
    {
        // TODO: push logic
    }
}

public static class HandlerFactory
{
    public static IHandler Create()
    {
        string type = /* TODO: Access from Singleton */;
        
        // TODO: return instance based on type
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
```

---

**CASE STUDY 2 — Repository + Dependency Injection**

Build a customer management service using DI.
Repository must be registered in DI and injected into the service.

Requirements:

* Implement Customer entity
* Implement `ICustomerRepository` and `InMemoryCustomerRepository`
* Register in DI
* Complete the missing sections
* Use repository inside `CustomerService`


```csharp
public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public interface ICustomerRepository
{
    void Add(Customer c);
    Customer Get(int id);
}

public class InMemoryCustomerRepository : ICustomerRepository
{
    private readonly List<Customer> _db = new();

    public void Add(Customer c)
    {
        // TODO
    }

    public Customer Get(int id)
    {
        // TODO
        return null;
    }
}

public class CustomerService
{
    private readonly ICustomerRepository _repo;

    public CustomerService(/* TODO: inject */)
    {
        // TODO
    }

    public void PrintCustomer(int id)
    {
        var customer = /* TODO */
        Console.WriteLine(/* TODO */);
    }
}

class Program
{
    static void Main(string[] args)
    {
        var builder = Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                // TODO: register repository + CustomerService
            });

        var app = builder.Build();

        var service = /* TODO: resolve */;
        service.PrintCustomer(1);
    }
}
