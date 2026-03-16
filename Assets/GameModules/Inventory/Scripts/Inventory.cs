using System;
using System.Collections.Generic;

/// <summary>
/// Manages a collection of item stacks with a fixed slot limit.
/// Adds to existing stacks first and prevents partial adds.
/// </summary>
public class Inventory
{
    private readonly List<InventoryStack> _stacks = new();
    private readonly int _maxSlots;

    // Constructor with configurable max slots (default: 10)
    public Inventory(int maxSlots = 10)
    {
        if (maxSlots <= 0)
            throw new ArgumentOutOfRangeException(nameof(maxSlots), "Inventory must have at least one slot.");

        _maxSlots = maxSlots;
    }

    // Adds an item to the inventory
    public bool AddItem(InventoryItem item, int quantity)
    {
        if (item == null || quantity <= 0)
            return false;

        int remaining = quantity;

        // Step 1: Try to add to existing stacks of the same item
        foreach (InventoryStack stack in _stacks)
        {
            if (stack.Item.Id != item.Id)
                continue;

            int spaceLeft = item.MaxStack - stack.Quantity;

            if (spaceLeft > 0)
            {
                int toAdd = Math.Min(spaceLeft, remaining);
                stack.Add(toAdd);
                remaining -= toAdd;

                if (remaining == 0)
                    return true; // All items added successfully
            }
        }

        // Step 2: Add new stacks if there's room left in the inventory
        while (remaining > 0)
        {
            if (_stacks.Count >= _maxSlots)
                return false; // Inventory is full, can't add more stacks

            int toAdd = Math.Min(item.MaxStack, remaining);
            InventoryStack newStack = new InventoryStack(item, toAdd);
            _stacks.Add(newStack);
            remaining -= toAdd;
        }

        return true; // All items added after creating new stacks
    }

    // Removes a quantity of a specific item by its ID
    public bool RemoveItem(string itemId, int quantity)
    {
        if (string.IsNullOrWhiteSpace(itemId) || quantity <= 0)
            return false;

        // Step 1: Find all stacks matching the item
        List<InventoryStack> matchingStacks = new List<InventoryStack>();

        foreach (InventoryStack stack in _stacks)
        {
            if (stack.Item.Id == itemId)
            {
                matchingStacks.Add(stack);
            }
        }

        if (matchingStacks.Count == 0)
            return false; // No stack found

        // Step 2: Sort stacks to remove from smallest first
        matchingStacks.Sort((a, b) => a.Quantity.CompareTo(b.Quantity));

        int remaining = quantity;

        foreach (InventoryStack stack in matchingStacks)
        {
            int toRemove = Math.Min(stack.Quantity, remaining);
            stack.Remove(toRemove);
            remaining -= toRemove;

            if (stack.Quantity == 0)
                _stacks.Remove(stack);

            if (remaining == 0)
                break;
        }

        // Return true only if the full quantity was removed
        return remaining == 0;
    }


    // Returns the total quantity of an item by its ID
    public int GetTotalQuantity(string itemId)
    {
        int total = 0;

        foreach (InventoryStack stack in _stacks)
        {
            if (stack.Item.Id == itemId)
                total += stack.Quantity;
        }

        return total;
    }

    // Returns a readable string of the inventory contents
    public override string ToString()
    {
        if (_stacks.Count == 0)
            return $"Inventory is empty. (0 / {_maxSlots} stacks used)";

        string result = $"Inventory contents ({_stacks.Count}/{_maxSlots} stacks used):\n";
        foreach (InventoryStack stack in _stacks)
        {
            result += "- " + stack.ToString() + "\n";
        }
        return result.TrimEnd();
    }

}
