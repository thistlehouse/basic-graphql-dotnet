using System.Linq.Expressions;
using BasicGraphQL.Infrastructure.Entities;

namespace BasicGraphQL.Application.Repositories;

public interface IBookRepository
{
    void Add(Book book);
    Book GetById(int id);
    List<Book> GetAll();
    List<Book> GetByFilter(Expression<Func<Book, bool>> expression);
}