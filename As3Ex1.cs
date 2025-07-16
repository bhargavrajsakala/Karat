using System; 
 using System.Collections.Generic; 
 using System.Linq; 
 using System.Text; 
 using System.Threading.Tasks; 
namespace KarateAssignment 
 { 
    class Department { public int Id; public string Name; } 
    class Employee { public int Id; public int DepartmentId; public string Name; } 
    var departments = GetDepartments();  // Assume 100 departments 
     var employees = GetEmployees();      // Assume 10,000 employees 
    // Group employees by DepartmentId only once 
     var employeeLookup = employees.GroupBy(e => e.DepartmentId) 
                                   .ToDictionary(g => g.Key, g => g.ToList()); 
 
     foreach (var dept in departments) 
     { 
         // Fetch employees for the department using the dictionary 
         var emps = employeeLookup.ContainsKey(dept.Id) ? employeeLookup[dept.Id] : new List<Employee>(); 
        Console.WriteLine($"{dept.Name}: {emps.Count} employees"); 
     } 
 }