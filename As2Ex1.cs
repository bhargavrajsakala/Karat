

**CASE STUDY 1 — Threading + Singleton**
 
**Server Health Monitoring System**
 
```csharp
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
 
/*
We are writing software to monitor health check pings from multiple servers
in a data center.
 
Each server periodically sends a health ping which is logged in memory.
 
Log format:
<timestamp> <serverId> <status>
 
status can be:
- UP
- DOWN
 
The monitoring service runs in a multi-threaded environment where
multiple threads record health pings at the same time.
 
There must be ONLY ONE INSTANCE of HealthMonitor in the application
because it represents a centralized monitoring system.
 
A server is considered "STABLE" if:
- It has at least one UP status
- It never goes DOWN after its first UP
 
1-1) Implement the HealthMonitor as a THREAD-SAFE SINGLETON
1-2) Write a function CountStableServers()
     that returns how many servers are stable
*/
 
public class HealthLogEntry
{
    public double Timestamp { get; }
    public string ServerId { get; }
    public string Status { get; }
 
    public HealthLogEntry(double timestamp, string serverId, string status)
    {
        Timestamp = timestamp;
        ServerId = serverId;
        Status = status;
    }
}
 
public class HealthMonitor
{
    // TODO:
    // - Make this class a thread-safe singleton
    // - Store logs in a thread-safe collection
 
    public void AddLog(HealthLogEntry entry)
    {
        // TODO: Thread-safe add
    }
 
    /*
    1-3) Implement this function
    */
    public int CountStableServers()
    {
        // TODO
        return 0;
    }
}
 
public class Solution
{
    public static void Main()
    {
        HealthMonitor monitor = HealthMonitor.Instance;
 
        Thread t1 = new Thread(() =>
        {
            monitor.AddLog(new HealthLogEntry(1.1, "S1", "UP"));
            monitor.AddLog(new HealthLogEntry(2.1, "S1", "UP"));
        });
 
        Thread t2 = new Thread(() =>
        {
            monitor.AddLog(new HealthLogEntry(1.5, "S2", "UP"));
            monitor.AddLog(new HealthLogEntry(2.5, "S2", "DOWN"));
        });
 
        t1.Start();
        t2.Start();
        t1.Join();
        t2.Join();
 
        Debug.Assert(monitor.CountStableServers() == 1);
 
        Console.WriteLine("All tests passed.");
    }
}
```

solution : 

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

public class HealthLogEntry
{
    public double Timestamp { get; }
    public string ServerId { get; }
    public string Status { get; }

    public HealthLogEntry(double timestamp, string serverId, string status)
    {
        Timestamp = timestamp;
        ServerId = serverId;
        Status = status;
    }
}

public class HealthMonitor
{
    private static readonly object _lock = new object();
    private static HealthMonitor _instance;
    
    
    public static HealthMonitor Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new HealthMonitor();
                    }
                }
            }
            return _instance;
        }
    }
    
    private readonly List<HealthLogEntry> _logs;
    private readonly object _logsLock = new object();
    
    private HealthMonitor()
    {
        _logs = new List<HealthLogEntry>();
    }
    
    public void AddLog(HealthLogEntry entry)
    {
        lock (_logsLock)
        {
            _logs.Add(entry);
        }
    }
    
    public int CountStableServers()
    {
        lock (_logsLock)
        {
            
            Dictionary<string, bool> serverHasUp = new Dictionary<string, bool>();
            Dictionary<string, bool> serverHasDownAfterUp = new Dictionary<string, bool>();
            
            
            foreach (HealthLogEntry log in _logs)
            {
                string serverId = log.ServerId;
                
                
                if (log.Status == "UP")
                {
                    if (!serverHasUp.ContainsKey(serverId))
                    {
                        serverHasUp[serverId] = true;
                    }
                }
                
                
                if (serverHasUp.ContainsKey(serverId) && log.Status == "DOWN")
                {
                    serverHasDownAfterUp[serverId] = true;
                }
            }
            
           
            int stableCount = 0;
            foreach (string serverId in serverHasUp.Keys)
            {
                
                if (serverHasUp[serverId] && 
                    (!serverHasDownAfterUp.ContainsKey(serverId) || !serverHasDownAfterUp[serverId]))
                {
                    stableCount++;
                }
            }
            
            return stableCount;
        }
    }
}

public class Solution
{
    public static void Main()
    {
        HealthMonitor monitor = HealthMonitor.Instance;

        Thread t1 = new Thread(() =>
        {
            monitor.AddLog(new HealthLogEntry(1.1, "S1", "UP"));
            monitor.AddLog(new HealthLogEntry(2.1, "S1", "UP"));
        });

        Thread t2 = new Thread(() =>
        {
            monitor.AddLog(new HealthLogEntry(1.5, "S2", "UP"));
            monitor.AddLog(new HealthLogEntry(2.5, "S2", "DOWN"));
        });

        t1.Start();
        t2.Start();
        t1.Join();
        t2.Join();

        Debug.Assert(monitor.CountStableServers() == 1);

        Console.WriteLine("All tests passed.");
    }
}

 
**CASE STUDY 2 — Async + Arrays**
 
**Weather Sensor Data Processing System**
 
```csharp
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
 
/*
We are writing software to process temperature data collected from
multiple weather sensors.
 
Each sensor reports a fixed number of readings per day.
Data for each sensor is stored in an ARRAY.
 
Log file format:
<sensorId> <comma-separated temperature readings>
 
Example:
S1 30,31,32,33
S2 25,26,27,28
 
A sensor is considered "OVERHEATED" if:
- ANY temperature reading exceeds 40 degrees
 
The data file can be very large, so it must be read asynchronously.
 
1-1) Write an async function LoadSensorDataAsync()
     that reads the file asynchronously and returns sensor data
1-2) Write a function CountOverheatedSensors()
     that returns how many sensors are overheated
*/
 
public class SensorData
{
    public string SensorId { get; }
    public int[] Readings { get; }
 
    public SensorData(string line)
    {
        var parts = line.Split(" ");
        SensorId = parts[0];
        Readings = Array.ConvertAll(parts[1].Split(","), int.Parse);
    }
}
 
public class SensorDataFile : List<SensorData>
{
    public static async Task<SensorDataFile> LoadSensorDataAsync(string filePath)
    {
        // TODO: Async file read + parsing
        return null;
    }
 
    /*
    2-1) Implement this function
    */
    public int CountOverheatedSensors()
    {
        // TODO
        return 0;
    }
}
 
public class Solution
{
    public static async Task Main()
    {
        string path = "sensors.txt";
        File.WriteAllLines(path, new[]
        {
            "S1 30,31,32,33",
            "S2 25,26,27,28",
            "S3 35,42,36,37"
        });
 
        var data = await SensorDataFile.LoadSensorDataAsync(path);
 
        Debug.Assert(data.CountOverheatedSensors() == 1);
 
        Console.WriteLine("All tests passed.");
    }
}
```
solution:

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

public class SensorData
{
    public string SensorId { get; }
    public int[] Readings { get; }

    public SensorData(string line)
    {
        var parts = line.Split(" ");
        SensorId = parts[0];
        Readings = Array.ConvertAll(parts[1].Split(","), int.Parse);
    }
}

public class SensorDataFile : List<SensorData>
{
    public static async Task<SensorDataFile> LoadSensorDataAsync(string filePath)
    {
        var file = new SensorDataFile();
        using var reader = new StreamReader(filePath);
        string line;
        while ((line = await reader.ReadLineAsync()) != null)
        {
            if (!string.IsNullOrWhiteSpace(line))
            {
                file.Add(new SensorData(line));
            }
        }
        return file;
    }

    public int CountOverheatedSensors()
    {
        int count = 0;
        for (int i = 0; i < this.Count; i++)
        {
            SensorData sensor = this[i];
            bool overheated = false;
            for (int j = 0; j < sensor.Readings.Length; j++)
            {
                if (sensor.Readings[j] > 40)
                {
                    overheated = true;
                    break;
                }
            }
            if (overheated)
            {
                count++;
            }
        }
        return count;
    }
}

public class Solution
{
    public static async Task Main()
    {
        string path = "sensors.txt";
        File.WriteAllLines(path, new[]
        {
            "S1 30,31,32,33",
            "S2 25,26,27,28",
            "S3 35,42,36,37"
        });

        var data = await SensorDataFile.LoadSensorDataAsync(path);

        Debug.Assert(data.CountOverheatedSensors() == 1);

        Console.WriteLine("All tests passed.");
    }
}

Maniarasi
