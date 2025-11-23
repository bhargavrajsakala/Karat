1.
  
  return amount > 0 : It means the payment will only succeed if the payment amount is greater than zero
 _strategy: This is a private field declared inside the class, used to hold a reference to an object implementing the IPaymentStrategy interface.
strategy: This is the parameter passed into the SetStrategy method. It represents a specific payment strategy instance (like CardPaymentStrategy, UpiPaymentStrategy, or WalletPaymentStrategy).
Assignment: The statement _strategy = strategy; copies the reference of the strategy object passed in into the _strategy field. It means the class now "remembers" the strategy to use.
Effect: Later when the PaymentContext calls _strategy.Pay(amount), it calls the Pay method of the specific strategy instance that was assigned here, dynamically changing the payment behavior.
 string? choice = Console.ReadLine() : So, string? choice means the variable choice may not have any typed text if the input is empty or canceled.
                                       In simple terms, the ? means the variable is allowed to be empty (null) or contain a string.   
break stops the switch to prevent running unintended code.

  

CASE STUDY 1— Strategy Pattern for Payment Processing

**Theme:** E-commerce checkout system
**Pattern:** Strategy Pattern
**Goal:** Dynamically switch payment logic at runtime.

---

*Requirement*

Implement a payment processing module where:

* Payment logic should be changeable at runtime via Strategy Pattern.
* Strategies include:

  * `CardPaymentStrategy`
  * `UPIPaymentStrategy`
  * `WalletPaymentStrategy`
* `PaymentContext` will select and execute the strategy.
* Complete the missing parts in the code below.


```csharp
public interface IPaymentStrategy
{
    bool Pay(double amount);
}

public class CardPaymentStrategy : IPaymentStrategy
{
    public bool Pay(double amount)
    {
        // TODO: Implement card payment logic
        return false;
    }
}

public class UpiPaymentStrategy : IPaymentStrategy
{
    public bool Pay(double amount)
    {
        // TODO: Implement UPI payment logic
        return false;
    }
}

public class WalletPaymentStrategy : IPaymentStrategy
{
    public bool Pay(double amount)
    {
        // TODO: Implement wallet deduction logic
        return false;
    }
}

public class PaymentContext
{
    private IPaymentStrategy _strategy;

    public void SetStrategy(IPaymentStrategy strategy)
    {
        // TODO: assign
    }

    public bool Execute(double amount)
    {
        // TODO: call strategy
        return false;
    }
}

class Program
{
    static void Main()
    {
        PaymentContext ctx = new PaymentContext();

        // TODO: Based on user input or config, set a strategy

        bool result = ctx.Execute(500);

        Console.WriteLine(result ? "Payment Success" : "Payment Failed");
    }
}
```

---

  
code :

 public interface IPaymentStrategy
{
    bool Pay(double amount);
}

public class CardPaymentStrategy : IPaymentStrategy
{
    public bool Pay(double amount)
    {
        // Dummy card payment validation and processing
        Console.WriteLine($"Processing Card payment for {amount}");
        // Assume success if amount > 0
        return amount > 0;
    }
}

public class UpiPaymentStrategy : IPaymentStrategy
{
    public bool Pay(double amount)
    {
        // Dummy UPI payment validation and processing
        Console.WriteLine($"Processing UPI payment for {amount}");
        return amount > 0;
    }
}

public class WalletPaymentStrategy : IPaymentStrategy
{
    public bool Pay(double amount)
    {
        // Dummy wallet balance check and deduction
        Console.WriteLine($"Processing Wallet payment for {amount}");
        return amount > 0;
    }
}
public class PaymentContext
{
    private IPaymentStrategy _strategy;

    public void SetStrategy(IPaymentStrategy strategy)
    {
        _strategy = strategy;
    }

    public bool Execute(double amount)
    {
        if (_strategy == null)
        {
            Console.WriteLine("No payment strategy selected.");
            return false;
        }

        return _strategy.Pay(amount);
    }
}

class Program
{
    static void Main()
    {
        PaymentContext ctx = new PaymentContext();

        Console.WriteLine("Select payment method: 1-Card, 2-UPI, 3-Wallet");
        string? choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                ctx.SetStrategy(new CardPaymentStrategy());
                break;
            case "2":
                ctx.SetStrategy(new UpiPaymentStrategy());
                break;
            case "3":
                ctx.SetStrategy(new WalletPaymentStrategy());
                break;
            default:
                Console.WriteLine("Invalid choice.");
                return;
        }

        bool result = ctx.Execute(500);

        Console.WriteLine(result ? "Payment Success" : "Payment Failed");
    }
}
 
