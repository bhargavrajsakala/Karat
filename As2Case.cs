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
