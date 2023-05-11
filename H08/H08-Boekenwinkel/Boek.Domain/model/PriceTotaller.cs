namespace Boek.Domain.model; 

public class PriceTotaller {

    private List<Book> _books = new();

    public void AddBookToTotal(Book book) {
         _books.Add(book);
    }

    public decimal GetAveragePrice() {
        return _books.Average(b => b.Price);
    }
}