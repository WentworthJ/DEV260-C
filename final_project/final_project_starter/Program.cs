using System;

namespace LibrarySystem
{
    class Program
    {
        static void Main()
        {
            var lib = new Library();
            bool running = true;

            while (running)
            {
                //Open Menu
                UI.ShowMenu();
                Console.Write("Choice: ");
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddBook(lib); break;
                    case "2":
                        SearchTitle(lib); break;
                    case "3":
                        ViewAll(lib); break;
                    case "4":
                        Update(lib); break;
                    case "5":
                        Delete(lib); break;
                    case "6":
                        Borrow(lib); break;
                    case "7":
                        Return(lib); break;
                    case "8":
                        lib.DisplayWaitlistStatus(); break;
                    case "9":
                        lib.ShowStats(); break;
                    case "10":
                        running = false; break;
                }

                Console.WriteLine("\nPress ENTER to continue...");
                Console.ReadLine();
            }
        }

        static void AddBook(Library lib)
        {
            Console.Write("ISBN: ");
            var isbn = Console.ReadLine();
            Console.Write("Title: ");
            var title = Console.ReadLine();
            Console.Write("Author: ");
            var author = Console.ReadLine();

            if (lib.AddBook(isbn!, title!, author!))
                Console.WriteLine("Book added!");
            else
                Console.WriteLine("Book already exists.");
        }

        static void SearchTitle(Library lib)
        {
            Console.Write("Search title: ");
            var t = Console.ReadLine();
            var results = lib.SearchByTitle(t!);
            foreach (var b in results) Console.WriteLine(b);
        }

        static void ViewAll(Library lib)
        {
            Console.WriteLine("\nAll Books:");
            foreach (var b in lib.SearchByTitle("")) Console.WriteLine(b);
        }

        static void Update(Library lib)
        {
            Console.Write("ISBN to update: ");
            var isbn = Console.ReadLine();

            Console.Write("New Title: ");
            var t = Console.ReadLine();
            Console.Write("New Author: ");
            var a = Console.ReadLine();

            if (lib.UpdateBook(isbn!, t!, a!)) Console.WriteLine("Updated!");
            else Console.WriteLine("Not found.");
        }

        static void Delete(Library lib)
        {
            Console.Write("ISBN to delete: ");
            if (lib.DeleteBook(Console.ReadLine()!))
                Console.WriteLine("Deleted.");
            else
                Console.WriteLine("Not found.");
        }

        static void Borrow(Library lib)
        {
            Console.Write("Your name: ");
            var n = Console.ReadLine();
            var borrower = lib.GetOrCreateBorrower(n!);

            Console.Write("ISBN: ");
            var isbn = Console.ReadLine();

            Console.WriteLine(lib.RequestBorrow(isbn!, borrower));
        }

        static void Return(Library lib)
        {
            Console.Write("ISBN return: ");
            Console.WriteLine(lib.ReturnBook(Console.ReadLine()!));
        }
    }
}
