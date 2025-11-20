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

---

**3. Write a Small Program – Simple Repository Filter**

Write a small C# program that:

Requirements:

* Uses a `ProductRepository`
* Implements `GetProductsByCategory(string category)`
* Returns only matching products
* No database required; use in-memory list

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
