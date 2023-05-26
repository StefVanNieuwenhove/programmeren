using Feest.Domain.DTO;
using Feest.Domain.Exceptions;
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

        public List<EventDTO> SearchEvent(string title, DateTime date) {
            try {
                return _repository.GetAllEventByDate(date).Where(x => x.Title.ToLower().Contains(title.ToLower())).Select(x => new EventDTO(x.Id, x.Title, x.StartDate, x.EndDate, x.Price, x.Description)).DistinctBy(x => x.Title).OrderBy(x => x.Title).ToList();
            } catch (EventException ex) {
                throw new EventException("EventManager - SearchEvent", ex);
            }
        }

        public List<EventDTO> GetEventsByTitle(string title, DateTime date) {
            try {
                return _repository.GetAllEventByDate(date).Where(x => x.Title.ToLower().Contains(title.ToLower())).Select(x => new EventDTO(x.Id, x.Title, x.StartDate, x.EndDate, x.Price, x.Description)).DistinctBy(x => x.Title).OrderBy(x => x.Title).ToList();
            } catch (EventException ex) {
                throw new EventException("EventManager - GetEventbyTitle", ex);
            }
        }

        public List<DateTime> GetStartDateEndDateEvents() {
           try {
                return _repository.GetAllEvents().Select(x => x.StartDate.Date).Distinct().Order().ToList();
            } catch (EventException ex) {
                throw new EventException("Eventmanager - GetStartDateEvents", ex);
            }
        }

        public List<EventDTO> GetAllEventByDate(DateTime date) {
            try {
                return _repository.GetAllEventByDate(date).Select(x => new EventDTO(x.Id, x.Title, x.StartDate, x.EndDate, x.Price, x.Description)).DistinctBy(x => x.Title).OrderBy(x => x.Title).ToList();
            } catch (EventException ex) {
                throw new EventException("EventManager - GetAllEventbyDate", ex);
            }
        }
            
    }
}
