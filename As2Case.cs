Explanation: 

System.io namespace used to perform input and output operations while working on files. 

Filepath: represent the name of csv file 

File.ReadLines() method is used to read all the lines efficiently from the respective file. 

Used foreach to iterate over each line in the file. 

Line.Split(‘,’) : breaks the line into its individual data fields by splitting where a comma occurs, splitting the line into parts is essential to convert the raw data into a structured data (in array format of strings) . 

I  have created the instance for Employee class and used employees.Add() method to add this newly created Employee object to the list called employees. Here we are converting the raw data to stuctured format. 

Employees.GroupBy.(e => e.Department) : employees is a collection (list) of Employee details. 

 Here groupby is used to group employees by their department property.each group represented by key. 

Like if you have employees from hr,it,sales , groupby creates 3 groups keyed by those department names. 

Select(g => new { Department = g.Key, AverageSalary = g.Average(e => e.Salary) :  

 

Here e is one employee obj at a time as the groupby method loops. 

Here g represents a group of items created by groupby method. Each g is a collection of employees who belongs to the same department. 

Here g.key tells you which department the employees inside the group belong to. 

Here i am taking average of all salaries e => e.Salary use salary property of each employee in the group to compute the average. 

 

Difference b/w csv and txt :  

Csv uses commas to seperate fields. 

Best because it enables structured data processing with easy parsing of rows and columns. 

Txt read them like plain text. 

                      Best because it supports flexible and simple free text format storage, no parsing constraints needed. 


    2.
    Delegate: it is a type safe function pointer that allows methods to be reffered and invoked dynamically. It provides a way to treat methods as objects enabling senarios like event handling and function styling. 

 

Event : an event is a notification sent by an obj to signal the occurance of an action. 

 

Delegates defines what type of notification methods you can use. 

String meassage : the delegate defines the signature of methods it can reference, this means any method assigned to this delegate must accept string parameter call message. 

Event allows many methods to subscribe for notification and lets publisher trigger them all together. 

Here i used list that stores subscriberbase objects(sms/email subscribers) i used gettter because only publisher class should modify the list. 

I implemented add and remove methods with subscriber as parameter of type SubscriberBase. 

Notification += subscriber.onnotificationreceived : adds subscribers method to the event list to receive notification. 

Notification -= subscriber.onnotificationreceived : removes subscribers method from event so it wont receive notification. 

Here onnotificationreceived methods are subscribers methods. They are assigned to delegate because their signature matchs it.when the event is raised these, methods are invoked to handle the notification.subscriber methods are event handler methods that get assigned to delegate to react to notification from publisher. 

Then i am checking notification event  not null then pass the string msg to the each subscriber method. Null means no subscribers 

Real time example :  

The delegate is the blue print specifying the type of methods allowed as subscribers to the event. Like string message 

The event builds on delegate managing the actual list of such methods that will be called when news is published.event holds a list of subscribers methods which confirm the delegatetype allows subscribers to add or remove by themselves 

When news company publishes news it raises the event which calls all subscriber methods in the list. 


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

explanation:

Getter (get):
The getter checks if the internal list marks is null. If it is null, it returns a new empty list instead of returning null. 
    This avoids possible null reference exceptions in client code that accesses Marks. If marks is not null, it returns the actual list.

Setter (set):
The setter accepts a value and checks if it's null.
    If the incoming value is null, it initializes marks to an empty list instead of null. Otherwise, it sets marks to the provided list.
    This ensures the internal marks field never becomes null, preserving class invariants.
        Why overriding ToString() is important:
It gives a meaningful, human-readable string that summarizes the object (like "Id: 1, Name: Alice").
 The Average() method is used to calculate the average (arithmetic mean) of the numbers in a collection  
 Where filters a collection based on a condition. Only students who satisfy the condition will be kept.
    OrderBy sorts the filtered students based on a key, here the student’s name in alphabetical order.
    For each student s in the collection, a new anonymous object is created with two properties:
Student = s : This property holds the entire current student object.
AverageMarks = s.CalculateAverageMarks() : This property holds the average marks for the current student, calculated by calling the method CalculateAverageMarks().

    
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

