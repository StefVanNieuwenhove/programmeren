using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Domain
{
    public class Helicopter : IFuelableAircraft
    {
        private readonly double _fuel;
        public Helicopter(double fuel)
        {
            CheckRequestedFuel(fuel);
            _fuel = fuel;
        }

        public double GetKerosineToFuel()
        {
            return _fuel;
        }

        public override string ToString()
        {
            return "Helicopter that needs " + GetKerosineToFuel() + " L of fuel";
        }

        private void CheckRequestedFuel(double fuel)
        {
            if (!(fuel > 100 && fuel%10 == 0))
            {
                throw new ArgumentException("Fuel amount is invalid");
            }
        }
    }
}
