using Lesson5_Encapsulation.Models;

namespace Lesson5_Encapsulation.Services;

public class BookCollection
{
    private List<Book> books;
    public BookCollection()
    {
        books = new List<Book>();
    }
    public void AddBook(Book book)
    {
        books.Add(book);
    }
    public List<Book> GetBooksByAuthor(string author)
    {
        var booksByAuthor = new List<Book>();
        foreach (var book in books)
        {
            if (book.Author == author)
            {
                booksByAuthor.Add(book);
            }
        }
        return booksByAuthor;
    }
}
