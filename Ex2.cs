using System;
class TicketBooking
{
    public double totalFare = 0;
    public void BookTicket(string passengerName, int age, int quantity, double pricePerTicket)
    {
        try
        {
            if (quantity <= 0 || pricePerTicket < 0)
            {
                Console.WriteLine("Invalid quantity or price."); return;
            }
            if (age < 0)
            {
                Console.WriteLine("Invalid age.");
                return;
 
            }
 
            double discount = GetDiscount(age);
            // if (age < 5)
            //     discount = 0.5;
            // else if (age >= 60)
            //     discount = 0.3;
            // else
            //     discount = 0;
            double finalPrice = quantity * pricePerTicket * (1 - discount);
            totalFare += finalPrice;
            Console.WriteLine(passengerName + " booked " + quantity + " tickets. Total fare: " + totalFare);
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine("DivByZero Exception: " + ex.Message);
        }
        catch (NullReferenceException ex)
        {
            Console.WriteLine("NullReferenceException caught: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An unexpected error occurred: " + ex.Message);
        }
    }
 
    public double GetDiscount(int age)
    {
        if (age < 5)
            return 0.5;
        else if (age >= 60)
            return 0.3;
        else
            return 0;
    }
}
class Program
{
    static void Main()
    {
            TicketBooking booking = new TicketBooking();
            booking.BookTicket("Alice", 3, 2, 100);
            booking.BookTicket("Bob", -1, 1, 150); // Invalid age 
            booking.BookTicket("Charlie", 30, 0, 200); // Invalid quantity 
            booking.BookTicket("cathy", 0, 0, 0);
    }
 
}