# Assignment 6: Game Matchmaking System - Implementation Notes

**Name:** Jason Wentworth

## Multi-Queue Pattern Understanding

**How the multi-queue pattern works for game matchmaking:**
[Explain your understanding of how the three different queues (Casual, Ranked, QuickPlay) work together and why each has different matching strategies]
The multi-queue pattern keeps multiple queues as waiting lines for players, with the casual queue acting by simply matching the first players
by first in first out. Ranked is more strict by only matching players with skill levels that are simliar. For instancewithin 2 above or below each other.

Quick play tries to match similar skill levels, but if the delay is too long, it broadens the scope, allowing players to be joined with more varying skill levels for less delays than ranked.

## Challenges and Solutions

**Biggest challenge faced:**
[Describe the most difficult part of the assignment - was it the skill-based matching, queue management, or match processing?]
I had trouble trying to figure out how to design the quick play element. I wasn't sure how and when to switch from more strict matchmaking to the loose quicker joining.
**How you solved it:**
[Explain your solution approach and what helped you figure it out]
Using the internet for ideas on designing a quick play sorting style, I decided to limit the skill based matchmaking to when there were 4 players queued, and switch to first in first out when there were more.
**Most confusing concept:**
[What was hardest to understand about queues, matchmaking algorithms, or game mode differences?]
designing the match creaton method was the most confusing, because of having to keep track of all the different things that needed to be used to make a match.
## Code Quality

**What you're most proud of in your implementation:**
[Highlight the best aspect of your code - maybe your skill matching logic, queue status display, or error handling]

**What you would improve if you had more time:**
[Identify areas for potential improvement - perhaps better algorithms, more features, or cleaner code structure]
Better commenting of my code as I code it so it's easier when I'm looking through it
## Testing Approach

**How you tested your implementation:**
[Describe your overall testing strategy - how did you verify skill-based matching worked correctly?]

**Test scenarios you used:**
[List specific scenarios you tested, like players with different skill levels, empty queues, etc.]

**Issues you discovered during testing:**
[Any bugs or problems you found and fixed during development]

## Game Mode Understanding

**Casual Mode matching strategy:**
[Explain how you implemented FIFO matching for Casual mode]

**Ranked Mode matching strategy:**
[Explain how you implemented skill-based matching (±2 levels) for Ranked mode]

**QuickPlay Mode matching strategy:**
[Explain your approach to balancing speed vs. skill matching in QuickPlay mode]

## Real-World Applications

**How this relates to actual game matchmaking:**
[Describe how your implementation connects to real games like League of Legends, Overwatch, etc.]

**What you learned about game industry patterns:**
[What insights did you gain about how online games handle player matching?]

## Stretch Features

[If you implemented any extra credit features like team formation or advanced analytics, describe them here. If not, write "None implemented"]

## Time Spent

**Total time:** [X hours]

**Breakdown:**

- Understanding the assignment and queue concepts: [X hours]
- Implementing the 6 core methods: [X hours]
- Testing different game modes and scenarios: [X hours]
- Debugging and fixing issues: [X hours]
- Writing these notes: [X hours]

**Most time-consuming part:** [Which aspect took the longest and why - algorithm design, debugging, testing, etc.]

## Key Learning Outcomes

**Queue concepts learned:**
[What did you learn about managing multiple queues and different processing strategies?]

**Algorithm design insights:**
[What did you learn about designing matching algorithms and handling different requirements?]

**Software engineering practices:**
[What did you learn about error handling, user interfaces, and code organization?]
