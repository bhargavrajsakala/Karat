using System;
using System.IO;

public class Order
{
    public int Id { get; set; }
    public double Amount { get; set; }
}

public delegate double DiscountRule(double amount);

public class OrderProcessor
{
    public double ApplyDiscountRule(Order order, DiscountRule rule)
    {
        return rule(order.Amount);
    }

    public void SaveResultToFile(string path, Order order, double finalAmount)
    {
        string line = order.Id + "," + order.Amount.ToString("F2") + "," + finalAmount.ToString("F2");

        try
        {
            using (StreamWriter sw = new StreamWriter(path, append: true))
            {
                sw.WriteLine(line);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error writing to file: " + ex.Message);
        }
    }
}

class Program
{
    static void Main()
    {
        // Use a full path or a relative path where you have write permissions
        string path = "results.txt";

        Order order = new Order { Id = 101, Amount = 1200.0 };

        DiscountRule festivalDiscount = amt => amt * 0.90;       // 10% off
        DiscountRule premiumDiscount = amt => amt - 200;         // Flat ₹200 off

        OrderProcessor processor = new OrderProcessor();

        // Apply festival discount and save
        double afterFestival = processor.ApplyDiscountRule(order, festivalDiscount);
        processor.SaveResultToFile(path, order, afterFestival);

        // Apply premium discount and save
        double afterPremium = processor.ApplyDiscountRule(order, premiumDiscount);
        processor.SaveResultToFile(path, order, afterPremium);

        Console.WriteLine("Discounts applied and results saved to: " + Path.GetFullPath(path));
    }
}


explanation : 

The reason for using ToString("F2") is to convert the number to a string formatted as a fixed-point number with exactly 2 digits after the decimal point.

Why use ToString("F2")?
The "F" stands for Fixed-point format.

The number 2 specifies 2 decimal places.

This ensures numbers like 1200 become "1200.00" and 1080.135 become "1080.14" (rounded).
   
    processor.SaveResultToFile(path, order, afterFestival);
"This line saves the order's ID, original amount, and discounted amount after the festival discount to a specified output file for record-keeping."
    Path.GetFullPath(path) converts a possibly relative file path into the full absolute path
