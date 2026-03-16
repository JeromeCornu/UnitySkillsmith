using System;

/// <summary>
/// Holds a stack of a specific item and tracks its quantity.
/// Enforces MaxStack limit and provides safe add/remove methods.
/// </summary>
public class InventoryStack
{
    public InventoryItem Item { get; }
    public int Quantity { get; private set; }

    public InventoryStack(InventoryItem item, int initialQuantity = 0)
    {
        Item = item ?? throw new ArgumentNullException(nameof(item));

        if (initialQuantity < 0 || initialQuantity > item.MaxStack)
            throw new ArgumentOutOfRangeException(nameof(initialQuantity), $"Initial quantity must be between 0 and {item.MaxStack}.");

        Quantity = initialQuantity;
    }

    public bool CanAdd(int amount)
    {
        if (amount <= 0) return false;
        return Quantity + amount <= Item.MaxStack;
    }

    public bool Add(int amount)
    {
        if (!CanAdd(amount)) return false;
        Quantity += amount;
        return true;
    }

    public bool CanRemove(int amount)
    {
        return amount > 0 && amount <= Quantity;
    }

    public bool Remove(int amount)
    {
        if (!CanRemove(amount)) return false;
        Quantity -= amount;
        return true;
    }

    public override string ToString()
    {
        return $"{Item.Name} x{Quantity}/{Item.MaxStack}";
    }
}
