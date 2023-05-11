namespace Airport.Domain
{
    public interface IDestinationRepository
    {
        string GetDestinationByIndex(int index);
        List<string> GetAllDestinations();
        int GetDistanceByDestination(string destination);
    }
}
