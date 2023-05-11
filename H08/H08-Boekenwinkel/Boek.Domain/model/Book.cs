namespace Boek.Domain.model; 

public class Book {
       public string Name { get; set; }
       public string Author { get; set; }
       public decimal Price { get; set; }
       public Boolean IsPaperback { get; set; }

       public Book(string name, string author, decimal price, bool isPaperback) {
              Name = name;
              Author = author;
              Price = price;
              IsPaperback = isPaperback;
       }
}