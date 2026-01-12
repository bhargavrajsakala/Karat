/*

We're building the game engine for *Thrilling Teleporters*, a board game with N tiles, starting from tile 0.

Some tiles contain teleporters that instantly move the player to another tile (forward or backward).  
For example:

teleporters1 = [
  "3,1",  // From tile 3 to tile 1
  "4,2",  // From tile 4 to tile 2
  "5,10"  // From tile 5 to tile 10
]

Visual example for N = 12:

       "3,1"
     ┌─<───<─┐                                    
     v       │
 0 → 1 → 2 → 3 . 4 . 5 . 6 → 7 → 8 → 9 → 10 → 11 → 12
         ^       │   │                    ^
         └─<───<─┘   └──>───>───>───>───>──┘
           "4,2"             "5,10"

Rules:
- The player rolls a die and moves forward.
- If they land on a tile with a teleporter, they are instantly transported.
- Only one teleporter is activated per roll.
- The player cannot move past the final tile N.

Write a function that returns all unique tiles the player can reach in a single die roll.

Example:  
N = 12, start = 0, die = 6, teleporters1 above → [1, 2, 10, 6].
      
*/
using System;
using System.Collections.Generic;
using System.Linq;

class Solution {
  
    static void Main(string[] args) {
        var teleporters1 = new string[] {"3,1", "4,2", "5,10"};
        var result = Destinations(teleporters1, 6, 0, 12);
        Console.WriteLine(string.Join(", ", result));
    }
}
