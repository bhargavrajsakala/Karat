CASE STUDY 1 — Multi-Threaded Order Processing (Thread Safety + LINQ + File I/O)

### **Scenario**

You are working for an e-commerce company. Their system receives orders from multiple marketplace partners (Amazon, Flipkart, Meesho, etc.) in the form of text files. Each order is logged as one line:

```
<timestamp> <orderId> <customerId> <amount> <status>
```

Example:

```
20250121T10:22:11 ORD001 CUST09 1200.50 CREATED
20250121T10:22:12 ORD002 CUST01 899.99 CREATED
20250121T10:22:15 ORD001 CUST09 1200.50 DISPATCHED
20250121T10:22:20 ORD002 CUST01 899.99 CANCELLED
20250121T10:22:29 ORD003 CUST15 499.00 CREATED
```

A **complete order lifecycle** consists of:

* A **CREATED**
* Followed later by a **DISPATCHED** or **CANCELLED**

Multiple partner systems write logs concurrently. Your team built a service to process files in parallel, but you found **race conditions** due to improper shared-collection usage.

---

## **2-1) Fix the thread-safety issue in the following partially implemented class:**

```csharp
public class OrderProcessor
{
    private List<OrderEntry> entries = new List<OrderEntry>(); // THREAD-UNSAFE

    public void LoadOrdersParallel(List<string> filePaths)
    {
        Parallel.ForEach(filePaths, file =>
        {
            foreach (var line in File.ReadAllLines(file))
            {
                var order = new OrderEntry(line);
                entries.Add(order); // PROBLEM: Not thread-safe
            }
        });
    }

    public int CountCompleteOrders()
    {
        // A complete order = has CREATED and (DISPATCHED or CANCELLED)
        return entries
            .GroupBy(o => o.OrderId)
            .Count(g => g.Any(e => e.Status == "CREATED") &&
                        g.Any(e => e.Status == "DISPATCHED" || e.Status == "CANCELLED"));
    }
}
```

**Task:** Rewrite `LoadOrdersParallel()` to eliminate thread-safety issues using either:

* `ConcurrentBag<T>`
* `lock` block
* `Partitioner`
* or any other thread-safe structure.

Also provide the corrected full solution.

---

## **2-2) Write unit tests for CountCompleteOrders() using MSTest or NUnit.**

---

<br>

---
CASE STUDY 2 — Movie Streaming Analytics (Async I/O + LINQ + Classes + Validation)

### **Scenario**

A movie streaming platform logs user activity events in a text file where each line is:

```
<Timestamp> <UserId> <MovieId> <Action>
```

Actions:

* `STARTED`
* `PAUSED`
* `RESUMED`
* `COMPLETED`

A **valid movie watch session** is defined as:

* STARTED
* Zero or more PAUSED / RESUMED
* COMPLETED

Example:

```
20250121T14:00:01 U01 M10 STARTED
20250121T14:10:15 U01 M10 COMPLETED
20250121T15:00:01 U02 M11 STARTED
20250121T15:30:01 U02 M11 PAUSED
20250121T15:40:00 U02 M11 RESUMED
20250121T16:00:00 U02 M11 COMPLETED
```

---

## **2-1) Implement the following method asynchronously:**

```csharp
public class StreamLogService
{
    public async Task<List<UserSession>> LoadSessionsAsync(string filePath)
    {
        // TODO: Read file asynchronously, parse log lines,
        // group by (UserId + MovieId), determine valid sessions
        // and return List<UserSession>
    }
}
```

### Requirements:

✔ Use `async/await` with `File.ReadAllLinesAsync()`
✔ Use grouping with LINQ
✔ Validate session sequence in correct order (STARTED → ... → COMPLETED)
✔ Ignore corrupted or invalid sequences
✔ Return list of UserSession objects containing:

```csharp
public class UserSession
{
    public string UserId { get; set; }
    public string MovieId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}
```

---

## **2-2) Identify performance issues and propose improvements for scalability if the file size reaches 5–10GB.**

Your answer should mention:

* Streaming through file with `StreamReader.ReadLineAsync`
* Avoiding loading entire file into memory
* Using async I/O for throughput
* Using `ValueTask` where applicable
* Using `IAsyncEnumerable<string>` for pipeline processing

---
