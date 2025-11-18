Section 1: Small Coding Questions (4 Questions)**

(Including threading, async, tasks, parallel loops, thread safety)

---

## **Q1. Fix the Code – Task and Async/Await Issue**

The following method is intended to download data asynchronously, but the output prints before the data is ready.

```csharp
public static async Task<string> GetData()
{
    Task<string> t = Task.Run(() =>
    {
        Thread.Sleep(2000);
        return "Download complete";
    });

    return t.Result;
}

static void Main()
{
    var msg = GetData();
    Console.WriteLine(msg);
}
```

**Requirements:**

* Identify the async/await issue.
* Fix the method so asynchronous flow works correctly.
* Ensure no blocking on `.Result` or `.Wait()`.

---

## **Q2. Debug the Code – Parallel.ForEach Not Working Correctly**

The code below counts words in parallel but produces incorrect totals.

```csharp
int total = 0;
List<string> words = new List<string> { "a", "bb", "ccc", "dddd" };

Parallel.ForEach(words, w =>
{
    total += w.Length;
});

Console.WriteLine("Total letters = " + total);
```

**Requirements:**

* Identify why the result is inconsistent.
* Ensure thread-safe accumulation.
* Fix the code using any safe construct (lock, Interlocked, thread-safe collections).

---

## **Q3. Fix the Deadlock – Locking Error**

The following code causes a deadlock in some scenarios:

```csharp
class Example
{
    private object lock1 = new object();
    private object lock2 = new object();

    public void MethodA()
    {
        lock (lock1)
        {
            Thread.Sleep(100);
            lock (lock2) { }
        }
    }

    public void MethodB()
    {
        lock (lock2)
        {
            Thread.Sleep(100);
            lock (lock1) { }
        }
    }
}
```

**Requirements:**

* Identify why deadlock happens.
* Refactor locking strategy to avoid circular dependency.
* Keep the two-method structure intact.

---

## **Q4. Fix the Code – List Modified While Enumerating**

This code attempts to remove odd numbers but throws an exception:

```csharp
List<int> nums = new List<int> { 1, 2, 3, 4, 5, 6 };

foreach (var n in nums)
{
    if (n % 2 == 1)
        nums.Remove(n);
}

Console.WriteLine(string.Join(", ", nums));
```

**Requirements:**

* Fix removal logic without exceptions.
* Preserve original intention: remove odd numbers.
* Keep memory usage minimal.

---

**Section 2: Case Studies (2 Questions)**

**Case Study 1: Event Processing System With Tasks + async/await + File I/O**

### **Scenario:**

You are building a system that processes event messages asynchronously and logs results to a file. Events come from a collection and must be processed using asynchronous methods + thread-safe logging.

---

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

class EventProcessor
{
    private readonly object fileLock = new object();

    public async Task<string> ProcessEventAsync(string evt)
    {
        // TODO:
        // 1. Simulate async processing (Task.Delay)
        // 2. Transform event string to upper case
        // 3. Return processed result

        throw new NotImplementedException();
    }

    public void LogResult(string path, string result)
    {
        // TODO:
        // 1. Use StreamWriter in append mode
        // 2. Ensure thread-safe access using fileLock
        // 3. Write result to file

        throw new NotImplementedException();
    }
}

class Program
{
    static async Task Main()
    {
        List<string> eventsList = new List<string>
        {
            "login",
            "click",
            "purchase",
            "logout"
        };

        EventProcessor processor = new EventProcessor();

        // TODO:
        // 1. Process all events using Task.WhenAll
        // 2. Log each processed event result
        // 3. Ensure no race condition in file writing

        Console.WriteLine("All events processed.");
    }
}
```

---

### **Requirements:**

* Implement async event processing with Task.Delay
* Process all events concurrently using `Task.WhenAll`
* Use thread-safe logging with `lock`
* Use StreamWriter in append mode
* Avoid race conditions and inconsistent writes

---

**Case Study 2: Order Calculation Engine Using Parallel.ForEach + Thread Safety + Delegates**

### **Scenario:**

You run a high-performance order processing pipeline.
There are thousands of orders processed in parallel using `Parallel.ForEach`.
Each order uses a **delegate-based pricing rule** to compute a final amount.

Your job: complete the program ensuring:
✔ Thread-safety
✔ Correct pricing
✔ Summary calculations using atomic operations
✔ No shared-state corruption


```csharp
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

public delegate double PricingRule(double amount);

class Order
{
    public int Id { get; set; }
    public double Amount { get; set; }
}

class OrderEngine
{
    public ConcurrentBag<double> FinalAmounts = new ConcurrentBag<double>();
    public int ProcessedCount = 0;

    public double ApplyPricingRule(Order order, PricingRule rule)
    {
        // TODO:
        // 1. Apply rule and return final amount
        throw new NotImplementedException();
    }

    public void ProcessOrders(IEnumerable<Order> orders, PricingRule rule)
    {
        // TODO:
        // 1. Use Parallel.ForEach to process orders concurrently
        // 2. For each order:
        // a) Apply pricing rule
        // b) Add final amount to FinalAmounts thread-safely
        // c) Increment ProcessedCount using Interlocked
        throw new NotImplementedException();
    }
}

class Program
{
    static void Main()
    {
        List<Order> orders = new List<Order>
        {
            new Order { Id = 1, Amount = 1000 },
            new Order { Id = 2, Amount = 1500 },
            new Order { Id = 3, Amount = 2000 }
        };

        PricingRule discountRule = amt => amt * 0.85; // 15% discount

        OrderEngine engine = new OrderEngine();

        // TODO:
        // 1. Run ProcessOrders
        // 2. Print total processed count
        // 3. Print all final amounts
        // 4. Print sum of all final amounts using LINQ

        Console.WriteLine("Order processing complete.");
    }
}
```

---

### **Requirements:**

* Use `Parallel.ForEach`
* Ensure thread-safety using:

  * `ConcurrentBag<T>`
  * `Interlocked.Increment`
* Apply delegate pricing rule
* Summarize results safely
