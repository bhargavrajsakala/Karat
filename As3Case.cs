using System; 
 using System.Collections.Generic; 
 using System.Linq; 
 using System.Text; 
 using System.Threading.Tasks; 
namespace KarateAssignment {
    class SalesTransaction  
     {  
         public int ProductId {  get; set; } 
         public string Category { get; set; } 
         public decimal Amount { get; set; } 
         public DateTime TransactionDate { get; set; } 
     } 
    class program 
     { 
         static void Main() 
         { 
             var SalesTransactions = new List<SalesTransaction> 
             { 
                 new SalesTransaction {ProductId = 1, Category = "Electronics", Amount = 500, TransactionDate = DateTime.Parse("2025-01-15 10:30") }, 
                 new SalesTransaction {ProductId = 1, Category = "clothing", Amount = 500, TransactionDate = DateTime.Parse("2025-02-15 10:30") }, 
                 new SalesTransaction {ProductId = 1, Category = "Electronics", Amount = 500, TransactionDate = DateTime.Parse("2024-07-15 10:30") }, 
                 new SalesTransaction {ProductId = 1, Category = "Electronics", Amount = 500, TransactionDate = DateTime.Parse("2025-03-15 10:30") }, 
                 new SalesTransaction {ProductId = 1, Category = "clothing", Amount = 500, TransactionDate = DateTime.Parse("2025-04-15 10:30") }, 
                 new SalesTransaction {ProductId = 1, Category = "Electronics", Amount = 500, TransactionDate = DateTime.Parse("2023-07-15 10:30") }, 
                 new SalesTransaction {ProductId = 1, Category = "Electronics", Amount = 500, TransactionDate = DateTime.Parse("2025-05-15 10:30") },
                 new SalesTransaction {ProductId = 1, Category = "Electronics", Amount = 500, TransactionDate = DateTime.Parse("2025-06-15 10:30") }, 
                 new SalesTransaction {ProductId = 1, Category = "Electronics", Amount = 500, TransactionDate = DateTime.Parse("2025-07-15 10:30") }, 
                 new SalesTransaction {ProductId = 1, Category = "clothing", Amount = 500, TransactionDate = DateTime.Parse("2025-08-15 10:30") }, 
                 new SalesTransaction {ProductId = 1, Category = "Electronics", Amount = 500, TransactionDate = DateTime.Parse("2025-09-15 10:30") }, 
                 new SalesTransaction {ProductId = 1, Category = "Electronics", Amount = 500, TransactionDate = DateTime.Parse("2025-10-15 10:30") }, 
                 new SalesTransaction {ProductId = 1, Category = "clothing", Amount = 500, TransactionDate = DateTime.Parse("2025-11-15 10:30") }, 
                 new SalesTransaction {ProductId = 1, Category = "Electronics", Amount = 500, TransactionDate = DateTime.Parse("2025-12-15 10:30") } 
             }; 
             var CurrentYear = DateTime.Now.Year; 
             var SalesReport = SalesTransactions.Where(st => st.TransactionDate.Year == CurrentYear) 
                 .GroupBy(st => new { Quarter = GetQuarter(st.TransactionDate), st.Category }) 
                 .Select(g => new {Quarter = g.Key.Quarter, Category = g.Key.Category, TotalRevenue = g.Sum(x=>x.Amount)}) 
                 .OrderBy(r => r.Quarter) 
                 .ThenBy(r => r.Category) 
                 .ToList(); 
                 foreach (var s in SalesReport) 
             { 
                 Console.WriteLine($"Quarter = \"{s.Quarter}\", Category = \"{s.Category}\", TotalRevenue = {s.TotalRevenue}"); 
             } 
        } 
         static string GetQuarter(DateTime TransactionDate) 
         { 
             if (TransactionDate.Month <= 3) 
                 return "Q1"; 
             else if (TransactionDate.Month <= 6) 
                 return "Q2"; 
             if (TransactionDate.Month <= 9) 
                 return "Q3"; 
             else 
                 return "Q4"; 
         } 
     } 
 } 