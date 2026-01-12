/*
You are given a function that calculates the intersection of two lists of integers. The current implementation uses nested loops and has O(n*m) time complexity. Refactor it to improve readability and efficiency using built-in C# data structures.
*/
using System;
using System.Collections.Generic;

public class Program {
    public static void Main() {
        var list1 = new List<int>{1,2,3,4};
        var list2 = new List<int>{3,4,5,6};
        var result = FindIntersection(list1, list2);
        Console.WriteLine(string.Join(",", result));
    }

    public static List<int> FindIntersection(List<int> list1, List<int> list2) {
        List<int> result = new List<int>();
        foreach(var a in list1) {
            foreach(var b in list2) {
                if(a == b && !result.Contains(a)) {
                    result.Add(a);
                }
            }
        }
        return result;
    }
}




/*
The following code determines the discount for a customer. It is correct but hard to read. Refactor it to improve readability without changing behavior.
*/
using System;

public class Program {
    public static void Main() {
        Console.WriteLine(CalculateDiscount(16, true));   // 0.2
        Console.WriteLine(CalculateDiscount(20, false));  // 0.0
    }

    public static double CalculateDiscount(int age, bool isMember) {
        if(age < 18) return isMember ? 0.2 : 0.1;
        return isMember ? 0.15 : 0.0;
    }
}






/*
The following function validates a list of usernames. It repeats similar checks multiple times. Refactor to reduce code duplication.
*/
using System;
using System.Collections.Generic;

public class Program {
    public static void Main() {
        var usernames = new List<string>{"Alice", "Bob123", "John Doe", "Anna"};
        var valid = ValidateUsernames(usernames);
        Console.WriteLine(string.Join(",", valid));
    }

    public static List<string> ValidateUsernames(List<string> usernames) {
        List<string> valid = new List<string>();
        foreach(var name in usernames) {
            if(name.Length >= 5 && name.Length <= 10 && !name.Contains(" ")) {
                valid.Add(name);
            }
        }
        return valid;
    }
}




/*
You need to process thousands of CSV-formatted messages per second.The current code parses each message using string.Split(',') and creates an object for each message.How would you optimize this code for high-throughput scenarios?
*/
public class Message
{
    public string Id { get; set; }
    public string Value { get; set; }

    public static Message Parse(string csv)
    {
        var parts = csv.Split(',');
        return new Message { Id = parts[0], Value = parts[1] };
    }
}




performance:



/*
Sum all even numbers in a large integer array. Current code uses LINQ but is slow for very large arrays. Optimize for performance.
*/
using System;
using System.Linq;

public class Program {
    public static void Main() {
        int[] arr = {1,2,3,4,5,6};
        Console.WriteLine(SumEvenNumbers(arr)); // 12
    }

    public static int SumEvenNumbers(int[] arr) {
        return arr.Where(x => x % 2 == 0).Sum();
    }
}





/*
Compute the nth Fibonacci number. The naive recursive solution is very slow for n > 40. Optimize using memoization or iterative approach.
*/
using System;

public class Program {
    public static void Main() {
        Console.WriteLine(Fibonacci(10)); // 55
    }

    public static int Fibonacci(int n) {
        if(n <= 1) return n;
        int a = 0, b = 1;
        for(int i = 2; i <= n; i++) {
            int temp = a + b;
            a = b;
            b = temp;
        }
        return b;
    }
}




/*
Concatenating many strings using '+' is slow. Optimize the code using a more efficient method for large n.
*/
using System;
using System.Text;

public class Program {
    public static void Main() {
        Console.WriteLine(ConcatNumbers(10)); // 0123456789
    }

    public static string ConcatNumbers(int n) {
        var sb = new StringBuilder();
        for(int i = 0; i < n; i++) {
            sb.Append(i.ToString());
        }
        return sb.ToString();
    }
        }



/*
The snippet shows that the performance of getting the Instance is slow. What is the cause of performance degradation? How would you fix it
*/
public static Singleton Instance {
private Singleton (){}

private static readonly object Lock = new Object();

private static Singleton instance;

public static Singleton instance

{ 
get
{ lock (Lock) 
 { 
if (instance == null)
 { 
instance = new Singleton();
 }
 }
  return instance; 
  }
}

public void Log(string message)
 {
 Console.WriteLine($"[{DateTime.Now}] {message}");
  }
  }
   // Usage example
    public class Program
     {
     public static void Main() 
     { 
     Parallel.For(0, 10, i =>
{
         Logger.Instance.Log($"Log message {i}"); 
         }); 
         }
          }



/*
The following code uses a microservice to retrieve a list of companies' data. While profiling the code, we have observed that the microservice is being called multiple times when `GetReportableCompanies` is invoked.
*/
public class CompanyInfo
{
public Guid Id { get; set; }
public string Name { get; set; }
public string Description { get; set; }
public bool IsVip { get; set; }
}
public class CompanyService
{
private const int MaxReportableCompanies = 100;
private readonly HttpClient _httpClient;
public CompanyService(HttpClient httpClient)
{
_httpClient = httpClient;
}
public IEnumerable<CompanyInfo> GetReportableCompanies()
{
var companies = GetCompanyInfoList();
if (!companies.Any()) return Array.Empty<CompanyInfo>();
var vipCompanies = companies.Where(c => c.IsVip);
if (vipCompanies.Count() > MaxReportableCompanies)
{
return vipCompanies.Take(MaxReportableCompanies);
}
var nonVipReportableCompanies = companies
.Where(c => !c.IsVip)
.Where(c => c.Description.Contains("REPORT"));
return vipCompanies.Concat(nonVipReportableCompanies.Take(MaxReportableCompanies - vipCompanies.Count()));
}
private List<CompanyInfo> GetCompanyInfoList()
{
var text = _httpClient.GetStringAsync("/").Result;
var csvLines = text.Split(Environment.NewLine);
foreach (var csvLine in csvLines)
{
yield return ParseCompanyInfo(csvLine);
}
}
private static CompanyInfo ParseCompanyInfo(string csvLine)
{
var parts = csvLine.Split(',');
return new CompanyInfo
{
Id = Guid.Parse(parts[0]),
Name = parts[1],
Description = parts[2],
IsVip = bool.Parse(parts[3])
 
};
}





 /*
You are implementing a thread-safe counter using Interlocked.Increment and Interlocked.Decrement.However, sometimes your code throws a NullReferenceException.Why does this happen, and how can you fix it
*/
public class Counter
{
    public int? Value = 0;

    public void Increment()
    {
        Interlocked.Increment(ref Value);
    }

    public void Decrement()
    {
        Interlocked.Decrement(ref Value);
    }
}
}
