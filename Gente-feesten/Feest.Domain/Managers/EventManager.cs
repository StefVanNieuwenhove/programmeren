using Feest.Domain.DTO;
using Feest.Domain.Interface;
using Feest.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Feest.Domain.Managers {
    internal class EventManager {

        private readonly IEventRepository _repository;

        public EventManager(IEventRepository repository) {
            _repository = repository;
        }

        public List<EventDTO> GetAllEvents() {
            return _repository.GetAllEvents().Select(x => new EventDTO(x.Id, x.Title, x.StartDate, x.EndDate, x.Price, x.Description)).OrderBy(x => x.Title).ToList();
        }

        public List<EventDTO> GetAllDistinctEvents() {
            return _repository.GetAllEvents().Select(x => new EventDTO(x.Id, x.Title, x.StartDate, x.EndDate, x.Price, x.Description)).DistinctBy(x => x.Title).OrderBy(x => x.Title).ThenBy(x => x.StartDate).ToList();
        }

        public List<EventDTO> SearchEvent(string title) {
            return _repository.GetEventByTitle(title).Select(x => new EventDTO(x.Id, x.Title, x.StartDate, x.EndDate, x.Price, x.Description)).DistinctBy(x => x.Title).OrderBy(x => x.Title).ToList();
        }
    }
}
