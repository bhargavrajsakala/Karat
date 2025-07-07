using System;
using System.Collections.Generic;
List<int> numbers = new List<int>();
for (int i = 0; i < 1000000; i++)
{
    numbers.Add(i % 10000);
    // Many duplicates 
}
HashSet<int> uniqueNumbers = new HashSet<int>(numbers);
Console.WriteLine("Unique count: " + uniqueNumbers.Count);