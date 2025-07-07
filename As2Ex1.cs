using System;
public class Person 
{ 
    private int age; 
    public int Age { 
        get { return age; }
        set { age = value; } 
        } 
} 
public class Program 
{ public static void Main() 
{ Person p = new Person(); 
p.Age = 30; 
Console.WriteLine("Person's Age: " + p.Age); 
} 
}