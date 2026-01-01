CASE STUDY 1
 
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
 
/*
We are writing software to analyze trade execution logs from a stock exchange.
 
Each trade execution is recorded as a log entry in the following format:
 
<timestamp> <tradeId> <symbol> <price> <quantity>
 
Example:
90120.115 TR001 INFY 1520.50 100
90118.912 TR002 TCS 3450.75 50
90121.500 TR003 INFY 1518.25 200
 
The log file is NOT guaranteed to be sorted by timestamp.
 
A "HIGH VALUE TRADE" is defined as:
price * quantity >= 100000
 
We want to analyze high value trades in the exact order they occurred.
 
1-1) Write a function GetHighValueTrades()
     that returns a list of TradeIds of all HIGH VALUE TRADES,
     sorted by timestamp (earliest first).
*/
 
public class TradeLogEntry
{
    public double Timestamp { get; private set; }
    public string TradeId { get; private set; }
    public string Symbol { get; private set; }
    public decimal Price { get; private set; }
    public int Quantity { get; private set; }
 
    public TradeLogEntry(string logLine)
    {
        var tokens = logLine.Split(" ");
        Timestamp = double.Parse(tokens[0]);
        TradeId = tokens[1];
        Symbol = tokens[2];
        Price = decimal.Parse(tokens[3]);
        Quantity = int.Parse(tokens[4]);
    }
}
 
public class TradeLogFile : List<TradeLogEntry>
{
    public TradeLogFile(StreamReader reader)
    {
        string? line;
        while ((line = reader.ReadLine()) != null)
        {
            Add(new TradeLogEntry(line.Trim()));
        }
    }
 
    /*
    1-2) Implement this function
    */
    public List<string> GetHighValueTrades()
    {
        // TODO: Sorting + filtering logic
        return new List<string>();
    }
}
 
public class Solution
{
    public static void Main()
    {
        var log = new TradeLogFile(new StreamReader(new MemoryStream(
            System.Text.Encoding.UTF8.GetBytes(
@"90120.115 TR001 INFY 1520.50 100
90118.912 TR002 TCS 3450.75 50
90121.500 TR003 INFY 1518.25 200"))));
 
        var result = log.GetHighValueTrades();
 
        Debug.Assert(result.Count == 2);
        Debug.Assert(result[0] == "TR002");
        Debug.Assert(result[1] == "TR003");
 
        Console.WriteLine("All tests passed.");
    }
}

solution:
public List<string> GetHighValueTrades()
{
    const decimal threshold = 100000;

  
    var tempTrades = new List<TradeLogEntry>();
    for (int i = 0; i < Count; i++)
    {
        TradeLogEntry trade = this[i];
        decimal value = trade.Price * (decimal)trade.Quantity;
        if (value >= threshold)
        {
            tempTrades.Add(trade);
        }
    }

    int n = tempTrades.Count;
    for (int i = 0; i < n - 1; i++)
    {
        for (int j = 0; j < n - i - 1; j++)
        {
            if (tempTrades[j].Timestamp > tempTrades[j + 1].Timestamp)
            {
                
                TradeLogEntry temp = tempTrades[j];
                tempTrades[j] = tempTrades[j + 1];
                tempTrades[j + 1] = temp;
            }
        }
    }

    var result = new List<string>();
    for (int i = 0; i < tempTrades.Count; i++)
    {
        result.Add(tempTrades[i].TradeId);
    }

    return result;
}

 
CASE STUDY 2
 
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
 
/*
We are writing software to verify ticket scans in a railway station.
 
Each scan log entry has the format:
 
<timestamp> <ticketNumber> <gateNumber>
 
Example:
100.125 TK100 G1
101.330 TK101 G2
102.410 TK102 G3
103.500 TK103 G1
 
The scan log file is GUARANTEED to be sorted by timestamp.
 
Given a ticket number, we want to quickly determine
whether the ticket was scanned at least once.
 
Because the file can contain millions of entries,
linear search is not acceptable.
 
1-1) Write a function TicketScanned(string ticketNumber)
     that returns true if the ticket exists in the log,
     otherwise false.
 
Important:
- You MUST use binary search
- You may assume ticket numbers are unique
*/
 
public class TicketScanLogEntry
{
    public double Timestamp { get; }
    public string TicketNumber { get; }
    public string GateNumber { get; }
 
    public TicketScanLogEntry(string line)
    {
        var parts = line.Split(" ");
        Timestamp = double.Parse(parts[0]);
        TicketNumber = parts[1];
        GateNumber = parts[2];
    }
}
 
public class TicketScanLogFile : List<TicketScanLogEntry>
{
    public TicketScanLogFile(StreamReader reader)
    {
        string? line;
        while ((line = reader.ReadLine()) != null)
        {
            Add(new TicketScanLogEntry(line.Trim()));
        }
    }
 
    /*
    2-1) Implement this function using BINARY SEARCH
    */
    public bool TicketScanned(string ticketNumber)
    {
        // TODO: Binary search implementation
        return false;
    }
}
 
public class Solution
{
    public static void Main()
    {
        var log = new TicketScanLogFile(new StreamReader(new MemoryStream(
            System.Text.Encoding.UTF8.GetBytes(
@"100.125 TK100 G1
101.330 TK101 G2
102.410 TK102 G3
103.500 TK103 G1"))));
 
        Debug.Assert(log.TicketScanned("TK102") == true);
        Debug.Assert(log.TicketScanned("TK999") == false);
 
        Console.WriteLine("All tests passed.");
    }
}

solution: 

    public bool TicketScanned(string ticketNumber)
    {
        int left = 0;
        int right = Count - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            int cmp = this[mid].TicketNumber.CompareTo(ticketNumber);

            if (cmp == 0)
            {
                return true;
            }
            else if (cmp < 0)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return false;



