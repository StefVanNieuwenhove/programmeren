using Feest.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feest.Domain.Managers {
    internal class DayPlanManager {
        private readonly IDayPlanRepository _dayPlanRepo;

        public DayPlanManager(IDayPlanRepository dayPlanRepo) {
            this._dayPlanRepo = dayPlanRepo;
        }
    }
}
