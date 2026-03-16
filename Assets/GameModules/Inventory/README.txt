InventorySystem
=================================================

A compact and clean inventory system for Unity, focusing on object-oriented design, immutability, and separation of concerns.

What it demonstrates:
- Stack-based inventory (like in Minecraft)
- No UI, 100% console driven
- Data-only item definitions
- Reusable, testable, and ready for extensions (crafting, saving, UI...)

---

Main Components:

InventoryItem:
- Id, Name, MaxStack
- Immutable after creation

InventoryStack:
- Holds an InventoryItem and a quantity
- Add(), Remove(), CanAdd(), CanRemove()
- Never exceeds MaxStack

Inventory:
- Holds a list of InventoryStacks (limited to a max number of slots)
- Adds to existing stacks before creating new ones
- Removes from smallest stacks first
- Console-friendly output with a clear ToString()

InventoryTester:
- Runs at Start()
- Adds, removes and displays items using Debug.Log
- Simulates real game logic in a testable way

---

Example Scenario: in InventoryTester

---

Why it's useful:
- Demonstrates understanding of immutability and clean update logic
- Base for crafting or save systems

