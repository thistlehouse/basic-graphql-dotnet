using System.Linq.Expressions;
using BasicGraphQL.Application.Repositories;
using BasicGraphQL.Infrastructure.Entities;

namespace BasicGraphQL.Infrastructure.Repositories;

public class BookRepository : IBookRepository
{
    private static readonly List<Book> _books =
    [
        new(1, "C#", DateTime.UtcNow),
        new(2, "C# Design Patterns", DateTime.UtcNow),
        new(3, "How to Think Like a Programmer", DateTime.UtcNow),
    ];

    public void Add(Book book)
    {
        _books.Add(book);
    }

    public List<Book> GetAll()
    {
        return _books;
    }

    public List<Book> GetByFilter(Expression<Func<Book, bool>> expression)
    {
        return _books.Where(expression.Compile()).ToList();
    }

    public Book GetById(int id)
    {
        return _books.SingleOrDefault(book => book.Id == id)!;
    }
}
