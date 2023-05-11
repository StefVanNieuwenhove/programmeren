using Boek.Domain.interfaces;
using Boek.Domain.model;

namespace Boek.Persistence; 

public class BookRepository : IBookRepository {

    private List<Book> _books;

    public BookRepository() {
        _books = new List<Book>() {
            new Book("C# in Depth", "John Skeet", 29.29m, true),
            new Book("Effective Java", "Joshua Bloch", 43.86m, false),
            new Book("Murach's C# 2015", "Anne Boehm & Joel Murach", 55.49m, true),
            new Book("The C# Player's Guide", "R. B. Whitaker", 10.0m, true),
        };
    }                                                                 

    
    public void ProcessPaperbackBooks(IBookRepository.BookAction action) {
        _books.Where(b => b.IsPaperback).ToList().ForEach(x => action?.Invoke(x));
    }
}