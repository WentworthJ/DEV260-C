# Project Design & Rationale

**Instructions:** Replace prompts with your content. Be specific and concise. If something doesn't apply, write "N/A" and explain briefly.

---

## Data Model & Entities

**Core entities:**  
_List your main entities with key fields, identifiers, and relationships (1–2 lines each)._

**Your Answer:**

**Entity A:**

- Name: Book
- Key fields: ISBN, Title, Author, IsCheckedOut, Waitlist
- Identifiers: ISBN (string, case-insensitive)
- Relationships: Has a Queue<BorrowRequest> as its waitlist. Does not directly store borrower data, but interacts with borrowers through their requests

**Entity B (if applicable):**

- Name: Borrower
- Key fields: Name
- Identifiers: Name (case-insensitive match for uniqueness)
- Relationships: Borrowers do not directly own books; instead, they appear inside BorrowRequest objects

**Identifiers (keys) and why they're chosen:**  
_Explain your choice of keys (e.g., string Id, composite key, case-insensitive, etc.)._

**Your Answer:**

I used ISBN as the unique key for books because they are globally unique, stable, and suited for dictionary lookups. A case-insensitive string comparer is used to avoid complications with capitalization. Borrowers are uniquely identified by name, which works for a small-scale system and simplifies input, though a larger system would need to use number IDs eventually.

## Data Structures — Choices & Justification

_List only the meaningful data structures you chose. For each, state the purpose, the role it plays in your app, why it fits, and alternatives considered._

### Structure #1

**Chosen Data Structure:**  
_Name the data structure (e.g., Dictionary<string, Customer>)._

**Your Answer:**
Dictionary<string, Book>
**Purpose / Role in App:**  
_What user action or feature does it power?_

**Your Answer:**
Provides fast lookup of books by ISBN for Add, Update, Delete, Borrow, and Return operations.
**Why it fits:**  
_Explain access patterns, typical size, performance/Big-O, memory, simplicity._

**Your Answer:**
It has O(1) average lookup, insertion, and removal and prevents duplicate ISBN entries.
Simplifies validation and user input flow, and avoids scanning a list every time.

**Alternatives considered:**  
_List alternatives (e.g., List<T>, SortedDictionary, custom tree) and why you didn't choose them._

**Your Answer:**

A List<Book>, but it is too slow.
I considered a SortedDictionary, but it was excessive because I decided to use direct key lookups.

### Structure #2

**Chosen Data Structure:**  
_Name the data structure._

**Your Answer:**
List<Book>

**Purpose / Role in App:**  
_What user action or feature does it power?_

**Your Answer:**
Stores the complete catalog for searching by title and displaying all books.

**Why it fits:**  
_Explain access patterns, typical size, performance/Big-O, memory, simplicity._

**Your Answer:**
Maintains insertion order which useful for display.
Easy LINQ integration for partial title searches
Small expected dataset makes O(n) searches acceptable
Simple to iterate and print

**Alternatives considered:**  
_List alternatives and why you didn't choose them._

**Your Answer:**

SortedList, but it doesn't need to be ordered.
A Database could be an alternative, but would be excessive for this kind of project.

### Structure #3

**Chosen Data Structure:**  
_Name the data structure._

**Your Answer:**
Queue<BorrowRequest>

**Purpose / Role in App:**  
_What user action or feature does it power?_

**Your Answer:**
Manages each book’s waiting list, ensuring fair FIFO order for borrowers when a checked-out book is returned.

**Why it fits:**  
_Explain access patterns, typical size, performance/Big-O, memory, simplicity._

**Your Answer:**
FIFO is perfect for a waitlist, has O(1) enqueue/dequeue operations, is simple but appropriate for keeping arrival order.

**Alternatives considered:**  
_List alternatives and why you didn't choose them._

**Your Answer:**

A PriorityQueue could be used, but there aren't generally situtions where someone will have a higher priority to get a book.

### Additional Structures (if applicable)

_Add more sections if you used additional structures like Queue for workflows, Stack for undo, HashSet for uniqueness, Graph for relationships, BST/SortedDictionary for ordered views, etc._

**Your Answer:**



## Comparers & String Handling

**Comparer choices:**  
_Explain what comparers you used and why (e.g., StringComparer.OrdinalIgnoreCase for keys)._

**Your Answer:**
The ISBN dictionary uses StringComparer.OrdinalIgnoreCase to ensure case-insensitive lookup. This makes the system more user-friendly because users can enter ISBNs in any casing.

**For keys:**
StringComparer.OrdinalIgnoreCase for dictionary ISBN keys.

**For display sorting (if different):**
N/A

**Normalization rules:**  
_Describe how you normalize strings (trim whitespace, collapse duplicates, canonicalize casing)._

**Your Answer:**
Borrower names are matched case-insensitively, so things like "John" and "john" are considered the same.

**Bad key examples avoided:**  
_List examples of bad key choices and why you avoided them (e.g., non-unique names, culture-varying text, trailing spaces, substrings that can change)._

I avoided using things like Titles or Authors, as different books can have the same name or the same author.

## Performance Considerations

**Expected data scale:**  
_Describe the expected size of your data (e.g., 100 items, 10,000 items)._

**Your Answer:**
I expect this would be used for a small library with 100-300 books and 50 or so borrowers

**Performance bottlenecks identified:**  
_List any potential performance issues and how you addressed them._
The search is O(n), but it shouldn't be a problem with the size.
Search results aren't cached, but it's not needed.
Waitlist is efficient with O(1) because of queues.

**Your Answer:**

**Big-O analysis of core operations:**  
_Provide time complexity for your main operations (Add, Search, List, Update, Delete)._

**Your Answer:**

- Add:O(1)
- Search:O(n)
- List:O(n) 
- Update:O(1)
- Delete:O(1)

---

## Design Tradeoffs & Decisions

**Key design decisions:**  
_Explain major design choices and why you made them._

**Your Answer:**
Using a dictionary and list to get fast ISBN lookup, while keeping display and search simple
Using a queue for the waitlist to match real-world FIFO behavior.

**Tradeoffs made:**  
_Describe any tradeoffs between simplicity vs performance, memory vs speed, etc._

**Your Answer:**
No persistent storage means restarting the program resets data, but reduces the complexity of the project.
Borrowers are identified by their name, which could cause issues, but is acceptable on a small scale application.

**What you would do differently with more time:**  
_Reflect on what you might change or improve._

**Your Answer:**
It would be nice to have a persistent memory of what books were in the library, and who was borrowing.
Maybe have an additional menu option, that was for someone in the waitlist to pick up their book,
because the current format assumes the books will immediatly be supplied to those in the waitlist.

