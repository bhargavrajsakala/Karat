using System;
 
public class InputProcessor
{
    public void HandleInput(string input)
    {
        // Try to parse the input as a long (Int64).
        // long.TryParse returns true if the parsing is successful, false otherwise.
        // The parsed value is stored in the 'number' variable if successful.
        if (long.TryParse(input, out long number))
        {
            // If parsing is successful, print the number.
            Console.WriteLine($"Number: {number}");
        }
        else
        {
            // If parsing fails (e.g., input is not a valid number, or it's
            // too large/small even for a 'long'), print an error message.
            Console.WriteLine($"Error: Invalid input or number is too large/small for a long: {input}");
        }
    }
 
    // Example of how you might use this class
    public static void Main(string[] args)
    {
        InputProcessor processor = new InputProcessor();
 
        // Test cases:
        processor.HandleInput("12345"); // Valid int, also valid long
        processor.HandleInput("9999999999"); // Exceeds int range, valid long
        processor.HandleInput("1234567890123456789"); // Large long
        processor.HandleInput("-9876543210"); // Negative long
        processor.HandleInput("NotANumber"); // Invalid input
        processor.HandleInput("99999999999999999999999999999999999999999"); // Exceeds long range
    }
}