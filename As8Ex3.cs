using System;
using System.Collections.Generic;
using System.Linq;
 
public class ProblematicCollectionModification
{
    public static void Main(string[] args)
    {
        Console.WriteLine("--- Problematic Collection Modification ---");
 
        List<string> names = new List<string> { "Alice", "Bob", "Charlie", "David" };
 
        Console.WriteLine("Original list:");
        names.ForEach(n => Console.WriteLine($"{n}")); // Fixed string interpolation
        Console.WriteLine("\n");
 
        try
        {
            // Iterate over a copy of the list to avoid modifying the collection during enumeration
            foreach (string name in new List<string>(names))
            {
                if (name == "Bob")
                {
                    names.Remove(name); // Now, removing from the original list is safe
                }
                Console.WriteLine($"Processing: {name}");
            }
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Caught Expected Exception: {ex.Message}");
        }
 
        Console.WriteLine("\n--- End Collection Modification ---");
 
        Console.WriteLine("\nFinal list:");
        names.ForEach(n => Console.WriteLine($"{n}")); // Print the final state of the list
 
        Console.ReadKey();
    }
}