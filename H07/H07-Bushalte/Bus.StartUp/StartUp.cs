using BusStops.Domain;
using BusStops.Domain.Repository;
using BusStops.Persistence;
using BusStops.Presentation;

IBusStopsRepository repository = new BusStopsMapper();
DomainController domainController = new DomainController(repository);
BusStopsApplication application = new BusStopsApplication(domainController);