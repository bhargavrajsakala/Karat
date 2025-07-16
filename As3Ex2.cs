using KarateAssignment; 
 using System; 
 using System.Collections.Generic; 
 using System.Linq; 
 using System.Text; 
 using System.Threading.Tasks; 
 namespace KarateAssignment 
 { 
    class Transaction 
     { 
         public int Id { get; set; } 
         public string CustomerEmail { get; set; } 
         public bool IsActive { get; set; } 
     } 
    class Program 
     { 
         static void Main(string[] args) 
         { 
             var transactions = new List<Transaction> 
         { 
             new Transaction { Id = 1, CustomerEmail = "a@example.com", IsActive = true }, 
             new Transaction { Id = 2, CustomerEmail = "a@example.com", IsActive = true }, 
             new Transaction { Id = 3, CustomerEmail = "b@example.com", IsActive = false }, 
             new Transaction { Id = 4, CustomerEmail = "c@example.com", IsActive = true } 
         }; 
         var activeCustomers = transactions 
             .Where(t => t.IsActive) 
             .Select(t => t.CustomerEmail) 
             .Distinct(); 
            foreach (var customer in activeCustomers) 
             { 
                 Console.WriteLine(customer); 
             } 
        } 
     } 
 } 