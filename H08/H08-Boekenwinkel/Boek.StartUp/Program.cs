using Boek.Domain;
using Boek.Domain.interfaces;
using Boek.Domain.model;
using Boek.Persistence;

IBookRepository repository = new BookRepository();
DomainManager manager = new (repository);