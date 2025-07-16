using System; 

using System.Threading.Tasks; 
public class Issue1_Problem 
{ 
    private async Task<string> GetStringAfterDelayAsync() 
    { 
        await Task.Delay(1000); // Waits for 1 second 
        return "Data after delay"; 
    } 
    public async Task RunProblemScenario() 
    { 
        Console.WriteLine("Issue 1 ---"); 
        Console.WriteLine("Start Fetching Data (Proper way)..."); 
        // ✅ CORRECT: Awaiting Task.Delay directly 
        await Task.Delay(2000); 
        Console.WriteLine("Waited for 2 seconds using await Task.Delay"); 
        Console.WriteLine("Main thread was NOT blocked here."); 
        // ✅ Properly calling an async method that returns a string 
        Task<string> dataTaskB = GetStringAfterDelayAsync(); 
        Console.WriteLine($"Problem B: dataTaskB Status: {dataTaskB.Status}"); 
        string resultB = await dataTaskB;
         Console.WriteLine($"Result from GetStringAfterDelayAsync(): {resultB}"); 
        Console.WriteLine("End Fetching Data"); 
    } 
    public static async Task Main(string[] args) 
    { 
        await new Issue1_Problem().RunProblemScenario(); 
    } 
} 