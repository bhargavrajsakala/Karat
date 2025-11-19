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

solution : 
using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    public static async Task<string> GetData()
    {
       
        string result = await Task.Run(() =>
        {
            Thread.Sleep(2000);
            return "Download complete";
        });
        return result;
    }
    static void Main()
{
    var msgTask = GetData();
    msgTask.Wait(); 
    Console.WriteLine(msgTask.Result);
}
}

explanation : So, use await to keep things smooth and non-blocking, and use Wait() only if you must pause everything and wait synchronously 
    Your GetData() method uses .Result (which is like Wait()), making the program stop and wait right there until the "download" completes (like standing at the counter).

In your Main(), when you do var msg = GetData(); Console.WriteLine(msg);, it just prints a "promise" (task) of the data,
 not the actual result, because it doesn't wait for the downloading to finish properly.


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

code :
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        int total = 0;
        List<string> words = new List<string> { "a", "bb", "ccc", "dddd" };

        Parallel.ForEach(words, w =>
        {
            Interlocked.Add(ref total, w.Length);
        });

        Console.WriteLine("Total letters = " + total);
    }
}


explanation :
Interlocked.Add : that even if many threads call this line simultaneously, the updates to total will never get mixed up or lost
Take the current value of the variable total (passed by reference using ref so the method can directly modify the original variable).
Atomically add w.Length (the length of the current word) to total.
Update total with this new sum in a thread-safe way, ensuring no other thread can interrupt or interfere during this add operation.
Interlocked is added to make sure that when multiple threads try to update the same number (like the total count), 
the updates happen one at a time without getting mixed up.

Imagine you have a single counter, and two people want to add to it at the same time:

Without Interlocked, both might read the current value at the same time (say it’s 5), 
then both add their number (like 3), and both try to write back 8. But really, the total should now be 11 (5 + 3 + 3).
 Because their actions overlapped, one update got lost.
 
 real:
 For example, a web server could use Interlocked to keep track of how many requests it has processed so far,
 incrementing the count safely every time a new request is handled by any thread



 ## **Q3. Fix the Deadlock – Locking Error**
The following code causes a deadlock in some scenarios:
```csharp
class Example
{ private object lock1 = new object();
    private object lock2 = new object();
public void MethodA()
    {lock (lock1)
        {Thread.Sleep(100);
            lock (lock2) { }}}
public void MethodB()
    {lock (lock2)
        {Thread.Sleep(100);
            lock (lock1) { }}}}
* Identify why deadlock happens.
* Refactor locking strategy to avoid circular dependency.
* Keep the two-method structure intact.



using System;
using System.Threading;

class Example
{
    private object lock1 = new object();
    private object lock2 = new object();

    public void MethodA()
    {
        lock (lock1)
        {
            Console.WriteLine("MethodA acquired lock1");
            Thread.Sleep(100);
            lock (lock2)
            {
                Console.WriteLine("MethodA acquired lock2");
                // Critical section
                Thread.Sleep(100);
            }
            Console.WriteLine("MethodA released lock2");
        }
        Console.WriteLine("MethodA released lock1");
    }

    public void MethodB()
    {
        lock (lock1) // Consistent order: first lock1, then lock2
        {
            Console.WriteLine("MethodB acquired lock1");
            Thread.Sleep(100);
            lock (lock2)
            {
                Console.WriteLine("MethodB acquired lock2");
                // Critical section
                Thread.Sleep(100);
            }
            Console.WriteLine("MethodB released lock2");
        }
        Console.WriteLine("MethodB released lock1");
    }
}

class Program
{
    static void Main()
    {
        var example = new Example();
        var threadA = new Thread(example.MethodA);
        var threadB = new Thread(example.MethodB);

        threadA.Start();
        threadB.Start();

        threadA.Join();
        threadB.Join();

        Console.WriteLine("Execution finished without deadlock.");
    }
}

exp :
in methodA first lock1 and then lock2 reverse in MethodB.
if thread 1 calls methodA and acquires lock1, then sleeps and acquires lock2.
At same time, thread 2 calls methodB reversly holds locks here both threads hold one thread and wait for other, 
causing a dependency and a dead lock.


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



solution : 
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> nums = new List<int> { 1, 2, 3, 4, 5, 6 };

        // Remove odd numbers using RemoveAll
        nums.RemoveAll(x => x % 2 != 0);
        
        Console.WriteLine(string.Join(", ", nums));  // Output: 2, 4, 6
    }
}

exp :
here in foreach index starts from 0 which is value 1 and it removes it in list which leads to mismatch of list ,
then while enumarator checks the list it was mismatch so it will throw exception.
instead of that write remove all method.
