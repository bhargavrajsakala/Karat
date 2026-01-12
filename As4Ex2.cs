/*
You are with your friends in a castle, where there are multiple rooms named after flowers. Some of the rooms contain treasures - we call them the treasure rooms.  

Each room contains a single instruction that tells you which room to go to next.

Instructions and treasure rooms:

instructions_1 = [ 
    ["jasmin", "tulip"],
    ["lily", "tulip"],
    ["tulip", "tulip"], 
    ["rose", "rose"],
    ["violet", "rose"], 
    ["sunflower", "violet"],
    ["daisy", "violet"],
    ["iris", "violet"]
]

treasure_rooms_1 = ["lily", "tulip", "violet", "rose"]

instructions_2 = [ 
    ["jasmin", "tulip"],
    ["lily", "tulip"],
    ["tulip", "violet"],
    ["violet", "violet"]       
]

treasure_rooms_2 = ["lily", "jasmin", "violet"]  
treasure_rooms_3 = ["violet"]

Write a function filter_rooms(instructions, treasureRooms) that returns a list of rooms satisfying:
1. At least two *other* rooms have instructions pointing to this room.
2. This room's instruction immediately points to a treasure room.

Examples:
- filter_rooms(instructions_1, treasure_rooms_1) => ["tulip", "violet"]
- filter_rooms(instructions_1, treasure_rooms_2) => []
- filter_rooms(instructions_2, treasure_rooms_3) => ["tulip"]
*/
using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public static List<string> filter_rooms(string[][] instructions, string[] treasureRooms)
    {
     //TODO
    }

    public static void Main()
    {
     string[][] instructions_1 = new string[][] {
            new string[] {"jasmin", "tulip"},
            new string[] {"lily", "tulip"},
            new string[] {"tulip", "tulip"},
            new string[] {"rose", "rose"},
            new string[] {"violet", "rose"},
            new string[] {"sunflower", "violet"},
            new string[] {"daisy", "violet"},
            new string[] {"iris", "violet"}
        };
        string[][] instructions_2 = new string[][] {
            new string[] {"jasmin", "tulip"},
            new string[] {"lily", "tulip"},
            new string[] {"tulip", "violet"},
            new string[] {"violet", "violet"}
        };

        string[] treasure_rooms_1 = new string[] {"lily", "tulip", "violet", "rose"};
        string[] treasure_rooms_2 = new string[] {"lily", "jasmin", "violet"};  
        string[] treasure_rooms_3 = new string[] {"violet"};

        Console.WriteLine(string.Join(", ", filter_rooms(instructions_1, treasure_rooms_1)));  
        Console.WriteLine(string.Join(", ", filter_rooms(instructions_1, treasure_rooms_2)));  
        Console.WriteLine(string.Join(", ", filter_rooms(instructions_2, treasure_rooms_3)));   
    }
}
