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
CASE STUDY 1 — Task Scheduler Using Queue (FIFO)

**Concepts:** Queue, basic classes, simple scheduling
**Theme:** Job processing / background workers

Requirements

Implement a lightweight job scheduler where:

* Incoming tasks are stored in a **Queue**.
* The scheduler processes tasks in FIFO order.
* Each task has:

  * `Id`
  * `Description`
* When the user calls `ProcessNext()`, the scheduler should:

  * Dequeue next job
  * Process it (console output)
* Complete missing pieces in the half-implemented code.


```csharp
public class Job
{
    public int Id { get; set; }
    public string Description { get; set; }
}

public class JobScheduler
{
    private Queue<Job> _queue = new Queue<Job>();

    public void AddJob(Job job)
    {
        // TODO: enqueue job
    }

    public void ProcessNext()
    {
        // TODO: check if queue empty
        // TODO: dequeue next job
        // TODO: print processing message
    }
}

class Program
{
    static void Main()
    {
        var scheduler = new JobScheduler();

        scheduler.AddJob(new Job { Id = 1, Description = "Email sync" });
        scheduler.AddJob(new Job { Id = 2, Description = "Backup database" });

        // TODO: call ProcessNext twice  
        // TODO: process remaining jobs
    }
}
```

CASE STUDY 2 Custom Linked List + Stack for Undo/Redo System

**Concepts:** Custom LinkedList, Stack, navigating nodes
**Theme:** Text editor undo/redo functionality

Requirements

Implement a simple text editor model where:

* A **custom singly linked list** stores text history snapshots.
* An **Undo stack** and **Redo stack** manage navigation.
* When text changes:

  * Push previous state onto **Undo Stack**
* On Undo:

  * Pop from Undo, push current state to Redo
* On Redo:

  * Pop from Redo, restore state

Complete missing parts in the code.


```csharp
// Custom node-based linked list for tracking text states
public class TextNode
{
    public string State;
    public TextNode Next;
}

public class TextHistory
{
    public TextNode Head;

    public void AddState(string state)
    {
        // TODO: append node at end
    }

    public TextNode GetLatest()
    {
        // TODO: return last node in list
        return null;
    }
}

public class Editor
{
    private TextHistory _history = new TextHistory();
    private Stack<string> _undoStack = new Stack<string>();
    private Stack<string> _redoStack = new Stack<string>();
    private string _currentText = "";

    public void Type(string newText)
    {
        // TODO: push current text to undo stack
        // TODO: update text, add to history
    }

    public void Undo()
    {
        // TODO: move current state to redo, restore from undo
    }

    public void Redo()
    {
        // TODO: move current state to undo, restore from redo
    }

    public void Print()
    {
        Console.WriteLine("Current text: " + _currentText);
    }
}

class Program
{
    static void Main()
    {
        var editor = new Editor();

        editor.Type("Hello");
        editor.Type("Hello World");

        editor.Undo(); // Should go back to "Hello"
        editor.Redo(); // Should go to "Hello World"

        // TODO: print final text
    }
}
```

