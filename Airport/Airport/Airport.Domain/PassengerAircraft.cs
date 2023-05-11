using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Domain
{
    internal class PassengerAircraft : Aircraft
    {
        private int _passengers;
        private const int StandardWeightPassenger = 70;
        public PassengerAircraft(string destination, int distance, int passengers) : base(destination, distance)
        {
            CheckPassengerCount(passengers);
            _passengers = passengers;
        }

        public override double Weight { get => StandardWeightPassenger*_passengers; }

        public override string ToString()
        {
            return base.ToString() + "containing " + _passengers + " passengers";
        }

        private void CheckPassengerCount(int passengers)
        {
            if (passengers < 0)
            {
                throw new NegativePassengerCountException("Het aantal passagiers is lager dan nul");
            }
        }
    }
}
