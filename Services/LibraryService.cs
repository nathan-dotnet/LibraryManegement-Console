using LibraryManagement.Models;

namespace LibraryManagement.Services;

public class LibraryService
{
    private readonly List<Book> _books = [];
    public void AddBook(Book book)
    {
        _books.Add(book);
    }

    public void SearchBook(string searchTitle)
    {
        var foundBooks = _books.Where(b => b.Title.Contains(searchTitle, StringComparison.OrdinalIgnoreCase)).ToList();
        if (foundBooks.Count == 0)
        {
            Console.WriteLine("No books found with that title.");
        }
        else
        {
            Console.WriteLine("Books found:");
            foreach (var book in foundBooks)
            {
                Console.WriteLine($"- {book.Title} by {book.Author} (Available: {book.IsAvailable})");
            }
        }
    }

    public void RemoveBook(string title)
    {
        var bookToRemove = _books.FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        if (bookToRemove != null)
        {
            _books.Remove(bookToRemove);
            Console.WriteLine("Book removed successfully.");
        }
        else
        {
            Console.WriteLine("Book not found.");
        }
    }
    
    public void BorrowBook(string title)
    {
        var bookToBorrow = _books.FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase) && b.IsAvailable);
        if (bookToBorrow != null)
        {
            bookToBorrow.IsAvailable = false;
            Console.WriteLine("Book borrowed successfully.");
        }
        else
        {
            Console.WriteLine("Book not available for borrowing.");
        }
    }

    public void ReturnBook(string title)
    {
        var bookToReturn = _books.FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase) && !b.IsAvailable);
        if (bookToReturn != null)
        {
            bookToReturn.IsAvailable = true;
            Console.WriteLine("Book returned successfully.");
        }
        else
        {
            Console.WriteLine("Book not found or not currently borrowed.");
        }
    }
    public List<Book> GetBooks()
    {
        return _books;
    }
}