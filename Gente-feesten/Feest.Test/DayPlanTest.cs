using Feest.Domain.Interface;
using Feest.Domain.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feest.Test {
    internal class DayPlanTest {

        private DayPlanManager _manager;
        private IDayPlanRepository _repository;

        public DayPlanTest() {
            _manager = new(_repository);
        }


    }
}
