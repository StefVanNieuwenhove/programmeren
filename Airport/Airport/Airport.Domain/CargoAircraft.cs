using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Domain
{
    internal class CargoAircraft : Aircraft
    {
        private double _weight;

        public CargoAircraft(string destination, int distance, double cargoWeight) : base(destination, distance)
        {
            _weight = cargoWeight;
        }

        public override double Weight { get { return _weight; } }

        public override string ToString()
        {
            return base.ToString() + "with a cargo of " + Weight + " kilograms";
        }
    }
}
