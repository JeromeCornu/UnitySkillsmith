using UnityEngine;

/// <summary>
/// MonoBehaviour that tests the Inventory system by simulating item additions and removals.
/// Attach this script to an empty GameObject to run the test in the Unity Console.
/// </summary>
public class InventoryTester : MonoBehaviour
{
    private Inventory _inventory;

    // Sample items
    private InventoryItem _apple;
    private InventoryItem _wood;
    private InventoryItem _stone;

    void Start()
    {
        // Initialize items
        _apple = new InventoryItem("apple", "Apple", 5);
        _wood = new InventoryItem("wood", "Wood", 10);
        _stone = new InventoryItem("stone", "Stone", 20);

        // Create inventory with 10 stack slots max
        _inventory = new Inventory(10);

        Debug.Log("=== Inventory Test Started ===");

        // Add items
        Debug.Log("Adding 3 apples...");
        _inventory.AddItem(_apple, 3);

        Debug.Log("Adding 4 apples...");
        _inventory.AddItem(_apple, 4); // should split into (5 + 2)

        Debug.Log("Adding 15 wood...");
        _inventory.AddItem(_wood, 15); // (10 + 5)

        Debug.Log("Adding 50 stone...");
        _inventory.AddItem(_stone, 50); // should create 3 stacks (20 + 20 + 10)

        Debug.Log("Adding 1000 stone...");
        bool stoneCrashTestResult = _inventory.AddItem(_stone, 1000); // should fail (but still add the stone)

        Debug.Log($"Adding all stone result: {stoneCrashTestResult}");

        // Current inventory
        Debug.Log(_inventory.ToString());

        // Remove some items
        Debug.Log("Removing 4 apples...");
        _inventory.RemoveItem("apple", 4);

        Debug.Log("Removing 10 wood...");
        _inventory.RemoveItem("wood", 10);

        Debug.Log("Removing 1000 stone...");
        bool stoneCrashTestRemove = _inventory.RemoveItem("stone", 1000); // should fail (but still remove the stone)

        Debug.Log($"Removing all stone result: {stoneCrashTestRemove}");

        // Inventory after removals
        Debug.Log(_inventory.ToString());


        // Check quantities
        int appleQty = _inventory.GetTotalQuantity("apple");
        Debug.Log($"Total apples left: {appleQty}");

        Debug.Log("=== Inventory Test Complete ===");
    }
}
