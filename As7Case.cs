using System;
using System.Collections.Generic;
using System.Linq; // Required for LINQ methods like Any(), Average(), GroupBy()
 
public enum MembershipStatus
{
    BASIC = 1,
    PRO = 2,
    ELITE = 3
}
 
public class Member
{
    public int MemberId { get; private set; }
    public string Name { get; private set; }
    public MembershipStatus MembershipStatus { get; set; } // Set is public for UpdateMembership
 
    public Member(int memberId, string name, MembershipStatus membershipStatus)
    {
        MemberId = memberId;
        Name = name;
        MembershipStatus = membershipStatus;
    }
 
    public override string ToString()
    {
        return $"Member ID: {MemberId}, Name: {Name}, Membership Status: {MembershipStatus}";
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
    private Dictionary<int, List<Workout>> workoutRegister; // Key: MemberId, Value: List of Workouts
 
    public Membership()
    {
        members = new List<Member>();
        workoutRegister = new Dictionary<int, List<Workout>>();
    }
 
    public void AddMember(Member member)
    {
        members.Add(member);
    }
 
    public void UpdateMembership(int memberId, MembershipStatus membershipStatus)
    {
        Member memberToUpdate = members.Find(member => member.MemberId == memberId);
        if (memberToUpdate == null)
        {
            throw new ArgumentException($"Member with ID {memberId} not found.");
        }
        memberToUpdate.MembershipStatus = membershipStatus;
    }
 
    public Dictionary<string, double> GetMembershipStatistics()
    {
        int totalMembers = members.Count;
        int totalPaidMembers = members.Count(member => member.MembershipStatus == MembershipStatus.PRO || member.MembershipStatus == MembershipStatus.ELITE);
        double conversionRate = (totalMembers > 0) ? (double)totalPaidMembers / totalMembers * 100 : 0.0;
 
        return new Dictionary<string, double>
        {
            { "total_members", totalMembers },
            { "total_paid_members", totalPaidMembers },
            { "conversion_rate", conversionRate }
        };
    }
 
    // New Function: AddWorkout
    public void AddWorkout(int memberId, Workout workout)
    {
        // Check if the member exists
        Member existingMember = members.Find(m => m.MemberId == memberId);
        if (existingMember == null)
        {
            // If member does not exist, ignore the workout
            Console.WriteLine($"Warning: Member with ID {memberId} not found. Workout ignored.");
            return;
        }
 
        // Add the workout to the workoutRegister for the specific member
        if (!workoutRegister.ContainsKey(memberId))
        {
            workoutRegister[memberId] = new List<Workout>();
        }
        workoutRegister[memberId].Add(workout);
        Console.WriteLine($"Workout {workout.Id} added for Member {memberId}.");
    }
 
    // New Function: GetAverageWorkoutDurations
    public Dictionary<int, double> GetAverageWorkoutDurations()
    {
        Dictionary<int, double> averageDurations = new Dictionary<int, double>();
 
        foreach (var entry in workoutRegister)
        {
            int memberId = entry.Key;
            List<Workout> workouts = entry.Value;
 
            if (workouts.Any()) // Ensure there are workouts to avoid division by zero
            {
                double averageDuration = workouts.Average(w => w.GetDuration());
                averageDurations[memberId] = averageDuration;
            }
            else
            {
                averageDurations[memberId] = 0.0; // Or handle as per requirement if no workouts
            }
        }
        return averageDurations;
    }
}
 
// Test Suite (from provided images, with minor adjustments for execution)
public class TestSuite
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Running All Tests:");
        TestMember();
        TestMembership();
        TestGetAverageWorkoutDurations();
 
        Console.WriteLine("\nAll tests completed. Press any key to exit.");
        Console.ReadKey();
    }
 
    public static void TestMember()
    {
        Console.WriteLine("\n--- Running TestMember ---");
        Member testMember = new Member(1, "John Doe", MembershipStatus.BASIC);
 
        System.Diagnostics.Debug.Assert(testMember.MemberId == 1, "TestMemberId Failed");
        System.Diagnostics.Debug.Assert(testMember.Name == "John Doe", "TestMemberName Failed");
        System.Diagnostics.Debug.Assert(testMember.MembershipStatus == MembershipStatus.BASIC, "TestMembershipStatus Failed");
 
        Console.WriteLine("TestMember Passed.");
    }
 
    public static void TestMembership()
    {
        Console.WriteLine("\n--- Running TestMembership ---");
        Membership testMembership = new Membership();
 
        Member testMember = new Member(1, "John Doe", MembershipStatus.BASIC);
        testMembership.AddMember(testMember);
 
        Dictionary<string, double> initialStats = testMembership.GetMembershipStatistics();
        System.Diagnostics.Debug.Assert(initialStats["total_members"] == 1, "Initial total_members failed");
        System.Diagnostics.Debug.Assert(initialStats["total_paid_members"] == 0, "Initial total_paid_members failed");
 
        // Test UpdateMembership (Bug fix part)
        testMembership.UpdateMembership(1, MembershipStatus.PRO);
        Dictionary<string, double> updatedStats = testMembership.GetMembershipStatistics();
        System.Diagnostics.Debug.Assert(updatedStats["total_paid_members"] == 1, "UpdateMembership PRO failed");
 
        Member testMember2 = new Member(2, "Alex C", MembershipStatus.BASIC);
        testMembership.AddMember(testMember2);
 
        Member testMember3 = new Member(3, "Marie C", MembershipStatus.ELITE);
        testMembership.AddMember(testMember3);
 
        Member testMember4 = new Member(4, "Joe D", MembershipStatus.PRO);
        testMembership.AddMember(testMember4);
 
        Dictionary<string, double> attendanceStats = testMembership.GetMembershipStatistics();
        System.Diagnostics.Debug.Assert(attendanceStats["total_members"] == 4, "Total members after additions failed");
        System.Diagnostics.Debug.Assert(attendanceStats["total_paid_members"] == 3, "Total paid members after additions failed");
        // Math.Abs for floating point comparison
        System.Diagnostics.Debug.Assert(Math.Abs(attendanceStats["conversion_rate"] - 75.00) < 0.1, "Conversion rate failed");
 
        Console.WriteLine("TestMembership Passed.");
    }
 
    public static void TestGetAverageWorkoutDurations()
    {
        Console.WriteLine("\n--- Running TestGetAverageWorkoutDurations ---");
        Membership testMembership = new Membership();
 
        // Add members
        Member testMember1 = new Member(11, "John Doe", MembershipStatus.PRO);
        testMembership.AddMember(testMember1);
 
        Member testMember2 = new Member(22, "Alex C", MembershipStatus.BASIC);
        testMembership.AddMember(testMember2);
 
        Member testMember3 = new Member(31, "Marie C", MembershipStatus.ELITE);
        testMembership.AddMember(testMember3);
 
        // Define workouts
        Workout workout1 = new Workout(1, 10, 20);  // Duration: 10
        Workout workout2 = new Workout(2, 15, 35);  // Duration: 20
        Workout workout3 = new Workout(3, 20, 90);  // Duration: 70
        Workout workout4 = new Workout(4, 100, 155); // Duration: 55
        Workout workout5 = new Workout(5, 120, 200); // Duration: 80
        Workout workout6 = new Workout(6, 300, 610); // Duration: 310
        Workout workout7 = new Workout(7, 2000, 2010); // Duration: 10
        Workout workout8 = new Workout(8, 2010, 2045); // Duration: 35
 
        // Add workouts to members
        testMembership.AddWorkout(11, workout1);
        testMembership.AddWorkout(22, workout2);
        testMembership.AddWorkout(31, workout3);
        testMembership.AddWorkout(11, workout4); // Member 11 gets another workout
        testMembership.AddWorkout(22, workout5); // Member 22 gets another workout
        testMembership.AddWorkout(31, workout6); // Member 31 gets another workout
        testMembership.AddWorkout(11, workout7); // Member 11 gets another workout
        testMembership.AddWorkout(4, workout8); // This workout should be ignored as member 4 does not exist
 
        // Get average workout durations
        Dictionary<int, double> averageDurations = testMembership.GetAverageWorkoutDurations();
 
        // Assertions for average durations
        // Member 11: (10 + 55 + 10) / 3 = 75 / 3 = 25
        System.Diagnostics.Debug.Assert(Math.Abs(averageDurations[11] - 25.0) < 0.1, "Avg for Member 11 failed");
 
        // Member 22: (20 + 80) / 2 = 100 / 2 = 50
        System.Diagnostics.Debug.Assert(Math.Abs(averageDurations[22] - 50.0) < 0.1, "Avg for Member 22 failed");
 
        // Member 31: (70 + 310) / 2 = 380 / 2 = 190
        System.Diagnostics.Debug.Assert(Math.Abs(averageDurations[31] - 190.0) < 0.1, "Avg for Member 31 failed");
 
        // Assert that member 4 (non-existent) is not in the dictionary, or its average is 0 if it was implicitly added and empty
        // In this implementation, non-existent members won't have entries if they never had workouts added successfully.
        System.Diagnostics.Debug.Assert(!averageDurations.ContainsKey(4), "Non-existent member 4 should not have an average.");
 
        Console.WriteLine("TestGetAverageWorkoutDurations Passed.");
    }
}