using Feest.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feest.Domain.Interface {
    public interface IEventRepository {

        List<Event> GetAllEvents();
        Event GetEventById(string id);
    }
}
