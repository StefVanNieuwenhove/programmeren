using Feest.Domain.Interface;
using Feest.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feest.Domain.Managers {
    internal class EventManager {

        private readonly IEventRepository _repository;

        public EventManager(IEventRepository repository) {
            _repository = repository;
        }

        public List<string> GetAllEvents() {
            return _repository.GetAllEvents().Select(x => $"{x.Title}").ToList();
        }
    }
}
