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

solution:
    public static List<int> FindIntersection(List<int> list1, List<int> list2) {
        return list1.Intersect(list2).ToList();

        Simple math:

Union = ALL numbers [1,2,3,4,5,6]  , Intersect = ONLY common [3,4] , Except = only in list1 [1,2]

Your code: list1.Intersect(list2) automatically:

Converts list2 to super-fast HashSet

Finds matching numbers from list1

Removes duplicates

Returns clean result




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

        solution:
        public static double CalculateDiscount(int age, bool isMember) {
    double memberDiscount = isMember ? 0.20 : 0.10;
    double adultDiscount = isMember ? 0.15 : 0.00;
    
    return age < 18 ? memberDiscount : adultDiscount;
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

        solution:
        
        public static List<string> ValidateUsernames(List<string> usernames) {
    List<string> valid = new List<string>();
    
    foreach(var name in usernames) {
        bool lengthOk = name.Length >= 5 && name.Length <= 10;
        bool noSpaces = !name.Contains(" ");
        
        if(lengthOk && noSpaces) {
            valid.Add(name);
        }
    }
    return valid;
}

        Split conditions into clear booleans instead of one long if
            >= 5 = At least 5 chars (not too short)
            <= 10 = Maximum 10 chars (not too long)





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


        solution:
  Use Span<T> when you need to perform operations on a portion of a string without allocating new memory.      
        

        public class Message
{
    public string Id { get; set; }
    public string Value { get; set; }

    public static Message Parse(ReadOnlySpan<char> csv)
    {
        var commaIndex = csv.IndexOf(',');
        var idSpan = csv.Slice(0, commaIndex);
        var valueSpan = csv.Slice(commaIndex + 1);
        
        return new Message 
        { 
            Id = idSpan.ToString().Trim(),
            Value = valueSpan.ToString().Trim()
        };
    }
}




performance tasks:



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

        solution:
        public static int SumEvenNumbers(int[] arr) {
    int sum = 0;
    for(int i = 0; i < arr.Length; i++) {
        if((arr[i] & 1) == 0) {  // Bitwise AND - faster than % for even arr[i]&1 == 0 and for odd simply !=0
            sum += arr[i];
        }
    }
    return sum;
}

        Even: (arr[i] & 1) == 0  // Last bit = 0
Odd:  (arr[i] & 1) != 0  // Last bit = 1 ✓

        LINQ ❌	Optimized ✅
Where() = 2 passes (filter + sum)	1 pass through array
x % 2 = division (slow CPU op)	arr[i] & 1 = bitwise (1 CPU cycle)




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



        2 solutions lazy or double checked lock

       1.     public sealed class Logger {
    private static readonly Lazy<Logger> _lazy = new Lazy<Logger>();
    
    public static Logger Instance => _lazy.Value;  // Thread-safe, lazy, ZERO locks after creation
    
    private Logger() { }
    
    public void Log(string message) {
        Console.WriteLine($"[{DateTime.Now}] {message}");
    }
}


        2.
            private static volatile Logger _instance;
private static readonly object _lock = new object();

public static Logger Instance {
    get {
        if (_instance == null) {                    // 1st fast check (no lock)
            lock (_lock) {
                if (_instance == null) {            // 2nd check (with lock)
                    _instance = new Logger();
                }
            }
        }
        return _instance;
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

    solution: 

    var companies = db.Companies.Where(...).ToList();

then my understanding was with adding tolist it executes http once, store in memory that one call only linq uses the in memory list
before it was 3+ calls count, take, concat all triger

**IEnumerable = Lazy promise** (executes every enumeration)
**ToList() = Force promise now** (materializes to memory)





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


   solution:
    Interlocked.Increment doesn't work with int? (nullable int)    

    public class Counter {
    private int _value = 0;
    public int? Value => _value == 0 ? null : _value;
    
    public void Increment() => Interlocked.Increment(ref _value);
    public void Decrement() => Interlocked.Decrement(ref _value);
}
    
