Section 1: Small Coding Questions (4 Questions)
Q1. Fix the Code – Nullable Types & Conditionals
The following code throws a runtime error. Identify the issue and modify it so that it works correctly with nullable types.
int? value = null;
if (value > 10)
{
    Console.WriteLine("Greater than 10");
}
else
{
    Console.WriteLine("Not greater");
}
Requirements:
Fix the null handling.
Ensure no exception is thrown.
Output should make logical sense for nullable values.

    explanation: code because it tries to compare a nullable variable directly to an integer without handling the case when the variable may be null.
        In C#, attempting to evaluate something like value > 10 when value is null does not throw an exception directly, but it creates confusion.
    It first checks if there is a valid number (value.HasValue).
If not, it prints "Value is null" to indicate no comparison can be made.
If value is present, it then makes a safe comparison for "Greater than 10."
solution : 
int? value = null;
if (value.HasValue && value > 10)
{
    Console.WriteLine("Greater than 10");
}
else if (!value.HasValue)
{
    Console.WriteLine("Value is null");
}
else
{
    Console.WriteLine("Not greater");
}


    
Q2. Debug the Code – Wrong Output With Arrays & Loops
The following program is expected to print the sum of all items in the array but prints the wrong result.
int[] numbers = { 2, 4, 6, 8 };
int sum = 0;
 
foreach (int n in numbers)
{
    sum = n;
}
 
Console.WriteLine("Sum: " + sum);
Requirements:
Identify the bug.
Correct the logic to accumulate the sum.
Maintain the same loop type unless necessary.

    explanation :  inside the loop, it uses sum = n; instead of sum += n;. This means each time the loop runs, it overwrites sum with the current value of n, 
        so only the last element of the array is stored in sum by the end of the loop
        Assume the array is {2, 4, 6, 8}:
replace sum = n with sum = sum + n; or += n

With sum = n;:

Iteration 1: sum becomes 2

Iteration 2: sum becomes 4

Iteration 3: sum becomes 6

Iteration 4: sum becomes 8

Final output: Sum: 8

Intended output should be: Sum: 20

Why sum += n; Works
Each pass adds the current value of n to the running total (sum).

Iteration 1: sum = 0 + 2 = 2

Iteration 2: sum = 2 + 4 = 6

Iteration 3: sum = 6 + 6 = 12

Iteration 4: sum = 12 + 8 = 20

Final output: Sum: 20, which is correct
    
Q3. Fix the Bug – Dictionary & Access Modifiers
You are given a ProductCatalog class:
class ProductCatalog
{
    private Dictionary<int, string> products;
 
    public ProductCatalog()
    {
        products = new Dictionary<int, string>();
    }
 
    public string GetProduct(int id)
    {
        return products[id];
    }
}
The following code crashes when a product ID doesn't exist.
Requirements:
Modify the class to safely access products.
Prevent runtime exceptions.
Use appropriate dictionary APIs or checks.
No changes to class usage allowed.

  explanation:
If the id does not exist in the dictionary, this will throw a KeyNotFoundException at runtime, causing the program to crash. 
    This approach does not check whether the key is present before trying to access the value.
TryGetValue approach: The corrected code uses products.TryGetValue(id, out string product), which checks for key existence and only retrieves the value if present.
Prevents runtime exceptions: By using this check, you avoid application crashes and can instead return a default value or message.    
    
    solution :

using System;
using System.Collections.Generic;


    class ProductCatalog
    {
        private Dictionary<int, string> products;

        public ProductCatalog()
        {
            products = new Dictionary<int, string>();
            products.Add(1, "Apple");
        }

        public string GetProduct(int id)
        {
            if (products.TryGetValue(id, out string product))
                return product;
            else
                return "Product not found";
        }
    }

    class Program
    {
        static void Main()
        {
            ProductCatalog catalog = new ProductCatalog();
            Console.WriteLine(catalog.GetProduct(1));    
            Console.WriteLine(catalog.GetProduct(2));   
        }
    }

TryGetValue: This method belongs to Dictionary, and is used to safely try to fetch the value for a given key. 
    It returns a bool: true if the key was found, false otherwise.
        
out string product: The keyword out means the variable will receive the value if the key is found. 
    If not, the variable will get the default value for its type (null for strings).


    
Q4. Threading Concept – Identify Issue With Task Execution
The following code is expected to print numbers 1 to 5 using tasks, but the output is inconsistent:
for (int i = 1; i <= 5; i++)
{
    Task.Run(() =>
    {
        Console.WriteLine(i);
    });
}
Requirements:
Identify why the output is unpredictable.
Fix the threading issue related to loop variables.
Ensure numbers 1–5 print correctly.

 Explanation : Here, each Task.Run uses the same i variable from the loop.
The lambda expression does not capture the value of i at the time the task is created; it captures the reference to the same i. 
If you want each task to work with its own value of i, the lambda must capture the value at the time of iteration, not after the loop.

 solution : 
for (int i = 1; i <= 5; i++)
{
    int local = i;  
    Task.Run(() =>
    {
        Console.WriteLine(local); 
    });
}

    
Section 2: Case Study Questions (2 Questions)
Case Study 1: Student Management & LINQ Processing
Scenario:
A system stores students with fields:
Id
Name
Marks (List)
You need to implement the following features:
Requirements:
Create a Student class with proper encapsulation.
Write a method to calculate each student’s average marks.
Using LINQ:
Filter students whose average marks are above 75.
Sort them by name.
Handle any exceptions related to empty marks list or null lists.
Print the final list of students with their average marks.

    solution : 

using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    // Fields with encapsulation through properties
    public int Id { get; set; }
    public string Name { get; set; }
    private List<int> marks;

    // Property to encapsulate marks with safety check
    public List<int> Marks
    {
        get => marks ?? new List<int>();
        set => marks = value ?? new List<int>();
    }

    // Constructor
    public Student(int id, string name, List<int> marks)
    {
        Id = id;
        Name = name;
        Marks = marks;
    }

    // Method to calculate average marks safely
    public double CalculateAverageMarks()
    {
        if (Marks == null || Marks.Count == 0)
        {
            throw new InvalidOperationException($"Student {Name} has no marks to calculate average.");
        }
        return Marks.Average();
    }

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}";
    }
}

public class Program
{
    public static void Main()
    {
        // Example students list including some with empty or null marks
        List<Student> students = new List<Student>
        {
            new Student(1, "Alice", new List<int> {90, 85, 88}),
            new Student(2, "Bob", new List<int> {70, 65}),
            new Student(3, "Charlie", new List<int>()),    // empty marks
            new Student(4, "David", null),                  // null marks
            new Student(5, "Eva", new List<int> {80, 78, 82})
        };

        try
        {
            var filteredSortedStudents = students
                .Where(s =>
                {
                    try
                    {
                        return s.CalculateAverageMarks() > 75;
                    }
                    catch
                    {
                        // Handle cases with empty or null marks lists by excluding student
                        return false;
                    }
                })
                .OrderBy(s => s.Name)
                .Select(s => new
                {
                    Student = s,
                    AverageMarks = s.CalculateAverageMarks()
                });

            // Print final list
            foreach (var item in filteredSortedStudents)
            {
                Console.WriteLine($"{item.Student.Name} has average marks: {item.AverageMarks:F2}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error occurred: " + ex.Message);
        }
    }
}

    
Case Study 2: File Processing + OOP + Delegates
Scenario:
You are building a mini framework that:
Reads text lines from a log file
Applies transformation logic using delegates
Stores results in a collection and prints them
Requirements:
Implement a class LogProcessor with:
A delegate TransformLine(string input)
A method ProcessFile(string path, TransformLine transformer)
Read file contents using File or StreamReader.
Use the delegate to transform each line (e.g., uppercase, prefix timestamp, etc.).
Store processed lines in a List<string>.
Handle I/O exceptions using try–catch-finally.
Demonstrate two different transformations by passing different delegate functions.

    solution : 
using System;
using System.Collections.Generic;
using System.IO;

public class LogProcessor
{
    // Delegate definition for transforming a line of text
    public delegate string TransformLine(string input);

    // List to store processed lines
    private List<string> processedLines = new List<string>();

    // Method to process file line-by-line using the provided delegate transformer
    public void ProcessFile(string path, TransformLine transformer)
    {
        StreamReader reader = null;
        try
        {
            reader = new StreamReader(path);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                // Apply transformation delegate and store result
                string transformed = transformer(line);
                processedLines.Add(transformed);
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine($"IO Exception occurred: {ex.Message}");
        }
        finally
        {
            // Ensure the stream is closed properly
            if (reader != null)
            {
                reader.Close();
            }
        }
    }

    // Method to print all processed lines
    public void PrintProcessedLines()
    {
        foreach (var line in processedLines)
        {
            Console.WriteLine(line);
        }
    }
}

// Example usage with two different transformations
public class Program
{
    public static void Main(string[] args)
    {
        LogProcessor processor = new LogProcessor();

        // Transformation 1: Convert each line to uppercase
        LogProcessor.TransformLine toUpper = input => input.ToUpper();

        // Transformation 2: Prefix each line with current timestamp
        LogProcessor.TransformLine addTimestamp = input =>
            $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {input}";

        string filePath = "samplelog.txt";  // Update this to your log file path

        // Process file with uppercase transformation
        Console.WriteLine("Processing with Uppercase Transformation:");
        processor.ProcessFile(filePath, toUpper);
        processor.PrintProcessedLines();

        Console.WriteLine("\nProcessing with Timestamp Prefix Transformation:");

        // Clear processed lines before re-processing with different transformation
        // Note: processedLines is private, so recreate processor instance to demo a clean slate
        processor = new LogProcessor();
        processor.ProcessFile(filePath, addTimestamp);
        processor.PrintProcessedLines();
    }
}

