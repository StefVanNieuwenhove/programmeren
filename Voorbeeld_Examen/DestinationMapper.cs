using System;
using System.Collections.Generic;

namespace Airport.Persistence
{
    public class DestinationMapper
    {
        public List<string> GetDestinations()
        {
            return new List<string>
            {
                "CAN",
                "ATL",
                "HND",
                "DEL",
                "DXB",
                "IST",
                "CDG",
                "LHR",
                "MEX",
                "SGN"
            };
        }

        public int GetDistance(string destination)
        {
            switch (destination)
            {
                case "CAN":
                    return 9264;
                case "ATL":
                    return 7087;
                case "HND":
                    return 9472;
                case "DEL":
                    return 6412;
                case "DXB":
                    return 5155;
                case "IST":
                    return 2179;
                case "CDG":
                    return 263;
                case "LHR":
                    return 349;
                case "MEX":
                    return 9252;
                case "SGN":
                    return 9912;
                default:
                    throw new ArgumentException("Unknown destination");
            }
        }
    }
}