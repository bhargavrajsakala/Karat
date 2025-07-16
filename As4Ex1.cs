using System; 
using System.Threading.Tasks; 
 public class Problem1  
 {  
     private async Task PerformLongRunningTaskAsync()  
     {  
         Console.WriteLine("Long-running task: Starting...");  
         await Task.Delay(3000);   
         Console.WriteLine("Long-running task: Completed!"); 
     }
     public static void Main(string[] args)   
     {  
         Console.WriteLine("Issue: Not handling async"); 
         Console.WriteLine("Main: Program starting.");  
 
         Problem1 program = new Problem1();  
         program.PerformLongRunningTaskAsync().GetAwaiter().GetResult();   
         Console.WriteLine("Main: Program ending.");  
     }  
 }