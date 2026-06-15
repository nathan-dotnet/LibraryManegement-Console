using LibraryManagement.Models;   
using LibraryManagement.Services;

var libraryService = new LibraryService();

while (true)
{
    Console.WriteLine("|===== Library Management System =====|");
    Console.WriteLine("1. Add Book");
    Console.WriteLine("2. View Books");
    Console.WriteLine("3. Exit");
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
                    Console.WriteLine("-------------------------");
                }
            }
            break;
        
        case "3":
            Console.WriteLine("Exiting...");
            return;
    }
}