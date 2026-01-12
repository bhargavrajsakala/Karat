/*
You are analyzing data for Aquaintly, a hot new social network.

On Aquaintly, connections are always symmetrical. If a user Alice is connected to Bob, then Bob is also connected to Alice.

You are given a sequential log of CONNECT and DISCONNECT events of the following form:
- This event connects users Alice and Bob: ["CONNECT", "Alice", "Bob"]
- This event disconnects the same users: ["DISCONNECT", "Bob", "Alice"] (order of users does not matter)

We want to separate users based on their popularity (number of connections). To do this, write a function that takes in the event log and a number N and returns two collections:
[Users with fewer than N connections], [Users with N or more connections]

Example:
events = [
    ["CONNECT","Alice","Bob"],
    ["DISCONNECT","Bob","Alice"],
    ["CONNECT","Alice","Charlie"],
    ["CONNECT","Dennis","Bob"],
    ["CONNECT","Pam","Dennis"],
    ["DISCONNECT","Pam","Dennis"],
    ["CONNECT","Pam","Dennis"],
    ["CONNECT","Edward","Bob"],
    ["CONNECT","Dennis","Charlie"],
    ["CONNECT","Alice","Nicole"],
    ["CONNECT","Pam","Edward"],
    ["DISCONNECT","Dennis","Charlie"],
    ["CONNECT","Dennis","Edward"],
    ["CONNECT","Charlie","Bob"]
]

Using a target of 3 connections, the expected results are:
Users with less than 3 connections: ["Alice", "Charlie", "Pam", "Nicole"]
Users with 3 or more connections: ["Dennis", "Bob", "Edward"]

All test cases:
grouping(events, 3) => [["Alice", "Charlie", "Pam", "Nicole"], ["Dennis", "Bob", "Edward"]]
grouping(events, 1) => [[], ["Alice", "Charlie", "Dennis", "Bob", "Pam", "Edward", "Nicole"]]
grouping(events, 10) => [["Alice", "Charlie", "Dennis", "Bob", "Pam", "Edward", "Nicole"], []]
Complexity Variable:
E = number of events
*/
using System;
using System.Collections.Generic;
using System.Linq;

class Solution {
    static List<List<string>> grouping(string[][] events, int N) {
        // TODO: Implement grouping logic here
        return new List<List<string>>();
    }

    static void Main(String[] args) {
        var events = new string[][] {
            new string[] {"CONNECT","Alice","Bob"},
            new string[] {"DISCONNECT","Bob","Alice"},
            new string[] {"CONNECT","Alice","Charlie"},
            new string[] {"CONNECT","Dennis","Bob"},
            new string[] {"CONNECT","Pam","Dennis"},
            new string[] {"DISCONNECT","Pam","Dennis"},
            new string[] {"CONNECT","Pam","Dennis"},
            new string[] {"CONNECT","Edward","Bob"},
            new string[] {"CONNECT","Dennis","Charlie"},
            new string[] {"CONNECT","Alice","Nicole"},
            new string[] {"CONNECT","Pam","Edward"},
            new string[] {"DISCONNECT","Dennis","Charlie"},
            new string[] {"CONNECT","Dennis","Edward"},
            new string[] {"CONNECT","Charlie","Bob"}
        };

        var result = grouping(events, 3);
        Console.WriteLine("Less than 3: " + string.Join(", ", result[0]));
        Console.WriteLine("3 or more: " + string.Join(", ", result[1]));
    }
}
