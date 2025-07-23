using System;
using System.Collections.Generic;
using System.Linq;
 
public class Product
{
    public string Name { get; set; }
    public double Price { get; set; }
}
 
public class ProductAnalyzer
{
    public void Analyze(List<Product> products)
    {
        // Materialize the filtered list once to avoid multiple enumerations
        List<Product> expensiveProducts = products.Where(p => p.Price > 1000).ToList();
 
        // Now, perform Count and Average on the already filtered list
        Console.WriteLine("Expensive Count: " + expensiveProducts.Count());
 
        // Check if there are any expensive products before calculating the average
        // to avoid a runtime error (e.g., if expensiveProducts is empty)
        if (expensiveProducts.Any())
        {
            Console.WriteLine("Average Price: " + expensiveProducts.Average(p => p.Price));
        }
        else
        {
            Console.WriteLine("No expensive products found, average price cannot be calculated.");
        }
    }
}
 
public class Program
{
    static void Main(string[] args)
    {
        var products = new List<Product>
        {
            new Product { Name = "Laptop", Price = 1200 },
            new Product { Name = "Tablet", Price = 950 },
            new Product { Name = "Monitor", Price = 1300 },
            new Product { Name = "Mouse", Price = 50 } // Added from first image
        };
 
        var analyzer = new ProductAnalyzer();
        analyzer.Analyze(products);
 
        // Keep console open
        Console.WriteLine("\nPress any key to exit.");
        Console.ReadKey();
    }
}