using Feest.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feest.Presentation.EventsArg {
    public class UserEventArgs {

        public UserDTO User { get; set; }
        public DateTime Date { get; set; }

        public UserEventArgs(UserDTO user, DateTime date) {
            User = user;
            Date = date;
        }
    }
}
