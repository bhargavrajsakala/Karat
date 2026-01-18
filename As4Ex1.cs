/*

/*
We are writing software to analyze logs for toll booths on a highway. This highway is a divided highway with limited access; the only way on to or off of the highway is through a toll booth.

There are three types of toll booths:
* ENTRY (E in the diagram) toll booths, where a car goes through a booth as it enters the highway.
* EXIT (X in the diagram) toll booths, where a car goes through a booth as it exits the highway.
* MAINROAD (M in the diagram), which have sensors that record a license plate as a car drives through at full speed.

We are interested in how many people are using the highway, and so we would like to count how many complete journeys are taken in the log file.

A complete journey consists of:
* A driver entering the highway through an ENTRY toll booth.
* The driver passing through some number of MAINROAD toll booths (possibly 0).
* The driver exiting the highway through an EXIT toll booth.

For example, the following excerpt of log lines contains complete journeys for the cars with JOX304 and THX138:

90750.191 JOX304 250E ENTRY
91081.684 JOX304 260E MAINROAD
91082.101 THX138 110E ENTRY
91483.251 JOX304 270E MAINROAD
91873.920 THX138 120E MAINROAD
91874.493 JOX304 280E EXIT
91982.102 THX138 290E EXIT

You may assume that the log only contains complete journeys, and there are no missing entries.

Task:
2-1) Write a function in LogFile named CountJourneys() that returns how many complete journeys there are in the given LogFile.

*/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

public class LogEntry
{
    public double Timestamp { get; private set; }
    public string LicensePlate { get; private set; }
    public string BoothType { get; private set; }
    public int Location { get; private set; }
    public string Direction { get; private set; }

    public LogEntry(string logLine)
    {
        string[] tokens = logLine.Split(' ');
        Timestamp = double.Parse(tokens[0]);
        LicensePlate = tokens[1];
        BoothType = tokens[3];
        Location = int.Parse(tokens[2].Substring(0, tokens[2].Length - 1));
        char directionLetter = tokens[2][tokens[2].Length - 1];
        if (directionLetter == 'E') Direction = "EAST";
        else if (directionLetter == 'W') Direction = "WEST";
        else Debug.Assert(false, "Invalid direction");
    }

    public override string ToString()
    {
        return string.Format("<LogEntry timestamp: {0} license: {1} location: {2} direction: {3} booth type: {4}>",
            Timestamp, LicensePlate, Location, Direction, BoothType);
    }
}

public class LogFile : List<LogEntry>
{
    public LogFile(StringReader sr)
    {
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            LogEntry logEntry = new LogEntry(line.Trim());
            Add(logEntry);
        }
    }

    // TODO: implement CountJourneys()
    public int CountJourneys()
    {
       int count = 0;
       foreach(LogEntry entry in this){
       if(entry.BoothType == "EXIT"){count++;}
       }
       return count;
    }
}

public class Solution
{
    private static void AssertEqual(object actual, object expected, string name)
    {
        if (!object.Equals(actual, expected))
        {
            Console.WriteLine("TEST FAILED: {0}\nExpected: {1}\nActual:   {2}", name, expected, actual);
            throw new Exception("Test failed: " + name);
        }
        else
        {
            Console.WriteLine("OK: {0}", name);
        }
    }

    public static void TestLogEntry()
    {
        string logLine = "44776.619 KTB918 310E MAINROAD";
        LogEntry logEntry = new LogEntry(logLine);
        AssertEqual(logEntry.Timestamp, 44776.619, "Timestamp");
        AssertEqual(logEntry.LicensePlate, "KTB918", "LicensePlate");
        AssertEqual(logEntry.Location, 310, "Location");
        AssertEqual(logEntry.Direction, "EAST", "Direction");
        AssertEqual(logEntry.BoothType, "MAINROAD", "BoothType");

        logLine = "52160.132 ABC123 400W ENTRY";
        logEntry = new LogEntry(logLine);
        AssertEqual(logEntry.Timestamp, 52160.132, "Timestamp2");
        AssertEqual(logEntry.LicensePlate, "ABC123", "LicensePlate2");
        AssertEqual(logEntry.Location, 400, "Location2");
        AssertEqual(logEntry.Direction, "WEST", "Direction2");
        AssertEqual(logEntry.BoothType, "ENTRY", "BoothType2");
    }

    public static void TestCountJourneys()
    {
        string sample = @"90750.191 JOX304 250E ENTRY
91081.684 JOX304 260E MAINROAD
91082.101 THX138 110E ENTRY
91483.251 JOX304 270E MAINROAD
91873.920 THX138 120E MAINROAD
91874.493 JOX304 280E EXIT
91982.102 THX138 290E EXIT";

        LogFile logFile = new LogFile(new StringReader(sample));
        AssertEqual(logFile.CountJourneys(), 2, "CountJourneys");
    }

    public static void Main()
    {
        TestLogEntry();
        TestCountJourneys();
        Console.WriteLine("All tests passed.");
    }
}

solution :
here we need to count journeys based on entry ,mainroad and exist here i am going to write a solution that 
in logentry if boottype is exit then we can count it has a 1 complete journey.
    
    public int CountJourneys()
    {
        int count = 0;

        foreach (LogEntry record in this)
        {
            if (record.BoothType == "EXIT")
            {
                count++;
            }
        }

        return count;
    }
}

LogFile is a List<LogEntry>

Inside CountJourneys() method, this = the LogFile object itself

this has all List<LogEntry> capabilities (Count, indexing, enumeration)
