using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feest.Domain.Exceptions {
    public class DayPlanException : Exception {

        public DayPlanException() { }

        public DayPlanException(string message) : base(message) { }

        public DayPlanException(string message, Exception innerException) : base(message, innerException) { }
    }
}
