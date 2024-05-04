using System.Diagnostics;

public static class Priority
{
    public static void Test()
    {
        // TODO Problem 2 - Write and run test cases and fix the code to match requirements
        // Example of creating and using the priority queue
        var priorityQueue = new PriorityQueue();
        Console.WriteLine(priorityQueue);

        // Test Cases

        // Test 1
        // Scenario: Insert multiple items with different priorities and remove them in order
        // Expected Result: should remove items in order of highest priority, Tim, Sue, Bob
        Console.WriteLine("Test 1");
        priorityQueue.Enqueue("Bob", 2);
        priorityQueue.Enqueue("Tim", 5);
        priorityQueue.Enqueue("Sue", 3);
        Console.WriteLine(priorityQueue);

        Trace.Assert(priorityQueue.Dequeue() == "Tim", "Expected Tim");
        Trace.Assert(priorityQueue.Dequeue() == "Sue", "Expected Sue");
        Trace.Assert(priorityQueue.Dequeue() == "Bob", "Expected Bob");

        // Defect(s) Found: Object is not actually removed from the queue

        Console.WriteLine("---------");

        // Test 2
        // Scenario: Add items with the same priority
        // Expected Result: should remove items in order or priority then insertion for items with the same priority, expecting Tim, Sue, Bob, Alice
        Console.WriteLine("Test 2");
        priorityQueue.Enqueue("Bob", 2);
        priorityQueue.Enqueue("Tim", 5);
        priorityQueue.Enqueue("Sue", 5);
        priorityQueue.Enqueue("Alice", 1);

        Trace.Assert(priorityQueue.Dequeue() == "Tim", "Expected Tim");
        Trace.Assert(priorityQueue.Dequeue() == "Sue", "Expected Sue");
        Trace.Assert(priorityQueue.Dequeue() == "Bob", "Expected Bob");
        Trace.Assert(priorityQueue.Dequeue() == "Alice", "Expected Alice");
        // Defect(s) Found: Needed to remove the = in the if statement of the dequeue method

        Console.WriteLine("---------");

        // Add more Test Cases As Needed Below
    }
}