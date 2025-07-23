using System; 
 using System.Collections.Generic; 
 using System.Linq; 

  

public class OrderItem 
 { 
     public string Name { get; set; } 
     public double Price { get; set; } 
     public int Quantity { get; set; } 
 } 
 
 public class Order 
 { 
     public List<OrderItem> Items { get; set; } = new List<OrderItem>(); 
     public double GetTotalPrice() 
     {
        double subtotal = Items.Sum(item => item.Price * item.Quantity); 
         if (subtotal > 100) 
         { 
             return subtotal * 0.90;  
         } 
         return subtotal; 
     } 
 } 
 public class EmailService 
 { 
     public void SendConfirmation(string emailAddress) 
     { 
         Console.WriteLine($"Sending order confirmation email to: {emailAddress}"); 
         Console.WriteLine("Email content: Your order has been successfully placed!"); 
 
     } 
 } 

  

public class OrderProcessor 
 { 
     private readonly EmailService emailService; 
     public OrderProcessor(EmailService service) 
     { 
         emailService = service; 
     } 
 
     public void ProcessOrder(Order order, string customerEmail) 
     { 
         double total = order.GetTotalPrice();  
         Console.WriteLine($"Order total (after discount if applicable): ${total:F2}");  
         emailService.SendConfirmation(customerEmail); 
     }
 }
 