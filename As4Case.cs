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
      
