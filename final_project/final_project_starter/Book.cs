namespace LibrarySystem
{
    public class Book
    {
        public string ISBN { get; }
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsCheckedOut { get; set; }

        // Create when someone wants a book
        public Queue<BorrowRequest> Waitlist { get; } = new Queue<BorrowRequest>();

        public Book(string isbn, string title, string author)
        {
            ISBN = isbn;
            Title = title;
            Author = author;
        }

        public override string ToString()
        {
            return $"{Title} ({ISBN}) by {Author} — " +
                   (IsCheckedOut ? "Checked Out" : "Available");
        }
    }
}
