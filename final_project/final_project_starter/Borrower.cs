namespace LibrarySystem
{
    public class Borrower
    {
        public string Name { get; }
        public Borrower(string name) => Name = name;

        public override string ToString() => Name;
    }
}
