/*
We are developing a stock trading data management software that tracks the prices of different stocks over time and provides useful statistics.

The program includes three classes: 
* Stock — represents data about a specific stock.
* PriceRecord — holds information about a single price record for a stock.
* StockCollection — manages a collection of price records for a particular stock and provides methods to retrieve useful statistics about the stock's prices.

Tasks:
1. Read through and understand the code.
2. The test for StockCollection is not passing due to a bug in the code. Make the necessary changes to StockCollection to fix the bug.
*/
using System;
using System.Collections.Generic;
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

    // BUG: These methods throw exceptions if PriceRecords is empty
    public int? GetMaxPrice()
    {
        return PriceRecords.Max(priceRecord => priceRecord.Price);
    }

    public int? GetMinPrice()
    {
        return PriceRecords.Min(priceRecord => priceRecord.Price);
    }

    public double? GetAvgPrice()
    {
        return PriceRecords.Average(priceRecord => priceRecord.Price);
    }
}

public class Solution
{
    public static void Main(String[] args) {
        TestPriceRecord();
        TestStockCollection();
    }
    
    public static void TestPriceRecord()
    {
        Console.WriteLine("Running TestPriceRecord");
        Stock TestStock = new Stock("AAPL", "Apple Inc.");
        PriceRecord TestPriceRecord = new PriceRecord(TestStock, 100, "2023-07-01");
        Console.WriteLine(TestPriceRecord.ToString());
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

        List<Tuple<int, string>> PriceData = new List<Tuple<int, string>>
        {
            new Tuple<int, string>(110, "2023-06-29"),
            new Tuple<int, string>(112, "2023-07-01"),
            new Tuple<int, string>(90, "2023-06-28"),
            new Tuple<int, string>(105, "2023-07-06")
        };
        TestStock = new Stock("AAPL", "Apple Inc.");
        StockCollection = MakeStockCollection(TestStock, PriceData);
        Debug.Assert(StockCollection.GetNumPriceRecords() == PriceData.Count);
        Debug.Assert(StockCollection.GetMaxPrice() == 112);
        Debug.Assert(StockCollection.GetMinPrice() == 90);
        Debug.Assert(StockCollection.GetAvgPrice().GetValueOrDefault() - 104.25m) < 0.1m;
    }
}

solution:
here in test cases max,min and avg prices leads to null the test cases are failed due to that in stock collection 
we need to write a logic that if pricerecords.count is 0 then it should return null

    if(pricerecords.count == 0) {return null} return PriceRecords.Max(priceRecord => priceRecord.Price);
if not we can use null check
PriceRecods.Count >0 ? PriceRecords.Max(priceRecord => priceRecord.Price) : null;
