using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
 
// This class demonstrates a problematic counter susceptible to race conditions
public class ProblematicCounter
{
    private int counter = 0;
 
    // Public method to get the current counter value
    public int GetCounter()
    {
        return counter;
    }
 
    // This operation is not atomic and can lead to race conditions
    // It involves three steps:
    // 1) Read counter (from memory into a register)
    // 2) Increment counter (in a register)
    // 3) Write counter back to memory
    // If Thread A reads counter, then Thread B reads the same counter value
    // before Thread A writes back, both threads will increment based on the old value,
    // and one update will be lost.
    public void Increment()
    {
        counter++;
    }
}
 
// This class demonstrates a race condition with a shared variable
public class RaceConditionDemonstration
{
    public static void Main(string[] args)
    {
        Console.WriteLine("\n--- Race Condition with Shared Variable ---\n");
 
        ProblematicCounter counter = new ProblematicCounter();
        const int iterations = 100000; // A large number to highlight the issue
 
        // Create multiple tasks to increment the counter concurrently
        Task[] tasks = new Task[5];
 
        for (int i = 0; i < tasks.Length; i++)
        {
            tasks[i] = Task.Run(() =>
            {
                for (int j = 0; j < iterations; j++)
                {
                    counter.Increment();
                }
            });
        }
 
        // Wait for all tasks to complete
        Task.WaitAll(tasks);
 
        // Display results
        Console.WriteLine($"Expected counter value: {iterations * tasks.Length}");
        Console.WriteLine($"Actual counter value: {counter.GetCounter()}");
        Console.WriteLine($"Difference: {(iterations * tasks.Length) - counter.GetCounter()}");
 
        Console.WriteLine("\n--- End Race Condition Demonstration ---\n");
        Console.ReadKey(); // Keep console open until a key is pressed
    }
}