ProcessNext() calls _queue.Dequeue() to remove the next job from the queue.
This removed job is assigned to nextJob.
Then the code uses nextJob.Id and nextJob.Description to show what job is being processed.
 If the queue has jobs with:
Id=1, Description="Email sync"
Id=2, Description="Backup database"
Calling ProcessNext() removes job 1 from the queue and assigns it to nextJob.
Then nextJob.Id is 1, and nextJob.Description is "Email sync," which are used in the processing message, e.g.:
Processing job 1: Email sync   
scheduler.IsEmpty is a Boolean property that returns true if there are no jobs left in the queue.
while the scheduler is NOT empty," or "while there are jobs remaining."
 This calls the ProcessNext method on the scheduler, which:
Removes the next job from the queue.
Processes it (e.g., prints the job details).
Each call processes exactly one job in FIFO order.   


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

code : 
using System;
using System.Collections.Generic;

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
        _queue.Enqueue(job); // Enqueue the job
    }

    public void ProcessNext()
    {
        if (_queue.Count == 0)
        {
            Console.WriteLine("No jobs to process.");
            return;
        }

        Job nextJob = _queue.Dequeue(); // Dequeue next job
        Console.WriteLine($"Processing job {nextJob.Id}: {nextJob.Description}"); // Processing message
    }
}

class Program
{
    static void Main()
    {
        var scheduler = new JobScheduler();

        scheduler.AddJob(new Job { Id = 1, Description = "Email sync" });
        scheduler.AddJob(new Job { Id = 2, Description = "Backup database" });
        scheduler.AddJob(new Job { Id = 3, Description = "Generate reports" });

        scheduler.ProcessNext(); // Process job 1
        scheduler.ProcessNext(); // Process job 2

        // Process any remaining jobs
        while (!scheduler.IsEmpty)
        {
            scheduler.ProcessNext();
        }
    }
}



