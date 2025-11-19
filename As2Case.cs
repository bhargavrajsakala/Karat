using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

class EventProcessor
{
    private readonly object fileLock = new object();

    public async Task<string> ProcessEventAsync(string evt)
    {
        // Simulate async processing delay
        await Task.Delay(500);
        // Transform event string to upper case
        string processed = evt.ToUpper();
        return processed;
    }

    public void LogResult(string path, string result)
    {
        // Use lock to ensure thread-safe file access
        lock (fileLock)
        {
            using (StreamWriter writer = new StreamWriter(path, append: true))
            {
                writer.WriteLine(result);
            }
        }
    }
}

class Program
{
    static async Task Main()
    {
        List<string> eventsList = new List<string> { "login", "click", "purchase", "logout" };
        EventProcessor processor = new EventProcessor();
        string logFilePath = "eventlog.txt";

        // Process all events concurrently
        Task<string>[] processingTasks = new Task<string>[eventsList.Count];
        for (int i = 0; i < eventsList.Count; i++)
        {
            processingTasks[i] = processor.ProcessEventAsync(eventsList[i]);
        }

        string[] results = await Task.WhenAll(processingTasks);

        // Log each processed result sequentially (no race conditions due to lock)
        foreach (string result in results)
        {
            processor.LogResult(logFilePath, result);
        }

        Console.WriteLine("All events processed.");
    }
}



2.


 using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
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
        // Apply the delegate pricing rule to the order amount safely
        return rule(order.Amount);
    }

    public void ProcessOrders(IEnumerable<Order> orders, PricingRule rule)
    {
        Parallel.ForEach(orders, order =>
        {
            double finalAmount = ApplyPricingRule(order, rule);
            FinalAmounts.Add(finalAmount);
            Interlocked.Increment(ref ProcessedCount);
        });
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

        // Run processing
        engine.ProcessOrders(orders, discountRule);

        // Print total processed count
        Console.WriteLine($"Total processed orders: {engine.ProcessedCount}");

        // Print all final amounts
        Console.WriteLine("Final amounts:");
        foreach (var amount in engine.FinalAmounts)
        {
            Console.WriteLine(amount);
        }

        // Print sum of all final amounts using LINQ
        double sum = engine.FinalAmounts.Sum();
        Console.WriteLine($"Sum of final amounts: {sum}");

        Console.WriteLine("Order processing complete.");
    }
}
