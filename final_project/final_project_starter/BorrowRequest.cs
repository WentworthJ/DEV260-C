namespace LibrarySystem
{
    public class BorrowRequest
    {
        public Borrower Borrower { get; }
        public DateTime TimeJoined { get; private set; }

        public BorrowRequest(Borrower borrower)
        {
            Borrower = borrower;
            TimeJoined = DateTime.Now;
        }

        public double WaitSeconds =>
            (DateTime.Now - TimeJoined).TotalSeconds;
    }
}
