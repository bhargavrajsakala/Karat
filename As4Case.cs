/*

We are building a program to manage a gym's membership. The gym has multiple members, each with a unique ID, name, and membership status. The program allows gym staff to add new members, update member status, and get membership statistics.

Recently, the system has been updated to include information about workouts for members. Each Workout object represents a single session with a unique ID, start time, and end time (in minutes from the start of the day). You need to implement:

1) AddWorkout: Add a workout session for a member. If the member does not exist, ignore the workout.
2) GetAverageWorkoutDurations: Calculate the average duration of workouts for each member and return as a dictionary/map.

Example:
- Member 12 has workouts of durations 10, 55, and 10 minutes → average = 25.
- Member 22 has workouts 20 and 80 → average = 50.
- Member 31 has workouts 40 and 100 → average = 70.
- Member 4 does not exist → ignored.
      
*/

using System;
using System.Collections.Generic;

public enum MembershipStatus
{
    BASIC = 1,
    PRO = 2,
    ELITE = 3
}

public class Member
{
    public int MemberId { get; set; }
    public string Name { get; set; }
    public MembershipStatus MembershipStatus { get; set; }

    public Member(int memberId, string name, MembershipStatus membershipStatus)
    {
        MemberId = memberId;
        Name = name;
        MembershipStatus = membershipStatus;
    }
}

public class Workout
{
    public int Id { get; private set; }
    public int StartTime { get; private set; }
    public int EndTime { get; private set; }

    public Workout(int id, int startTime, int endTime)
    {
        Id = id;
        StartTime = startTime;
        EndTime = endTime;
    }

    public int GetDuration()
    {
        return EndTime - StartTime;
    }
}

public class Membership
{
    private List<Member> members;
   public Membership()
    {
        members = new List<Member>();
    }

    public void AddMember(Member member)
    {
        members.Add(member);
    }

    public void AddWorkout(int memberId, Workout workout)
    {
        // TODO: Implement this function
    }

    public Dictionary<int, double> GetAverageWorkoutDurations()
    {
        // TODO: Implement this function
        return new Dictionary<int, double>();
    }
}

solution:
“The problem is to manage gym members and their workout sessions.
Each member can have multiple workouts, and each workout has a start and end time.
 “I stored members in a list and workouts in a dictionary.
The dictionary key is the member ID, and the value is a list of workouts for that member.”
 “When adding a workout, I first check if the member exists by looping through the members list and matching the member ID.”
 “If the member doesn’t exist, I immediately return, so invalid workouts are ignored.”
 “If the member exists, I check whether the dictionary already has an entry for that member.
If not, I create a new list and then add the workout.”
in getaverageworkouts “To calculate averages, I loop through each entry in the workouts dictionary.”
“I handled edge cases like:
Workouts for non-existent members
Multiple workouts per member
Correct average calculation using double division”


    public void AddWorkout(int memberId, Workout workout)
    {
        // 1) Check if member exists
        bool memberExists = false;
        for (int i = 0; i < members.Count; i++)
        {
            if (members[i].MemberId == memberId)
            {
                memberExists = true;
                break;
            }
        }

        // If member doesn't exist, ignore
        if (!memberExists)
            return;

        // 2) Add workout
        if (!workoutsByMember.ContainsKey(memberId))
        {
            workoutsByMember[memberId] = new List<Workout>();
        }

        workoutsByMember[memberId].Add(workout);
    }

    public Dictionary<int, double> GetAverageWorkoutDurations()
    {
        Dictionary<int, double> result = new Dictionary<int, double>();

        foreach (KeyValuePair<int, List<Workout>> entry in workoutsByMember)
        {
            int memberId = entry.Key;
            List<Workout> workoutList = entry.Value;

            int totalDuration = 0;
            for (int i = 0; i < workoutList.Count; i++)
            {
                totalDuration += workoutList[i].GetDuration();
            }

            double avgDuration = (double)totalDuration / workoutList.Count;
            result.Add(memberId, avgDuration);
        }

        return result;
    }
}

      
