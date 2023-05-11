using Boek.Domain.interfaces;
using Boek.Domain.model;

namespace Boek.Domain; 

public class DomainManager {

    private IBookRepository _repository;
    private PriceTotaller _totaller;

    public DomainManager(IBookRepository repository) {
        _repository = repository;
        _totaller = new();
        _repository.ProcessPaperbackBooks(_totaller.AddBookToTotal);
        Console.WriteLine(_totaller.GetAveragePrice());
        _repository.ProcessPaperbackBooks(PrintTitle);
    }

    public void PrintTitle(Book book) {
        Console.WriteLine(book.Name);
    }
}