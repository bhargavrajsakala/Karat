using System;
class Calculator
{
    public int total = 0;
    public void AddInput(string input)
    {
        //int number = Convert.ToInt32(input); // Fails if input is not a valid number
        //int number;
        if (int.TryParse(input, out int number))
        {
            total += number;
            Console.WriteLine("Added " + number + ". Total is now " + total);
        }
        else
        {
            Console.WriteLine("Invalid input: '" + input + "'. Please enter a valid integer.");
        }
    }
}
class Program
{
    public static void Main(string[] args)
    {
        Calculator calc = new Calculator();
        calc.AddInput("20");
        calc.AddInput("abc"); // This crashes the program call
        calc.AddInput(""); // This also crashes the program
    }
}
