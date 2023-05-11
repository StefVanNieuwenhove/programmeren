using Airport.Domain;
using Airport.Persistence;
using Airport.Presentation;

IDestinationRepository destinationRepository = new DestinationRepository();

DomeinController domainController = new(destinationRepository);

AirportApplication application = new(domainController);