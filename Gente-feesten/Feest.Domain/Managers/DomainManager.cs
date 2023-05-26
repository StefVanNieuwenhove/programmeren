using Feest.Domain.DTO;
using Feest.Domain.Interface;
using Feest.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feest.Domain.Managers {
    public class DomainManager {

        private readonly IEventRepository _eventRepo;
        private readonly IUserRepository _userRepo;
        private readonly IDayPlanRepository _dayPlanRepo;

        private EventManager _eventManager;
        private UserManager _userManager;
        private DayPlanManager _dayPlanManager;

        public DomainManager(IUserRepository userRepo, IEventRepository eventRepo, IDayPlanRepository dayPlanRepo) {
            _userRepo = userRepo;
            _eventRepo = eventRepo;
            _dayPlanRepo = dayPlanRepo;

            _eventManager = new(_eventRepo);
            _userManager = new(_userRepo);
            _dayPlanManager = new(_dayPlanRepo);
        }

        // EVENTS
        public List<EventDTO> GetAllEventByDate(DateTime date) {
            return _eventManager.GetAllEventByDate(date);
        }

        public List<EventDTO> SearchEvent(string title, DateTime date) => _eventManager.SearchEvent(title, date);

        public List<EventDTO> GetEventsByTitle(string title, DateTime date) => _eventManager.GetEventsByTitle(title, date);

        public List<DateTime> GetStartDateEndDateEvents() => _eventManager.GetStartDateEndDateEvents();


        // USERS
        public List<UserDTO> GetAllUsers() => _userManager.GetAllUsers();
        

        public UserDTO GetUserById(int id) => _userManager.GetUserById(id);
        

        public List<UserDTO> SearchUser(string username) => _userManager.SearchUser(username);

        // DAYPLAN
        public List<DayPlanDTO> GetUserDayplan(int id) {
            return _dayPlanManager.GetDayPlanOfUser(id);
        }

        public int CreateDayPlan(UserDTO user, DateTime date) {
             return _dayPlanManager.CreateDayPlan(user, date);
        }

        public List<string> AddEventToDayPlan(int dayPlanId,EventDTO dto,UserDTO user, DateTime date) => _dayPlanManager.AddEventToDayPlan(dayPlanId, dto, user, date);
    }
}
