using System;
using System.Collections;
 
public class OrderProcessor
{
    public void ProcessOrders()
    {
        // Using List<int> for better type safety and performance than ArrayList
        // if the type of elements is known.
        // Assuming 'orderIds' should contain integers based on the 'int orderId = (int)id;' line.
        // If order IDs can be other types, consider a List<object> or a more specific generic type.
        // For a large number of elements (100,000 as indicated in the original loop),
        // pre-allocating capacity can improve performance slightly, though not strictly necessary.
        List<int> orderIds = new List<int>(100000);
 
        // Populating the list with sample order IDs (as per the original code's implied loop)
        for (int i = 0; i < 100000; i++)
        {
            orderIds.Add(i);
        }
 
        // Iterating through the order IDs.
        // Using 'int id' directly in the foreach loop avoids the need for explicit casting
        // if 'orderIds' is a List<int>, improving type safety and potentially performance.
        foreach (int id in orderIds)
        {
            int orderId = id; // No explicit cast needed if 'id' is already an int.
 
            // Process order...
            // This is a placeholder for the actual order processing logic.
            // For a performance issue, this section would be the primary focus for optimization.
            // Example: Console.WriteLine($"Processing order: {orderId}");
        }
    }
}