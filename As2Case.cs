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
