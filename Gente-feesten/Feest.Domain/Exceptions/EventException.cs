﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feest.Domain.Exceptions {
    public class EventException : Exception {

        public EventException() { }

        public EventException(string message) : base (message) { }

        public EventException(string message,  Exception innerException) : base(message, innerException) { }
    }
}
