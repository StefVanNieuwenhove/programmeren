using Airport.Domain;

namespace Airport.Persistence
{
    public class DestinationRepository : IDestinationRepository
    {
        private readonly DestinationMapper _destinationMapper;

        public DestinationRepository()
        {
            _destinationMapper = new DestinationMapper();
        }

        public List<string> GetAllDestinations()
        {
            return _destinationMapper.GetDestinations();
        }

        public string GetDestinationByIndex(int index)
        {
            if (GetAllDestinations().Count < index)
            {
                throw new IndexOutOfRangeException($"There is no destination at index {index}");
            }
            else
            {
                return GetAllDestinations()[index];
            }
        }

        public int GetDistanceByDestination(string destination)
        {
            return _destinationMapper.GetDistance(destination);
        }
    }
}
