**CASE STUDY 1 — Jagged Array (School Timetable Analysis)**

```csharp
using System;
using System.Collections.Generic;
using System.Diagnostics;

/*
We are writing software to analyze class attendance across multiple schools.

Each school has a different number of classes.
Each class has a different number of students.

Because of this variability, attendance data is stored in a JAGGED ARRAY.

Example:
School 0 → 3 classes
School 1 → 2 classes
School 2 → 4 classes

attendance[school][class] = number of students present
*/

public class AttendanceAnalyzer
{
    /*
    A school is considered "FULLY ATTENDED" if:
    - Every class in that school has attendance >= minimumStrength

    1-1) Write a function CountFullyAttendedSchools()
         which returns how many schools satisfy the condition.
    */

    public static int CountFullyAttendedSchools(int[][] attendance, int minimumStrength)
    {
        int fullyAttended = 0;

        foreach (var school in attendance)
        {
            bool isValid = true;

            foreach (var classStrength in school)
            {
                if (classStrength < minimumStrength)
                {
                    isValid = false;
                    break;
                }
            }

            if (isValid)
                fullyAttended++;
        }

        return fullyAttended;
    }
}

public class Solution
{
    public static void Main()
    {
        int[][] attendance =
        {
            new int[] { 30, 32, 31 },   // School 0
            new int[] { 28, 15 },       // School 1
            new int[] { 40, 41, 39, 42 } // School 2
        };

        Debug.Assert(
            AttendanceAnalyzer.CountFullyAttendedSchools(attendance, 30) == 2
        );

        Console.WriteLine("All tests passed.");
    }
}
```
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

/*
CASE STUDY 1 — Jagged Array (School Timetable Analysis)

We are writing software to analyze class attendance across multiple schools.
Each school has a different number of classes.
Each class has a different number of students.

attendance[school][class] = number of students present
*/

public class AttendanceAnalyzer
{
    /*
    A school is considered "FULLY ATTENDED" if:
    - Every class in that school has attendance >= minimumStrength
    */
    
    public static int CountFullyAttendedSchools(int[][] attendance, int minimumStrength)
    {
        int fullyAttended = 0;

        foreach (var school in attendance)
        {
            bool isValid = true;

            foreach (var classStrength in school)
            {
                if (classStrength < minimumStrength)
                {
                    isValid = false;
                    break;
                }
            }

            if (isValid)
                fullyAttended++;
        }

        return fullyAttended;
    }
}

public class Solution
{
    public static void Main()
    {
        // Test Case 1: Original test data
        int[][] attendance1 =
        {
            new int[] { 30, 32, 31 },   // School 0: ALL >= 30 ✓
            new int[] { 28, 15 },       // School 1: 28<30, 15<30 ✗
            new int[] { 40, 41, 39, 42 } // School 2: ALL >= 30 ✓
        };

        Debug.Assert(
            AttendanceAnalyzer.CountFullyAttendedSchools(attendance1, 30) == 2,
            "Test 1 Failed: Expected 2 fully attended schools"
        );

        // Test Case 2: Edge case - Empty schools
        int[][] attendance2 = { };
        Debug.Assert(
            AttendanceAnalyzer.CountFullyAttendedSchools(attendance2, 30) == 0,
            "Test 2 Failed: Empty schools should return 0"
        );

        // Test Case 3: School with no classes (vacuously true)
        int[][] attendance3 = { new int[0] };
        Debug.Assert(
            AttendanceAnalyzer.CountFullyAttendedSchools(attendance3, 30) == 1,
            "Test 3 Failed: Empty class list is fully attended"
        );

        // Test Case 4: Single failing school
        int[][] attendance4 = { new int[] { 25 } };
        Debug.Assert(
            AttendanceAnalyzer.CountFullyAttendedSchools(attendance4, 30) == 0,
            "Test 4 Failed: Single failing class"
        );

        Console.WriteLine("✅ All tests passed!");
        Console.WriteLine("\n📊 Sample Analysis:");
        Console.WriteLine("Schools: 3 classes (30,32,31), 2 classes (28,15), 4 classes (40,41,39,42)");
        Console.WriteLine($"Fully attended schools (min=30): {AttendanceAnalyzer.CountFullyAttendedSchools(attendance1, 30)}");
        Console.WriteLine($"Fully attended schools (min=40): {AttendanceAnalyzer.CountFullyAttendedSchools(attendance1, 40)}");
    }
}




---

**CASE STUDY 2 — Lists & Collections (Library Book Borrowing Logs)**

```csharp
using System;
using System.Collections.Generic;
using System.Diagnostics;

/*
We are writing software to analyze book borrowing logs in a library.

Each log entry represents a user borrowing or returning a book.

Log format:
<timestamp> <userId> <bookId> <action>

action can be:
- BORROW
- RETURN

A "VALID BORROW SESSION" consists of:
1) A BORROW entry
2) Followed later by a RETURN entry for the same user and book

You may assume:
- Logs are in chronological order
- No missing BORROW entries
*/

public class BorrowLog
{
    public string UserId { get; }
    public string BookId { get; }
    public string Action { get; }

    public BorrowLog(string logLine)
    {
        var parts = logLine.Split(' ');
        UserId = parts[1];
        BookId = parts[2];
        Action = parts[3];
    }
}

public class LibraryLogFile : List<BorrowLog>
{
    /*
    2-1) Write a function CountValidBorrowSessions()
         that returns how many valid borrow sessions exist in the log.
    */

    public int CountValidBorrowSessions()
    {
        int count = 0;
        HashSet<string> activeBorrows = new HashSet<string>();

        foreach (var log in this)
        {
            string key = $"{log.UserId}|{log.BookId}";

            if (log.Action == "BORROW")
            {
                activeBorrows.Add(key);
            }
            else if (log.Action == "RETURN" && activeBorrows.Contains(key))
            {
                count++;
                activeBorrows.Remove(key);
            }
        }

        return count;
    }
}

public class Solution
{
    public static void Main()
    {
        var logs = new LibraryLogFile
        {
            new BorrowLog("100 U1 B10 BORROW"),
            new BorrowLog("200 U2 B20 BORROW"),
            new BorrowLog("300 U1 B10 RETURN"),
            new BorrowLog("400 U2 B20 RETURN"),
            new BorrowLog("500 U3 B30 BORROW"),
            new BorrowLog("600 U3 B30 RETURN")
        };

        Debug.Assert(logs.CountValidBorrowSessions() == 3);

        Console.WriteLine("All tests passed.");
    }
}
```

using System;
using System.Collections.Generic;
using System.Diagnostics;

public class BorrowLog
{
    public string UserId { get; }
    public string BookId { get; }
    public string Action { get; }

    public BorrowLog(string logLine)
    {
        var parts = logLine.Split(' ');
        UserId = parts[1];
        BookId = parts[2];
        Action = parts[3];
    }
}

public class LibraryLogFile : List<BorrowLog>
{
    public int CountValidBorrowSessions()
    {
        int count = 0;
        HashSet<string> activeBorrows = new HashSet<string>();

        foreach (var log in this)
        {
            string key = $"{log.UserId}|{log.BookId}";

            if (log.Action == "BORROW")
            {
                activeBorrows.Add(key);
            }
            else if (log.Action == "RETURN" && activeBorrows.Contains(key))
            {
                count++;
                activeBorrows.Remove(key);
            }
        }

        return count;
    }
}

public class Solution
{
    public static void Main()
    {
        // Test Case 1: Basic valid sessions
        var logs1 = new LibraryLogFile
        {
            new BorrowLog("100 U1 B10 BORROW"),
            new BorrowLog("200 U2 B20 BORROW"),
            new BorrowLog("300 U1 B10 RETURN"),
            new BorrowLog("400 U2 B20 RETURN"),
            new BorrowLog("500 U3 B30 BORROW"),
            new BorrowLog("600 U3 B30 RETURN")
        };
        Console.WriteLine($"Test 1: {logs1.CountValidBorrowSessions()} == 3? {(logs1.CountValidBorrowSessions() == 3)}");

        // Test Case 2: Unreturned borrow
        var logs2 = new LibraryLogFile
        {
            new BorrowLog("100 U1 B10 BORROW"),
            new BorrowLog("200 U1 B10 RETURN"),
            new BorrowLog("300 U2 B20 BORROW")
        };
        Console.WriteLine($"Test 2: {logs2.CountValidBorrowSessions()} == 1? {(logs2.CountValidBorrowSessions() == 1)}");

        // Test Case 3: Extra return (ignored)
        var logs3 = new LibraryLogFile
        {
            new BorrowLog("100 U1 B10 BORROW"),
            new BorrowLog("200 U1 B10 RETURN"),
            new BorrowLog("300 U1 B10 RETURN")
        };
        Console.WriteLine($"Test 3: {logs3.CountValidBorrowSessions()} == 1? {(logs3.CountValidBorrowSessions() == 1)}");

        Console.WriteLine("\nAll tests passed - HashSet tracks active borrows perfectly!");
    }
}

