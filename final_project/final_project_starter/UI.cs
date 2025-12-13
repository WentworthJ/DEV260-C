using System;

namespace LibrarySystem
{
    public static class UI
    {
        public static void ShowMenu()
        {
            Console.WriteLine("┌─ Library Lending System ─────────────────────────────┐");
            Console.WriteLine("│ 1. Add Book        │ 2. Search Title     │ 3. View All│");
            Console.WriteLine("│ 4. Update Book     │ 5. Delete Book      │            │");
            Console.WriteLine("│ 6. Borrow Book     │ 7. Return Book      │            │");
            Console.WriteLine("│ 8. Waitlist Status │ 9. Stats            │ 10. Quit   │");
            Console.WriteLine("└──────────────────────────────────────────────────────┘");
        }
    }
}
