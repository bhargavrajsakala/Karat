/*
We have a catalog of song titles (and their lengths) that we play at a local radio station. We have been asked to play two of those songs in a row, and they must add up to exactly seven minutes long. 

Given a list of songs and their durations, write a function that returns the names of any two distinct songs that add up to exactly seven minutes. If there is no such pair, return an empty collection. 

Example:
song_times_1 = [
("Stairway to Heaven", "8:05"), ("Immigrant Song", "2:27"),
("Rock and Roll", "3:41"), ("Communication Breakdown", "2:29"),
("Good Times Bad Times", "2:48"), ("Hot Dog", "3:19"),
("The Crunge", "3:18"), ("Achilles Last Stand", "10:26"),
("Black Dog", "4:55")
]
find_pair(song_times_1) => ["Rock and Roll", "Hot Dog"] (3:41 + 3:19 = 7:00)

Additional Input:
song_times_2 = [
("Stairway to Heaven", "8:05"), ("Immigrant Song", "2:27"),
("Rock and Roll", "3:41"), ("Communication Breakdown", "2:29"),
("Good Times Bad Times", "2:48"), ("Black Dog", "4:55"),
("The Crunge", "3:18"), ("Achilles Last Stand", "10:26"),
("The Ocean", "4:31"), ("Hot Dog", "3:19"),
]
song_times_3 = [
("Stairway to Heaven", "8:05"), ("Immigrant Song", "2:27"),
("Rock and Roll", "3:41"), ("Communication Breakdown", "2:29"),
("Hey Hey What Can I Do", "4:00"), ("Poor Tom", "3:00"),
("Black Dog", "4:55")
]
song_times_4 = [
("Hey Hey What Can I Do", "4:00"), ("Rock and Roll", "3:41"),
("Communication Breakdown", "2:29"), ("Going to California", "3:30"),
("On The Run", "3:50"), ("The Wrestler", "3:50"), 
("Black Mountain Side", "2:11"), ("Brown Eagle", "2:20")
]
song_times_5 = [("Celebration Day", "3:30"), ("Going to California", "3:30"), ("Take it easy", "3:30")]
song_times_6 = [
("Rock and Roll", "3:41"), ("If I lived here", "3:59"),
("Day and night", "5:03"), ("Tempo song", "1:57")
]


All Test Cases - snake_case:
find_pair(song_times_1) => ["Rock and Roll", "Hot Dog"]
find_pair(song_times_2) => ["Rock and Roll", "Hot Dog"] or ["Communication Breakdown", "The Ocean"]
find_pair(song_times_3) => ["Hey Hey What Can I Do", "Poor Tom"]
find_pair(song_times_4) => []
find_pair(song_times_5) => ["Celebration Day", "Going to California"] or ["Celebration Day", "Take it easy"] or ["Going to California", "Take it easy"]
find_pair(song_times_6) => ["Day and night", "Tempo song"]

All Test Cases - camelCase:
findPair(songTimes1) => ["Rock and Roll", "Hot Dog"]
findPair(songTimes2) => ["Rock and Roll", "Hot Dog"] or ["Communication Breakdown", "The Ocean"]
findPair(songTimes3) => ["Hey Hey What Can I Do", "Poor Tom"]
findPair(songTimes4) => []
findPair(songTimes5) => ["Celebration Day", "Going to California"] or ["Celebration Day", "Take it easy"] or ["Going to California", "Take it easy"]
findPair(songTimes6) => ["Day and night", "Tempo song"]

Complexity Variable:
n = number of song/time pairs
*/

*/
using System;
using System.Collections.Generic;
using System.Linq;

class Solution {
static void Main(String[] args) {
var songTimes1 = new string[][] {
new string[] {"Stairway to Heaven", "8:05"}, 
new string[] {"Immigrant Song", "2:27"},
new string[] {"Rock and Roll", "3:41"}, 
new string[] {"Communication Breakdown", "2:29"},
new string[] {"Good Times Bad Times", "2:48"}, 
new string[] {"Hot Dog", "3:19"},
new string[] {"The Crunge", "3:18"}, 
new string[] {"Achilles Last Stand", "10:26"},
new string[] {"Black Dog", "4:55"}
};
var songTimes2 = new string[][] {
new string[] {"Stairway to Heaven", "8:05"}, 
new string[] {"Immigrant Song", "2:27"},
new string[] {"Rock and Roll", "3:41"}, 
new string[] {"Communication Breakdown", "2:29"},
new string[] {"Good Times Bad Times", "2:48"}, 
new string[] {"Black Dog", "4:55"},
new string[] {"The Crunge", "3:18"}, 
new string[] {"Achilles Last Stand", "10:26"},
new string[] {"The Ocean", "4:31"}, 
new string[] {"Hot Dog", "3:19"}
};
var songTimes3 = new string[][] {
new string[] {"Stairway to Heaven", "8:05"}, 
new string[] {"Immigrant Song", "2:27"},
new string[] {"Rock and Roll", "3:41"}, 
new string[] {"Communication Breakdown", "2:29"},
new string[] {"Hey Hey What Can I Do", "4:00"}, 
new string[] {"Poor Tom", "3:00"},
new string[] {"Black Dog", "4:55"}
};
var songTimes4 = new string[][] {
new string[] {"Hey Hey What Can I Do", "4:00"}, 
new string[] {"Rock and Roll", "3:41"}, 
new string[] {"Communication Breakdown", "2:29"}, 
new string[] {"Going to California", "3:30"}, 
new string[] {"On The Run", "3:50"}, 
new string[] {"The Wrestler", "3:50"}, 
new string[] {"Black Mountain Side", "2:11"}, 
new string[] {"Brown Eagle", "2:20"}
}; 
var songTimes5 = new string[][] {
new string[] {"Celebration Day", "3:30"}, 
new string[] {"Going to California", "3:30"},
new string[] {"Take it easy", "3:30"}
};
var songTimes6 = new string[][] {
new string[] {"Rock and Roll", "3:41"},
new string[] {"If I lived here", "3:59"},
new string[] {"Day and night", "5:03"},
new string[] {"Tempo song", "1:57"}
};
}
