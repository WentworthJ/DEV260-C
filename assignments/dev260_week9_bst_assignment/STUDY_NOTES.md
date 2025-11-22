# Assignment 9: BST File System Navigator - Implementation Notes

**Name:** Jason Wentworth

## Binary Search Tree Pattern Understanding

**How BST operations work for file system navigation:**
[Explain your understanding of how O(log n) searches, automatic sorting through in-order traversal, and hierarchical file organization work together for efficient file management]

Answer: O(log n) searches quickly narrow down where to look in the tree, the in-order automatically sorting as the tree is explored and the structure allows distinction of files based on relationships with each other

## Challenges and Solutions

**Biggest challenge faced:**
[Describe the most difficult part of the assignment - was it recursive tree algorithms, custom file/directory comparison logic, or complex BST deletion?]

Answer: BST deletion keeping the tree valid while handling three cases

**How you solved it:**
[Explain your solution approach and what helped you figure it out - research, debugging, testing strategies, etc.]

Answer: Resaerching examples and testing smaller trees step by step

**Most confusing concept:**
[What was hardest to understand about BST operations, recursive thinking, or file system hierarchies?]

Answer: Visulizing the tree and how the recursive operations moved through it while coding.

## Code Quality

**What you're most proud of in your implementation:**
[Highlight the best aspect of your code - maybe your recursive algorithms, custom comparison logic, or efficient tree traversal]

Answer: I think the recursive traversal because it ended up working well and reusable

**What you would improve if you had more time:**
[Identify areas for potential improvement - perhaps better error handling, more efficient algorithms, or additional features]

Answer: I would improve the deletion by adding more testing to catch edge cases.

## Real-World Applications

**How this relates to actual file systems:**
[Describe how your implementation connects to tools like Windows File Explorer, macOS Finder, database indexing, etc.]

Answer: Real world file systems also rely on structured trees to organize, sort, and locate things quickly.

**What you learned about tree algorithms:**
[What insights did you gain about recursive thinking, tree traversal, and hierarchical data organization?]

Answer: I learned that recursive thinking makes teaversing the tree feel natural, and hierarchical data is much easier to manage when it's guideded by the tree for how you search and organize it.

## Stretch Features

[If you implemented any extra credit features like file pattern matching or directory size analysis, describe them here. If not, write "None implemented"]

Answer:

## Time Spent

**Total time:** [~4.5 hours]

**Breakdown:**

- Understanding BST concepts and assignment requirements: [X hours]
- Implementing the 8 core TODO methods: [X hours]
- Testing with different file scenarios: [X hours]
- Debugging recursive algorithms and BST operations: [X hours]
- Writing these notes: [X hours]

**Most time-consuming part:** [Which aspect took the longest and why - recursive thinking, BST deletion, custom comparison logic, etc.]

Working on the BST deletion