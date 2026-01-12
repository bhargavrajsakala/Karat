/*

You are planning a trek across a snowy mountain. Each day:

- In the **morning**, snow falls on some positions.
- In the **afternoon**, if a location has not received snow for 2 days, its snow begins to melt (1 unit per day).
- In the **evening**, the player may attempt a crossing.

Rules:
- Snow increases the altitude at that location.
- You can climb up or down **at most one level** when moving to the next position.
- The goal is to cross the mountain with the **least number of climbs**.
- The forecast is limited; later days are unpredictable.

Write a function that, given:
- base altitudes of the mountain, and
- a daily forecast of snowfall per position,  

returns the best day (0-indexed) and the number of climbs needed.  
If no crossing is possible, return [-1, -1].

---

**Example**:  

Altitudes: [0,1,2,1]  
Snow forecast:

```
Day 0: [1,0,1,0]
Day 1: [0,0,0,0]
Day 2: [1,1,0,2]
```

Evening profiles:

- Day 0: Too steep → no crossing
- Day 1: No changes → still no crossing
- Day 2: Melting begins, crossing possible with **1 climb** → result [2, 1]

---

**Expected Results**:

- best_day_to_cross(altitudes_1, snow_1) → [2, 1]  
- best_day_to_cross(altitudes_2, snow_2) → [0, 0]  
- best_day_to_cross(altitudes_3, snow_3) → [2, 0]  
- best_day_to_cross(altitudes_4, snow_4) → [-1, -1]  
- best_day_to_cross(altitudes_5, snow_5) → [5, 1]  
- best_day_to_cross(altitudes_6, snow_6) → [0, 4]  

Complexity variables:  
- A = number of altitude positions  
- D = number of forecast days
      
*/
using System;
using System.Collections.Generic;
using System.Linq;
class Solution {
    static void Main(String[] args) {
        int[] altitudes_1 = new int[] {0, 1, 2, 1};
        int[][] snow_1 = new int[][] {
            new int[] {1, 0, 1, 0},
            new int[] {0, 0, 0, 0},
            new int[] {1, 1, 0, 2}
        };

        int[] altitudes_2 = new int[] {0, 0, 0, 0};
        int[][] snow_2 = new int[][] {
            new int[] {2, 2, 2, 2},
            new int[] {1, 0, 0, 0},
            new int[] {1, 0, 0, 0}
        };

        int[] altitudes_3 = new int[] {0, 0, 0, 1};
        int[][] snow_3 = new int[][] {
            new int[] {0, 0, 2, 0},
            new int[] {1, 1, 0, 0},
            new int[] {0, 0, 0, 0},
            new int[] {1, 1, 1, 0}
        };

        int[] altitudes_4 = new int[] {0, 1, 2, 0};
        int[][] snow_4 = new int[][] {
            new int[] {1, 0, 0, 0},
            new int[] {0, 1, 0, 0}
        };

        int[] altitudes_5 = new int[] {0, 0, 0};
        int[][] snow_5 = new int[][] {
            new int[] {5, 5, 0},
            new int[] {0, 0, 0},
            new int[] {0, 0, 0},
            new int[] {0, 0, 0},
            new int[] {0, 0, 0},
            new int[] {0, 0, 0}
        };

        int[] altitudes_6 = new int[] {0, 0, 0, 0, 0};
        int[][] snow_6 = new int[][] {
            new int[] {2, 1, 2, 1, 2}
        };
        
        }
    }
