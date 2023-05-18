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

        public List<string> GetAllEvents() {
            return _eventManager.GetAllEvents(); 
        }
    }
}
