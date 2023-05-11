using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Domain
{
    internal abstract class Aircraft : IFuelableAircraft
    {
        private string destination;
        protected Aircraft(string destination, int distance)
        {
            Destination = destination;
            Distance = distance;
        }

        public string Destination {
            get { return destination; } 
            init 
            {
                CheckDestination(value);
                destination = value;
            } 
        }
        public int Distance { get; set; }

        public abstract double Weight { get; }

        public double GetKerosineToFuel()
        {
            return Distance * Weight;
        }

        public override bool Equals(object? obj)
        {
            return obj is Aircraft ac && ac.Destination == Destination;
        }

        public override int GetHashCode()
        {
            return Destination.GetHashCode();
        }

        public override string ToString()
        {
            return GetType().Name + " with destination " + Destination + " requires " + GetKerosineToFuel() + " L of fuel ";
        }

        private void CheckDestination(string destination)
        {
            if (string.IsNullOrEmpty(destination))
            {
                throw new ArgumentException("Er is een foutieve destinatie ingegeven");
            }
        }
    }
}
