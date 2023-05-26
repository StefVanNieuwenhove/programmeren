using Feest.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feest.Presentation.EventsArg {
    public class DayPlanArgs : EventArgs {

        public int DayPlanId { get; set; }
        public EventDTO Event { get; set; }
        public UserDTO User { get; set; }
        public DateTime DayPlanDate { get; set; }

        public DayPlanArgs(int dayPlanId, EventDTO dto, UserDTO user, DateTime dayPlanDate) {
            DayPlanId = dayPlanId;
            Event = dto;
            User = user;
            DayPlanDate = dayPlanDate;
        }
    }
}
