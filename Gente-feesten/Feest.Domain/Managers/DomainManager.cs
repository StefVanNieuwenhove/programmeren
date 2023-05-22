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
        public List<string> GetAllEvents() {
            return _eventManager.GetAllEvents(); 
        }

        // USERS
        public List<UserDTO> GetAllUsers() {
            return _userManager.GetAllUsers();
        }

        public UserDTO GetUserById(int id) {
            return _userManager.GetUserById(id);
        }

        public List<UserDTO> SearchUser(string username) => _userManager.SearchUser(username);

        // DAYPLAN
    }
}
