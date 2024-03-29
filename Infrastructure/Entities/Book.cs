namespace BasicGraphQL.Infrastructure.Entities;

public class Book
{
    public Book() { }

    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateTime Year { get; set; }

    public Book(int id, string title, DateTime year)
    {
        Id = id;
        Title = title;
        Year = year;
    }
}