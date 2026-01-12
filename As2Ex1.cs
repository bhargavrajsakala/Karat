/*
/*
We are writing software to analyze logs for toll booths on a highway. This highway is a divided highway with limited access; the only way on to or off of the highway is through a toll booth.

There are three types of toll booths:
* ENTRY (E in the diagram) toll booths, where a car goes through a booth as it enters the highway.
* EXIT (X in the diagram) toll booths, where a car goes through a booth as it exits the highway.
* MAINROAD (M in the diagram), which have sensors that record a license plate as a car drives through at full speed.


        Exit Booth                         Entry Booth
            |                                   |
            X                                   E
             \                                 /
---<------------<---------M---------<-----------<---------<----
                                         (West-bound side)

===============================================================

                                         (East-bound side)
------>--------->---------M--------->--------->--------->------
             /                                 \
            E                                   X
            |                                   |
        Entry Booth                         Exit Booth
*/

/*
For our first task:
1:1) Read through and understand the code and comments below. Feel free to run the code and tests.
1:2) The tests are not passing due to a bug in the code. Make the necessary changes to LogEntry to fix the bug.

*/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

public class LogEntry
{
    public string Timestamp { get; private set; }
    public string LicensePlate { get; private set; }
    public string BoothType { get; private set; }
    public int Location { get; private set; }
    public string Direction { get; private set; }

    public LogEntry(string logLine)
    {
        string[] tokens = logLine.Split(' ');
        Timestamp = tokens[0]; 
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
        return string.Format("<LogEntry timestamp: {0}  license: {1}  location: {2}  direction: {3}  booth type: {4}>",
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
}

public class Solution
{
    private static void AssertEqual(object actual, object expected, string name)
    {
        if (!object.Equals(actual, expected))
        {
            Console.WriteLine("TEST FAILED: {0}\nExpected: {1} ({2})\nActual:   {3} ({4})",
                name, expected, expected?.GetType(), actual, actual?.GetType());
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

    public static void Main()
    {
        TestLogEntry();
        Console.WriteLine("All tests passed.");
    }
}
