# Assignment 8: Spell Checker & Vocabulary Explorer - Implementation Notes

**Name:** Jason Wentworth

## HashSet Pattern Understanding

**How HashSet<T> operations work for spell checking:**
[Explain your understanding of how O(1) lookups, automatic uniqueness, and set-based categorization work together for efficient text analysis]
the O(1) lookups are provided by HashSet, making checking words very fast, and the automatic uniqueness ensures there is only one of each word per set, allowing efficient categorization of words without repeats
## Challenges and Solutions

**Biggest challenge faced:**
[Describe the most difficult part of the assignment - was it text normalization, HashSet operations, or file I/O handling?]
getting the dictionary to load

**How you solved it:**
[Explain your solution approach and what helped you figure it out]
It worked when using dotnet build and dotnet run in the Terminal, but I couldn't figure out how to get it to work otherwise

**Most confusing concept:**
[What was hardest to understand about HashSet operations, text processing, or case-insensitive comparisons?]
The hardest part was to consistently normalize for case-insensitive comparisons while using HashSet to efficiently track unique words without accidentally losing duplicates or misclassifying misspelled words.

## Code Quality

**What you're most proud of in your implementation:**
[Highlight the best aspect of your code - maybe your normalization strategy, error handling, or efficient text analysis]
that the normalization works with case sensitivity

**What you would improve if you had more time:**
[Identify areas for potential improvement - perhaps better tokenization, more robust error handling, or additional features]
It would be neat to adjust for contractions, hyphens, and special characters or misspelled words

## Testing Approach

**How you tested your implementation:**
[Describe your overall testing strategy - how did you verify spell checking worked correctly?]
comparing with dictonary words
**Test scenarios you used:**
[List specific scenarios you tested, like mixed case words, punctuation handling, edge cases, etc.]
Words with mixed cases (aPple and apple), and things with punctuation (hello,)
**Issues you discovered during testing:**
[Any bugs or problems you found and fixed during development]
Couldn't get dictionary to load when running normally
## HashSet vs List Understanding

**When to use HashSet:**
[Explain when you would choose HashSet over List based on your experience]
I would choose a HashSet over a List whenever I need fast membership checks, automatic uniqueness, or set-based operations
**When to use List:**
[Explain when List is more appropriate than HashSet]
A List is more appropriate than a HashSet when order matters, duplicates need to be kept, or index-based access is required, because Lists maintain the insertion order and allow multiple of the same items
**Performance benefits observed:**
[Describe how O(1) lookups and automatic uniqueness helped your implementation]
It allowed the spell checker to quickly check if each word was in the dictionary or already seen, and ensured no unessecary duplicates were stored
## Real-World Applications

**How this relates to actual spell checkers:**
[Describe how your implementation connects to tools like Microsoft Word, Google Docs, etc.]
it checks words against a dictionary and identifies misspellings like how real world tools underline highlight errors or suggest corrections
**What you learned about text processing:**
[What insights did you gain about handling real-world text data and normalization?]
How much needs to be edited or trimmed to identify a word like removing punctuation
## Stretch Features

[If you implemented any extra credit features like vocabulary suggestions or advanced analytics, describe them here. If not, write "None implemented"]

## Time Spent

**Total time:** [~4 hours]

**Breakdown:**
- Understanding HashSet concepts and assignment requirements: [X hours]
- Implementing the 6 core methods: [X hours]
- Testing different text files and scenarios: [X hours]
- Debugging and fixing issues: [X hours]
- Writing these notes: [X hours]

**Most time-consuming part:** [Which aspect took the longest and why - text normalization, HashSet operations, file I/O, etc.]
Trying to fix the dictionary loading
## Key Learning Outcomes

**HashSet concepts learned:**
[What did you learn about O(1) performance, automatic uniqueness, and set-based operations?]
how quickly they can perform operations
**Text processing insights:**
[What did you learn about normalization, tokenization, and handling real-world text data?]
A very high amount is required for processing real world text
**Software engineering practices:**
[What did you learn about error handling, user interfaces, and defensive programming?]
It's important to avoid crashes and incorrect processing of data