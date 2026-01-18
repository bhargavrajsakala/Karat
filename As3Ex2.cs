/*

1) We are developing a stock trading data management software that tracks the prices of different stocks over time and provides useful statistics.

The program includes three classes: Stock, PriceRecord, and StockCollection.

Classes:
* The Stock class represents data about a specific stock.
* The PriceRecord class holds information about a single price record for a stock.
* The StockCollection class manages a collection of price records for a particular stock and provides methods to retrieve useful statistics about the stock's prices.

2) We want to add a new function called "GetBiggestChange" to the StockCollection class. This function calculates and returns the largest absolute change in stock price between any two consecutive days in the price records of a stock along with the dates of the change in a list. For example, let's consider the following price records of a stock:

Price Records:
Price:  110         112         90          105
Date:   2023-06-29  2023-07-01  2023-06-25  2023-07-06

Stock price changes (sorted based on date):
Date:     2023-06-25  ->  2023-06-29  ->  2023-07-01 ->  2023-07-06
Price:        90      ->      110     ->     112     ->     105
Change:              +20              +2             -7

In this case, the biggest absolute change in the stock price was +20, which occurred between 2023-06-25 and 2023-06-29. In this case, the function should return [20, "2023-06-25", "2023-06-29"]

Two days are considered consecutive if there are no other days' data in between them in the price records based on their dates.

To assist you in testing this new function, we have provided the TestGetBiggestChange function.

Complexity Variable:
n = number of price records
      
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

public class Stock
{
   public string Symbol { get; set; }
   public string Name { get; set; }

   public Stock(string symbol, string name)
   {
       Symbol = symbol;
       Name = name;
   }

   public override string ToString()
   {
       return Name;
   }
}

public class PriceRecord
{
   public Stock Stock { get; set; }
   public int Price { get; set; }
   public string Date { get; set; }

   public PriceRecord(Stock stock, int price, string date)
   {
       Stock = stock;
       Price = price;
       Date = date;
   }

   public override string ToString()
   {
       return $"Stock: {Stock} Price: {Price} date: {Date}";
   }
}

public class StockCollection
{
   public List<PriceRecord> PriceRecords { get; set; }
   public Stock Stock { get; set; }

   public StockCollection(Stock stock)
   {
       PriceRecords = new List<PriceRecord>();
       Stock = stock;
   }

   public int GetNumPriceRecords()
   {
       return PriceRecords.Count;
   }

   public void AddPriceRecord(PriceRecord priceRecord)
   {
       if (!priceRecord.Stock.Equals(Stock))
           throw new ArgumentException("PriceRecord's Stock is not the same as the StockCollection's");

       PriceRecords.Add(priceRecord);
   }

   public int? GetMaxPrice()
   {
       return PriceRecords.Count > 0 ? PriceRecords.Max(priceRecord => priceRecord.Price) : null;
   }

   public int? GetMinPrice()
   {
       return PriceRecords.Count > 0 ? PriceRecords.Min(priceRecord => priceRecord.Price) : null;
   }

   public double? GetAvgPrice()
   {
       return PriceRecords.Count > 0 ? PriceRecords.Average(priceRecord => priceRecord.Price) : null;
   }

   public Tuple<int, string, string> GetBiggestChange()
   {
       // TODO: Implement logic to find largest absolute price change
       return new Tuple<int, string, string>(0, "", "");
   }
}

public class Solution
{
   public static void Main(String[] args) {
       TestPriceRecord();
       TestStockCollection();
       TestGetBiggestChange();
   }
   
   public static void TestPriceRecord()
   {
       Console.WriteLine("Running TestPriceRecord");
       Stock TestStock = new Stock("AAPL", "Apple Inc.");
       PriceRecord TestPriceRecord = new PriceRecord(TestStock, 100, "2023-07-01");
       Debug.Assert(TestPriceRecord.Stock == TestStock);
       Debug.Assert(TestPriceRecord.Price == 100);
       Debug.Assert(TestPriceRecord.Date == "2023-07-01");
   }
   
   public static StockCollection MakeStockCollection(Stock Stock, List<Tuple<int, string>> PriceData)
   {
       StockCollection StockCollection = new StockCollection(Stock);
       foreach (Tuple<int, string> PriceRecordData in PriceData)
       {
           PriceRecord PriceRecord = new PriceRecord(Stock, PriceRecordData.Item1, PriceRecordData.Item2);
           StockCollection.AddPriceRecord(PriceRecord);
       }
       return StockCollection;
   }
   
   public static void TestStockCollection()
   {
       Console.WriteLine("Running TestStockCollection");
       Stock TestStock = new Stock("AAPL", "Apple Inc.");
       StockCollection StockCollection = new StockCollection(TestStock);
       Debug.Assert(StockCollection.GetNumPriceRecords() == 0);
       Debug.Assert(StockCollection.GetMaxPrice() == null);
       Debug.Assert(StockCollection.GetMinPrice() == null);
       Debug.Assert(StockCollection.GetAvgPrice() == null);
   }
   
   public static void TestGetBiggestChange()
   {
       Console.WriteLine("Running TestGetBiggestChange");
       Stock TestStock = new Stock("AAPL", "Apple Inc.");
       StockCollection StockCollection = new StockCollection(TestStock);
       Debug.Assert(StockCollection.GetBiggestChange().Equals(new Tuple<int,string,string>(0, "", "")));
   }
}

solution:
“The problem is about analyzing stock price data over time.
Each stock has multiple price records, where every record contains a price and a date.
The task is to find the biggest price change between two consecutive days.
Consecutive means there are no other price records between those two dates when sorted by date.”
“First, I handled the edge case.
If there are fewer than two price records, it’s impossible to calculate a price change,
so the method simply returns a message saying ‘not enough records’.”
“To solve the problem, I first sorted the price records by date
“After sorting, I loop through the list starting from the second record.
For each record, I calculate the absolute difference between the current price and the previous day’s price.
I keep track of the maximum difference and store the corresponding two dates whenever I find a bigger change.”

public string GetBiggestChange()
{
    if (PriceRecords.Count < 2)
        return "not enough records";

    var records = PriceRecords.OrderBy(r => r.Date).ToList();

    int biggestChange = 0;
    string fromDate = "";
    string toDate = "";

    for (int i = 1; i < records.Count; i++)
    {
        int change = Math.Abs(records[i].Price - records[i - 1].Price);

        if (change > biggestChange)
        {
            biggestChange = change;
            fromDate = records[i - 1].Date;
            toDate = records[i].Date;
        }
    }

    return $"Biggest change is {biggestChange} between {fromDate} and {toDate}";
}

public string GetBiggestChange()
{
    if (PriceRecords.Count < 2)
        return "not enough records";

    var records = PriceRecords.OrderBy(r => r.Date).ToList();

    int biggestChange = 0;
    string fromDate = "";
    string toDate = "";

    for (int i = 1; i < records.Count; i++)
    {
        int change = Math.Abs(records[i].Price - records[i - 1].Price);

        if (change > biggestChange)
        {
            biggestChange = change;
            fromDate = records[i - 1].Date;
            toDate = records[i].Date;
        }
    }

    return $"Biggest change is {biggestChange} between {fromDate} and {toDate}";
}

We compare the current day with the previous day
So we need records[i] and records[i - 1]
Subtract yesterday’s price from today’s price
Use Math.Abs() to get the absolute value
