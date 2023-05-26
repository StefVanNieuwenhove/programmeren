using Feest.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feest.Presentation.EventsArg {
    public class EventDayPlanArgs : EventArgs {
        
        public string Title { get; set; }
        public DateTime Date { get; set; }

        public EventDayPlanArgs(string title, DateTime date) {
            Title = title;
            Date = date;
        }
    }
}
