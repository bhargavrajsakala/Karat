using System;  
 public class Base 
 { 
     public virtual void Display() 
     { 
         Console.WriteLine("Base"); 
     } 
 } 
 
 public class Derived : Base 
 { 
     public override void Display()  
     { 
         Console.WriteLine("Derived"); 
     }
     } 
 
 public class Program 
 { 
     public static void Main(string[] args) 
     { 
         Console.WriteLine("--- After Fix (Method Overriding Behavior) ---"); 
         Base b2 = new Derived(); 
         b2.Display(); 
 
         Derived d2 = new Derived(); 
         d2.Display(); 
     } 
 }