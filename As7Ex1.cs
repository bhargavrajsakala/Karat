using System;
using System.Collections.Generic;
using System.Text; // Required for StringBuilder
 
class ReportBuilder
{
    public string BuildReport(List<string> lines)
    {
        // Use StringBuilder for efficient string concatenation
        StringBuilder sb = new StringBuilder();
 
        foreach (var line in lines)
        {
            sb.AppendLine(line); // Appends the string and a newline character
        }
 
        return sb.ToString(); // Convert the StringBuilder content to a string
    }
}
 
class Program
{
    static void Main()
    {
        List<string> reportLines = new List<string>
        {
            "Sales Report",
            "",
            "Product A: 120 units",
            "Product B: 85 units",
            "Product C: 200 units"
        };
 
        ReportBuilder builder = new ReportBuilder();
        string report = builder.BuildReport(reportLines);
 
        Console.WriteLine("Generated Report:\n" + report);
    }
}