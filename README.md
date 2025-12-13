# DEV 260: Data Structures & Algorithms in C#

**Student:** Jason Wentworth 

**Term:** Fall 2025 - Bellevue College

**Instructor:** Zak Brinlee

---

## About This Repository

This repository contains the various assignments I have submitted for my class. The projects show examples of my understanding of Queues, Stacks, Hashsets, Binary Search Trees, and other concepts I learned from this class.

---

## Projects

### Labs

- **Lab Loops and Conditionals:** Practice using different kinds of loops (for, while, foreach) and conditionals (if/else, switch) in C#

- **Lab Stacks:** An interactive Stack<T> application with undo/redo functionality

- **Lab Queues:** Interactive Queue<T> application featuring an IT Support Desk Queue system that focuses on understanding the First In, First Out (FIFO) principle.

- **Lab Hashsets:** Interactive HashSet<T> application featuring User Management & Permissions System with email deduplication and enrollment analysis

- **Lab Trees:** An interactive Binary Search Tree application featuring Company Employee Management System with efficient searching, sorting, and hierarchical organization.


### Assignments

- **Assignment DS Foundations:** Choosing appropriate data structures to test for time complexity

- **Assignment Linked Lists:** Creating a linked list from scratch to test it's use cases.

- **Assignment Stacks:** A Browser Navigation System made with stacks that simulates how web browsers handle back/forward navigation

- **Assignment Queues:** A Game Matchmaking System using understanding of Queue<T> concepts to create.

- **Assignment Hashsets:** A spellchecker using Hashsets with words in the dictionary.txt file

- **Assignment Graphs:** Flight Network Management System using concepts of graphs based in real world examples.


### Final Project

**Library Lending System**

A console-based management system for a library that allows users to add, update, borrow, and return books, with automatic waitlist handling. It uses
- `Dictionary<string, Book>` → Fast lookup by ISBN for add, update, delete, and borrow logic.
- `List<Book>` → Stores the full catalog and supports title searching and display.
- `Queue<BorrowRequest>` → Manages the waitlist for each book in FIFO order.
- `List<Borrower>` → Stores all borrowers and avoids duplicate borrower entries.

📁 [View Final Project](./final_project/)


---


## Skills Demonstrated

- C# programming fundamentals

- Data structures: Lists, Dictionaries, HashSets, Queues, Stacks, Graphs

- Algorithm implementation: BFS, Dijkstra's, Binary Search

- File I/O and CSV parsing

- Object-oriented design

- Manual testing and debugging


---

## How to Run

Each project contains its own README with specific build and run instructions.

**General steps:**

```bash

cd [project-directory]

dotnet build

dotnet run

```
