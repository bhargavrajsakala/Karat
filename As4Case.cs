using System; 
using System.Diagnostics; 
using System.IO; 
using System.Threading.Tasks; 

public class FixedAsyncIO { private static readonly string filePath = "async_io_solution.txt";
public async Task RunFixedScenario() 
{ 
    Console.WriteLine("\n✅ Asynchronous I/O in an Async Method -"); 
 
    Stopwatch sw = Stopwatch.StartNew(); 
 
    try 
    { 
        Console.WriteLine("Starting asynchronous file write..."); 
        await File.WriteAllTextAsync(filePath, "This data was written asynchronously.\n");  
        Console.WriteLine($"Success: Wrote data asynchronously. Elapsed: {sw.ElapsedMilliseconds}ms"); 
 
        Console.WriteLine("Starting asynchronous file read..."); 
        string content = await File.ReadAllTextAsync(filePath); 
        Console.WriteLine($"Read data asynchronously. Content: {content.Trim()}. Elapsed: {sw.ElapsedMilliseconds}ms"); 
    } 
    catch (Exception ex) 
    { 
        Console.WriteLine($"Async I/O error: {ex.Message}"); 
    } 
    finally 
    { 
        sw.Stop(); 
        if (File.Exists(filePath)) File.Delete(filePath); 
    } 
} 
 
public static async Task Main(string[] args) 
{ 
    await new FixedAsyncIO().RunFixedScenario(); 
    Console.WriteLine("\nFixed scenario complete. Notice non-blocking behavior."); 
} 
}