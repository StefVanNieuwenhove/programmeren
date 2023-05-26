using Feest.Domain.DTO;
using Feest.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feest.Domain.Interface {
    public interface IEventRepository { 

        List<Event> GetAllEventByDate(DateTime date);
        List<Event> GetAllEvents();
        Event GetEventById(int id);
        List<Event> GetEventByTitle(string title);
    }
}
