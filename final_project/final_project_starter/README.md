# Project Title
Library Lending System
> One-sentence summary of what this app does and who it's for.
> A console-based management system for a library that allows users to add, update, borrow, and return books, with automatic waitlist handling.

---

## What I Built (Overview)

**Problem this solves:**  
_Explain the real-world task your app supports and why it's useful (2–4 sentences)._
This app aims to support the management of a small library, by making it easier to track where books are, and who is currently waiting for them.

**Your Answer:**
This app allows a small library to manage books and track who has borrowed from them. It helps prevent confusion if multiple users want the same book by automatically maintaining a waitlist. The system provides fast searching, simple book management, and clear feedback to users.


**Core features:**  
_List the main features your application provides (Add, Search, List, Update, Delete, etc.)_

**Your Answer:**
-Add new books

-Search books by title

-View full catalog

-Update book information

-Delete books

-Borrow books with automatically updated waitlist

-Return books

-Display waitlist status

-Show system statistics

## How to Run

**Requirements:**  
_List required .NET version, OS requirements, and any dependencies._

**Your Answer:**
.NET 6.0 or later

Windows, macOS, or Linux

No external dependencies

Console terminal required


```bash
git clone <your-repo-url>
cd <your-folder>
dotnet build
```

**Run:**  
_Provide the command to run your application._

**Your Answer:**

```bash
dotnet run
```

**Sample data (if applicable):**  
_Describe where sample data lives and how to load it (e.g., JSON file path, CSV import)._

**Your Answer:**
N/A
---

## Using the App (Quick Start)

**Typical workflow:**  
_Describe the typical user workflow in 2–4 steps._

**Your Answer:**

1. Add a book with choice 1
2. Search books by title
3. Borrow a book (or be added to a waitlist if it is already borrowed)
4. Return a book

**Input tips:**  
_Explain case sensitivity, required fields, and how common errors are handled gracefully._

**Your Answer:**
ISBN matching is case-insensitive due to StringComparer.OrdinalIgnoreCase
user names and titles are accepted as free-text.
If you attempt to borrow a book that doesn’t exist, you receive a helpful error message.
Duplicate waitlist entries for the same borrower are prevented.
---

## Data Structures (Brief Summary)

> Full rationale goes in **DESIGN.md**. Here, list only what you used and the feature it powers.

**Data structures used:**  
_List each data structure and briefly explain what feature it powers._

**Your Answer:**

- `Dictionary<string, Book>` → Fast lookup by ISBN for add, update, delete, and borrow logic.
- `List<Book>` → Stores the full catalog and supports title searching and display.
- `Queue<BorrowRequest>` → Manages the waitlist for each book in FIFO order.
- `List<Borrower>` → Stores all borrowers and avoids duplicate borrower entries.

---

## Manual Testing Summary

> No unit tests required. Show how you verified correctness with 3–5 test scenarios.

**Test scenarios:**  
_Describe each test scenario with steps and expected results._

**Your Answer:**

**Scenario 1: [Add Book]**

- Steps: Add a new book with ISBN 123, title "Test", author "ME"
- Expected result: New book with the previously mentioned attributes is added.
- Actual result: Success

**Scenario 2: [Borrow Book]**

- Steps: Borrow an added book
- Expected result: Immediate confirmation message
- Actual result: success

**Scenario 3: [Borrow Already-Checked-Out Book]**

- Steps: Attempt to borrow an already borrowed book while using a different user name
- Expected result: Second user added to waitlist
- Actual result: Success

**Scenario 4: [Search for Title]**

- Steps: 
- Expected result:
- Actual result:

---

## Known Limitations

**Limitations and edge cases:**  
_Describe any edge cases not handled, performance caveats, or known issues._

**Your Answer:**
No persistent storage—data is lost when the program closes.

No duplicate ISBN validation beyond exact matches.

Wait time is measured only in seconds and resets when program restarts.
-
-

## Comparers & String Handling

**Keys comparer:**  
_Describe what string comparer you used (e.g., StringComparer.OrdinalIgnoreCase) and why._

**Your Answer:**

**Normalization:**  
_Explain how you normalize strings (trim whitespace, consistent casing, duplicate checks)._

**Your Answer:**

I used StringComparer.OrdinalIgnoreCase for ISBN keys in the dictionary. I used it because it ensures that ISBN lookups work regardless of letter case differences, improving reliability in a console environment.
---

## Credits & AI Disclosure

**Resources:**  
_List any articles, documentation, or code snippets you referenced or adapted._
I used modified versions of previous assignments from this class, as well as reviewing various Stack Overflow posts

**Your Answer:**

-
- **AI usage (if any):**  
   _Describe what you asked AI tools, what code they influenced, and how you verified correctness._

  **Your Answer:**
  I used ChatGPT to help double-check the correctness of my code structure, validate logic flow, and ensure proper use of data structures, or to see if there was a flaw I had missed.

  I verified it by manually reviewing all the code that it wanted to modify to verify correct behavior.

  ***

## Challenges and Solutions

**Biggest challenge faced:**  
_Describe the most difficult part of the project - was it choosing the right data structures, implementing search functionality, handling edge cases, designing the user interface, or understanding a specific algorithm?_

**Your Answer:**
Designing the borrow/return workflow so that the waitlist automatically assigns the book when returned was the biggest challenge.

**How you solved it:**  
_Explain your solution approach and what helped you figure it out - research, consulting documentation, debugging with breakpoints, testing with simple examples, refactoring your design, etc._

**Your Answer:**
I separated responsibilities into the Library class and used a Queue to model FIFO waitlist behavior. Testing small scenarios and debugging step-by-step helped confirm my logic

**Most confusing concept:**  
_What was hardest to understand about data structures, algorithm complexity, key comparers, normalization, or organizing your code architecture?_

**Your Answer:**
Choosing the correct data structure for lookups and ordering was initially confusing, because of trying to conceptualize the whole project to make sure it would work before commiting.

## Code Quality

**What you're most proud of in your implementation:**  
_Highlight the best aspect of your code - maybe your data structure choices, clean architecture, efficient algorithms, intuitive user interface, thorough error handling, or elegant solution to a complex problem._

**Your Answer:**
I'm proud of how things are separated, so it's easier to navigate the file quickly for editing.

**What you would improve if you had more time:**  
_Identify areas for potential improvement - perhaps adding more features, optimizing performance, improving error handling, adding data persistence, refactoring for better maintainability, or enhancing the user experience._

**Your Answer:**
Persistent storage would be nice to add, or a pre determined library to start, that could still have books added and removed.

## Real-World Applications

**How this relates to real-world systems:**  
_Describe how your implementation connects to actual software systems - e.g., inventory management, customer databases, e-commerce platforms, social networks, task managers, or other applications in the industry._

**Your Answer:**
It's similar to real life systems that libraries use, that have to keep track of where books are all the time, so they can ensure acceptable service, with waitlists and various records being concepts that are commonly used.

**What you learned about data structures and algorithms:**  
_What insights did you gain about choosing appropriate data structures, performance tradeoffs, Big-O complexity in practice, the importance of good key design, or how data structures enable specific features?_

**Your Answer:**
I learned the importance of making sure you know what data structures to use early on, and that it's sometimes easier to keep some elements separate to avoid complications while editing code.

## Submission Checklist

- [ ] Public GitHub repository link submitted
- [X] README.md completed (this file)
- [ ] DESIGN.md completed
- [X] Source code included and builds successfully
- [ ] (Optional) Slide deck or 5–10 minute demo video link (unlisted)

**Demo Video Link (optional):**
