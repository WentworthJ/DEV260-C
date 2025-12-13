using System;
using System.Collections.Generic;
using System.Linq;

namespace LibrarySystem
{
    public class Library
    {
        //Data Structures
        private List<Book> catalog = new List<Book>();
        private Dictionary<string, Book> map = new Dictionary<string, Book>(StringComparer.OrdinalIgnoreCase);
        private List<Borrower> borrowers = new List<Borrower>();

        public bool AddBook(string isbn, string title, string author)
        {
            if (map.ContainsKey(isbn))
                return false;

            var b = new Book(isbn, title, author);
            catalog.Add(b);
            map[isbn] = b;
            return true;
        }

        public Book? FindByISBN(string isbn)
        {
            map.TryGetValue(isbn, out var book);
            return book;
        }

        public List<Book> SearchByTitle(string title)
        {
            return catalog
                .Where(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public bool UpdateBook(string isbn, string newTitle, string newAuthor)
        {
            if (!map.TryGetValue(isbn, out var b)) return false;

            b.Title = newTitle;
            b.Author = newAuthor;
            return true;
        }

        public bool DeleteBook(string isbn)
        {
            if (!map.TryGetValue(isbn, out var b)) return false;

            catalog.Remove(b);
            map.Remove(isbn);
            return true;
        }

        //Borrow books

        public string RequestBorrow(string isbn, Borrower borrower)
        {
            if (!map.TryGetValue(isbn, out var book))
                return "Book not found.";

            // checkout if the book is avalible
            if (!book.IsCheckedOut)
            {
                book.IsCheckedOut = true;
                return $"{borrower.Name} successfully checked out {book.Title}.";
            }

            // If book not avalible add to a wait list
            if (book.Waitlist.Any(r => r.Borrower == borrower))
                return "You are already on the waitlist.";

            book.Waitlist.Enqueue(new BorrowRequest(borrower));
            return $"{borrower.Name} added to waitlist for {book.Title}.";
        }

        public string ReturnBook(string isbn)
        {
            if (!map.TryGetValue(isbn, out var book))
                return "Book not found.";

            if (!book.IsCheckedOut)
                return "Book is already available.";

            if (book.Waitlist.Count > 0)
            {
                var next = book.Waitlist.Dequeue();
                return $"Book given to next in line: {next.Borrower.Name} (waited {next.WaitSeconds:F1}s)";
            }

            book.IsCheckedOut = false;
            return $"{book.Title} returned and is now available.";
        }

        // Show waitlist

        public void DisplayWaitlistStatus()
        {
            Console.WriteLine("\n────── Waitlist Status ──────");

            foreach (var book in catalog)
            {
                Console.WriteLine($"\n{book.Title} ({book.ISBN})");

                if (book.Waitlist.Count == 0)
                {
                    Console.WriteLine("   [No waitlist]");
                    continue;
                }

                int pos = 1;
                foreach (var req in book.Waitlist)
                {
                    Console.WriteLine($"   {pos}. {req.Borrower.Name} | Wait {req.WaitSeconds:F1}s");
                    pos++;
                }
            }
            Console.WriteLine();
        }

        public string GetWaitEstimate(string isbn)
        {
            if (!map.TryGetValue(isbn, out var book))
                return "Not found";

            if (book.Waitlist.Count >= 2)
                return "No wait (high turnover)";
            if (book.Waitlist.Count == 1)
                return "Short wait";
            return "Long wait (empty waitlist)";
        }

        public void ShowStats()
        {
            Console.WriteLine($"\nBooks: {catalog.Count}");
            Console.WriteLine($"Borrowers: {borrowers.Count}");
        }

        public Borrower GetOrCreateBorrower(string name)
        {
            var existing = borrowers.FirstOrDefault(b => b.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (existing != null) return existing;
            var b = new Borrower(name);
            borrowers.Add(b);
            return b;
        }
    }
}
