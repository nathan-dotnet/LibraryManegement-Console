using LibraryManagement.Models;   
using LibraryManagement.Services;

var libraryService = new LibraryService();

User? currentUser = null;

Console.WriteLine("===== Log In =====");
Console.WriteLine("1. Student");
Console.WriteLine("2. Librarian");
Console.Write("Select role: ");

string? roleOption = Console.ReadLine();

switch (roleOption)
{
    case "1":
        currentUser = new Student { Name = "Nathaniel" };
        break;
    case "2":
        currentUser = new Librarian { Name = "Admin" };
        break;
    default:
        Console.WriteLine("Invalid option.");
        return;
}

while (true)
{
    Console.WriteLine($"Welcome {currentUser.Name}");
    currentUser.DisplayRole();
    Console.WriteLine("|===== Library Management System =====|");
    Console.WriteLine("1. Add Book");
    Console.WriteLine("2. View Books");
    Console.WriteLine("3. Search Book");
    Console.WriteLine("4. Remove Book");
    Console.WriteLine("5. Borrow Book");
    Console.WriteLine("6. Return Book");
    Console.WriteLine("7. Exit");
    Console.Write("Select an option: ");

    string? option = Console.ReadLine();

    switch (option)
    {
        case "1":
            Console.Write("Enter Title: ");
            string? title = Console.ReadLine();

            Console.Write("Enter Author: ");
            string? author = Console.ReadLine();

            var book = new Book
            {
                Title = title ?? "",
                Author = author ?? ""
            };

            libraryService.AddBook(book);

            Console.WriteLine("Book added successfully!");
            break;
        
        case "2":
            var books = libraryService.GetBooks();
            
            if (books.Count == 0)
            {
                Console.WriteLine("No books available.");
            }
            else
            {
                foreach (var b in books)
                {
                    Console.WriteLine("-------------------------");
                    Console.WriteLine($"Title: {b.Title}");
                    Console.WriteLine($"Author: {b.Author}");
                    Console.WriteLine($"Available: {(b.IsAvailable ? "Yes" : "No")}");
                    Console.WriteLine("-------------------------");
                }
            }
            break;
        
        case "3":
            Console.Write("Enter title to search: ");
            string? searchTitle = Console.ReadLine();
            libraryService.SearchBook(searchTitle ?? "");
            break;

        case "4":
            Console.Write("Enter title to remove: ");
            string? removeTitle = Console.ReadLine();
            libraryService.RemoveBook(removeTitle ?? "");
            break;

        case "5":
            Console.Write("Enter title to borrow: ");
            string? borrowTitle = Console.ReadLine();
            libraryService.BorrowBook(borrowTitle ?? "");
            break;
        
        case "6":
            Console.Write("Enter title to return: ");
            string? returnTitle = Console.ReadLine();
            libraryService.ReturnBook(returnTitle ?? "");
            break;

        case "7":
            Console.WriteLine("Exiting...");
            return;
    }
}