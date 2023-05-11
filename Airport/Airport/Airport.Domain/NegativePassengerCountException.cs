using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Domain
{
    internal class NegativePassengerCountException : Exception
    {
        public NegativePassengerCountException() : base()
        { 
        }

        public NegativePassengerCountException(string message) : base(message)
        {

        }
    }
}
