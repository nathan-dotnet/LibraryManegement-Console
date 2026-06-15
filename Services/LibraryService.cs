using LibraryManagement.Models;

namespace LibraryManagement.Services;

public class LibraryService
{
    private readonly List<Book> _books = [];
    public void AddBook(Book book)
    {
        _books.Add(book);
    }

    public List<Book> GetBooks()
    {
        return _books;
    }
}