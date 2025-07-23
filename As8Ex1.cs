using System;
using System.Threading;
using System.Threading.Tasks;
 
public sealed class ProblematicSingleton // Changed to sealed as good practice for singletons
{
    private static volatile ProblematicSingleton instance; // Added 'volatile'
    private static readonly object lockObject = new object(); // New lock object
 
    private ProblematicSingleton()
    {
        Console.WriteLine("ProblematicSingleton instance created.");
    }
 
    public static ProblematicSingleton Instance
    {
        get
        {
            if (instance == null) // First check (no lock)
            {
                lock (lockObject) // Acquire lock
                {
                    if (instance == null) // Second check (inside lock)
                    {
                        // Removed Task.Delay(100).Wait() as it's not needed in a correct implementation
                        instance = new ProblematicSingleton();
                    }
                }
            }
            return instance;
        }
    }
 
    public void ShowMessage(string message)
    {
        Console.WriteLine($"Singleton message: {message}");
    }
}
 
public class SingletonDemonstration
{
    public static void Main(string[] args)
    {
        Console.WriteLine("--- Problematic Singleton Demonstration-1---");
 
        Parallel.Invoke(
            () => ProblematicSingleton.Instance.ShowMessage("Hello from Thread 1"),
            () => ProblematicSingleton.Instance.ShowMessage("Hello from Thread 2"),
            () => ProblematicSingleton.Instance.ShowMessage("Hello from Thread 3")
        );
 
        Console.WriteLine("\n--- end Singleton Demonstration ---\n");
        Console.ReadKey();
    }
}