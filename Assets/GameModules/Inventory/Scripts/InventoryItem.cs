using System;

/// <summary>
/// Immutable data class representing a type of item with a unique ID, name, and max stack size.
/// </summary>
public sealed class InventoryItem
{
    public string Id { get; }
    public string Name { get; }
    public int MaxStack { get; }

    public InventoryItem(string id, string name, int maxStack)
    {
        if (string.IsNullOrWhiteSpace(id))
            throw new ArgumentException("Item Id cannot be null or empty.", nameof(id));

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Item Name cannot be null or empty.", nameof(name));

        if (maxStack <= 0)
            throw new ArgumentOutOfRangeException(nameof(maxStack), "MaxStack must be greater than zero.");

        Id = id;
        Name = name;
        MaxStack = maxStack;
    }

    public override string ToString() => $"{Name} (x{MaxStack})";
}
