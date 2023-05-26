using Feest.Domain.DTO;
using Feest.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feest.Domain.Interface {
    public interface IDayPlanRepository {

        int CreateDayPlan(User user, DateTime date);
        List<DayPlan> GetDayPlanOfUser(int id);
        bool ExistDayPlan(int id, DateTime date);
        bool ExistEventDayPlan(int dayPlanId, int eventId);
        List<Event> GetEventsOfDatPlanUser(int dayPlanId, int userId);
        List<Event> AddEventToDayPlanUser(int dayPlanId, int id1, int id2);
    }
}
