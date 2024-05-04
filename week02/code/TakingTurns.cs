using System.Diagnostics;
using System.Xml.XPath;

public static class TakingTurns
{
    public static void Test()
    {
        // TODO Problem 1 - Run test cases and fix the code to match requirements
        // Test Cases
        int j = 0;
        // Test 1
        // Scenario: Create a queue with the following people and turns: Bob (2), Tim (5), Sue (3) and
        // run until the queue is empty
        // Expected Result: Bob, Tim, Sue, Bob, Tim, Sue, Tim, Sue, Tim, Tim
        Console.WriteLine("Test 1");
        var players = new TakingTurnsQueue();
        players.AddPerson("Bob", 2);
        players.AddPerson("Tim", 5);
        players.AddPerson("Sue", 3);
        // Console.WriteLine(players);    // This can be un-commented out for debug help
        List<string> expected1 = new List<string> { "Bob", "Tim", "Sue", "Bob", "Tim", "Sue", "Tim", "Sue", "Tim", "Tim" };
        while (players.Length > 0)
        {
            var result = players.GetNextPerson();
            Trace.Assert(result == expected1[j], $"Expected {expected1[j]} and got {result}");
            j++;
        }
        // Defect(s) Found: 
        // Test failed because people were not inserted at the end of the queue.
        // This caused the program to go through the queue in the wrong order.

        Console.WriteLine("---------");

        // Test 2
        // Scenario: Create a queue with the following people and turns: Bob (2), Tim (5), Sue (3)
        // After running 5 times, add George with 3 turns.  Run until the queue is empty.
        // Expected Result: Bob, Tim, Sue, Bob, Tim, Sue, Tim, George, Sue, Tim, George, Tim, George
        Console.WriteLine("Test 2");
        players = new TakingTurnsQueue();
        players.AddPerson("Bob", 2);
        players.AddPerson("Tim", 5);
        players.AddPerson("Sue", 3);

        List<string> expected2 = new List<string> { "Bob", "Tim", "Sue", "Bob", "Tim" };
        List<string> expected3 = new List<string> { "Sue", "Tim", "George", "Sue", "Tim", "George", "Tim", "George" };
        for (int i = 0; i < 5; i++)
        {
            var result = players.GetNextPerson();
            Trace.Assert(result == expected2[i], $"Expected {expected2[i]} and got {result}");
            // Console.WriteLine(players);
        }

        players.AddPerson("George", 3);
        // Console.WriteLine(players);
        j = 0;
        while (players.Length > 0)
        {
            var result = players.GetNextPerson();
            Trace.Assert(result == expected3[j], $"Expected {expected3[j]} and got {result}");
            j++;
        }
        // Defect(s) Found: 

        Console.WriteLine("---------");

        // Test 3
        // Scenario: Create a queue with the following people and turns: Bob (2), Tim (Forever), Sue (3)
        // Run 10 times.
        // Expected Result: Bob, Tim, Sue, Bob, Tim, Sue, Tim, Sue, Tim, Tim
        Console.WriteLine("Test 3");
        players = new TakingTurnsQueue();
        players.AddPerson("Bob", 2);
        players.AddPerson("Tim", 0);
        players.AddPerson("Sue", 3);
        // Console.WriteLine(players);
        List<string> expected4 = new List<string> { "Bob", "Tim", "Sue", "Bob", "Tim", "Sue", "Tim", "Sue", "Tim", "Tim" };
        for (int i = 0; i < 10; i++)
        {
            var result = players.GetNextPerson();
            Trace.Assert(result == expected4[i], $"Expected {expected4[i]} and got {result}");
            // Console.WriteLine(players);
        }
        // Defect(s) Found: 
        // Test failed because there was not a statment checking if a user has infinite turns.
        // This caused the program to not add the user back to the queue.

        Console.WriteLine("---------");

        // Test 4
        // Scenario: Create a queue with the following people and turns: Tim (Forever), Sue (3)
        // Run 10 times.
        // Expected Result: Tim, Sue, Tim, Sue, Tim, Sue, Tim, Tim, Tim, Tim
        Console.WriteLine("Test 4");
        players = new TakingTurnsQueue();
        players.AddPerson("Tim", -3);
        players.AddPerson("Sue", 3);
        // Console.WriteLine(players);
        List<string> expected5 = new List<string> { "Tim", "Sue", "Tim", "Sue", "Tim", "Sue", "Tim", "Tim", "Tim", "Tim" };
        for (int i = 0; i < 10; i++)
        {
            var result = players.GetNextPerson();
            Trace.Assert(result == expected5[i], $"Expected {expected5[i]} and got {result}");
            // Console.WriteLine(players);
        }
        // Defect(s) Found: 

        Console.WriteLine("---------");

        // Test 5
        // Scenario: Try to get the next person from an empty queue
        // Expected Result: Error message should be displayed
        Console.WriteLine("Test 5");
        players = new TakingTurnsQueue();
        var emptyQueue = players.GetNextPerson();

        Trace.Assert(emptyQueue == null, "Queue should be empty");
        // Defect(s) Found:
    }
}