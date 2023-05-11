using Boek.Domain.model;

namespace Boek.Domain.interfaces; 

public interface IBookRepository {

    delegate void BookAction(Book obj);
    void ProcessPaperbackBooks(BookAction action);
}