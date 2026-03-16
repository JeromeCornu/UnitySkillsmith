UnitySkillsmith
================

Clean C# Gameplay Systems for Unity

UnitySkillsmith is a technical sandbox repository designed to showcase clean, maintainable gameplay code for Unity.

This project focuses on architecture, readability, and extensibility rather than building a complete game.  
It is intended as a quick way for developers or recruiters to evaluate how gameplay systems are structured and implemented.

The repository currently contains two independent systems:
- A modular Ability System
- A stack-based Inventory System

All examples are intentionally console-driven (no UI) so the focus remains entirely on code structure and logic.



Quick Look
----------

Ability System
- ScriptableObject-driven architecture
- Runtime context-based execution
- Modular gameplay effects
- Cooldown and resource validation pipeline

Inventory System
- Stack-based inventory logic
- Immutable item definitions
- Clean object-oriented design
- Predictable add/remove behavior



Goals of this Repository
------------------------

This project exists to demonstrate:

- Clean and readable C# code
- Clear separation of responsibilities
- Modular gameplay system architecture
- Safe runtime data passing
- Scalable system design
- Extensible gameplay features
- Code written with production-quality structure

The systems are intentionally small and focused so that their architecture can be easily evaluated.



================
Systems Included
================


Ability System
--------------

A modular ability framework designed for Unity using ScriptableObjects and runtime context passing.

This system demonstrates how gameplay abilities can be designed in a scalable and data-driven way.

Typical use cases include:
- RPG ability systems
- Action combat abilities
- Roguelike skill systems
- Modular gameplay mechanics



Inventory System
--------------

A compact stack-based inventory system designed with object-oriented principles.
The system focuses on clarity and predictable behavior rather than UI presentation.
All interactions are logged to the console.


Key Design Principles:
- Immutable item definitions
- Clear object-oriented structure
- Separation between data and logic
- Stack-based item management
- Testable components


Example Behavior:
- Adding stackable items
- Automatically merging stacks
- Safely removing quantities
- Displaying the inventory state in console output



Technologies
============

Unity  
C#  
ScriptableObjects  
Interface-based architecture  
Object-oriented design  



Why This Repository Exists
==========================

Game development portfolios often showcase finished games, but evaluating code quality from a compiled build can be difficult.

This repository exists to provide a focused, readable code sample demonstrating how gameplay systems are structured.

It is meant to be quick to explore and easy to evaluate.



Author
======

Jérôme Cornu  
Technical Game Designer — Unity / Unreal

Portfolio  
https://jeromecornu.github.io/page/en/index_eng.html

GitHub  
https://github.com/JeromeCornu
